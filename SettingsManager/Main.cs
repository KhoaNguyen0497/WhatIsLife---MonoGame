﻿using Common;
using ScottPlot;
using ScottPlot.Plottable;
using SettingsManager.Graph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettingsManager
{
    public partial class SettingsManagerForm : Form
    {
        public SettingsManagerForm()
        {
            InitializeComponent();
            InitializeValues();
        }
        ScottPlot.Plottable.DataLogger Logger;

        List<BaseGraphContainer> GraphContainers = new List<BaseGraphContainer>();
        private void InitializeValues()
        {
            updateSpeedBar.Value = (int)(GlobalObjects.GameConfig.SpeedMultiplier * 100);
            debugCheckBox.Checked = GlobalObjects.GameConfig.Debug;
            drawEnabledCheckBox.Checked = GlobalObjects.GameConfig.Draw;
            worldWidthInput.Value = GlobalObjects.GameConfig.WorldWidth;
            worldHeightInput.Value = GlobalObjects.GameConfig.WorldHeight;

            GraphContainers.Add(new LineGraphContainer
            {
                Graph = entitiesbyDayGraph,
                RenderCondition = () => { return renderEntitiesByDay.Checked; },
                XDataGetter = () => { return GlobalObjects.GameStats.DailyStats.Days.ToArray(); },
                YDataGetter = () => { return GlobalObjects.GameStats.DailyStats.Entities.ToArray(); },
                XLabel = "",
                YLabel = "",
                Label = "Entities"
            });

            GraphContainers.Add(new LineGraphContainer
            {
                Graph = foodByDayGraph,
                RenderCondition = () => { return renderFoodByDay.Checked; },
                XDataGetter = () => { return GlobalObjects.GameStats.DailyStats.Days.ToArray(); },
                YDataGetter = () => { return GlobalObjects.GameStats.DailyStats.Food.ToArray(); },
                XLabel = "",
                YLabel = "",
                Label = "Food"
            });

            GraphContainers.Add(new DistributionGraphContainer
            {
                Graph = averageSpeedGraph,
                RenderCondition = () => { return renderAvegrageSpeed.Checked; },
                DataGetter = () => { return GlobalObjects.GameStats.DailyStats.Speed.ToArray(); },
                Bins = 2,
                XMin=1,
                XMax=4,
                XLabel = "Day",
                YLabel = "",
                Label = "Average Speed"
            });

            GraphContainers.ForEach(x => x.Initiate());
        }



        // Only refreshed when debug is on
        public void RefreshDebugStats()
        {
            currentDayLabel.Text = $"Current Day: {GlobalObjects.GameStats.CurrentDay}";

            SetObjectStat(ref entityStatTextBox, GlobalObjects.GameStats.NumberOfEntities, GlobalObjects.GameStats.EntitiesRecycled, GlobalObjects.GameStats.NumberOfEntities + GlobalObjects.GameStats.EntitiesRecycled);
            SetObjectStat(ref foodStatTextBox, GlobalObjects.GameStats.FoodQuantity, GlobalObjects.GameStats.FoodRecycled, GlobalObjects.GameStats.FoodQuantity + GlobalObjects.GameStats.FoodRecycled);
            lastUpdatedLabel.Text = $"Last Updated: {DateTime.Now:T}";
        }
        public void RefreshGraphs()
        {
            GraphContainers.ForEach(x => x.Render());
        }
        public void RefreshStats()
        {
            updateSpeedBar.Value = (int)(GlobalObjects.GameConfig.SpeedMultiplier * 100f);
            cursorCoordinate.Text = $"Cursor: {GlobalObjects.GameStats.Cursor.X:#},{GlobalObjects.GameStats.Cursor.Y:#}";

            #region Tracked entity
            // For adding entity by clicking near them
            foreach (var trackedEntityData in GlobalObjects.GameStats.TrackedEntities)
            {
                int key = trackedEntityData.Key;
                if (!trackedEntitiesComboBox.Items.Contains(key))
                {
                    trackedEntitiesComboBox.Items.Add(key);
                    trackedEntitiesComboBox.SelectedItem = key;
                }
            }

            // Tracked entities
            int selectedEntity = Convert.ToInt32(trackedEntitiesComboBox.SelectedItem);
            if (selectedEntity == 0) // either the entity doesnt exist or it was recently removed
            {
                trackedEntitiesComboBox.Text = "";
                trackedEntityTextBox.Text = "";
            }

            if (GlobalObjects.GameStats.TrackedEntities.TryGetValue(selectedEntity, out var entity))
            {
                trackedEntityTextBox.Rtf = entity;
            }

            nextTrackedEntityButton.Enabled = previousTrackedEntityButton.Enabled = trackedEntitiesComboBox.Items.Count > 1;
            #endregion

            #region Performance
            int totalFrames = GlobalObjects.GameStats.PerformanceRecords.Last().Frames - GlobalObjects.GameStats.PerformanceRecords.First().Frames;
            int totalUpdates = GlobalObjects.GameStats.PerformanceRecords.Last().Updates - GlobalObjects.GameStats.PerformanceRecords.First().Updates;

            double timeDiff = GlobalObjects.GameStats.PerformanceRecords.Last().Millisecond - GlobalObjects.GameStats.PerformanceRecords.First().Millisecond;

            double fps = totalFrames / (timeDiff / 1000);
            double ups = totalUpdates / (timeDiff / 1000);

            fpsLabel.Text = $"FPS: {fps:#.#}";
            upsLabel.Text = $"UPS: {ups:#.#}";
            #endregion

            nearestEntityTextBox.Rtf = GlobalObjects.GameStats.NearestEntityData;
        }

        private void SetObjectStat(ref RichTextBox textBox, int active, int recycled, int total)
        {
            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi");
            sb.Append($@"\b {active}\b0/{recycled}/{total}");
            sb.Append(@"}");

            textBox.Rtf = sb.ToString();
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.Debug = debugCheckBox.Checked;
        }

        private void updateSpeedBar_Scroll(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.SpeedMultiplier = updateSpeedBar.Value / 100f;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.TriggerRestart = true;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void worldWidthInput_ValueChanged(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.SetValueOnRestart(x => x.WorldWidth, (int)worldWidthInput.Value);
        }

        private void worldHeightInput_ValueChanged(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.SetValueOnRestart(x => x.WorldHeight, (int)worldWidthInput.Value);
        }

        private void addEntityButton_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(entityInput.Value);

            if (!trackedEntitiesComboBox.Items.Contains(key))
            {
                GlobalObjects.GameConfig.ToggleTrackedEntities.Add(key);

                var sb = new StringBuilder();
                sb.Append(@"{\rtf1\ansi");
                sb.Append($@"Error: no data Entity {key}");
                sb.Append(@"}");

                GlobalObjects.GameStats.TrackedEntities[key] = sb.ToString();
                trackedEntitiesComboBox.Items.Add(key);

                if (trackedEntitiesComboBox.SelectedIndex == -1)
                {
                    trackedEntitiesComboBox.SelectedIndex = 0;
                }
            }
        }

        private void removeEntityButton_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(trackedEntitiesComboBox.SelectedItem);
            int currentIndex = trackedEntitiesComboBox.SelectedIndex;

            if (key == 0)
            {
                return;
            }

            if (!trackedEntitiesComboBox.Items.Contains(key))
            {
                throw new Exception($"List of tracked entities does not contain {key}");
            }

            trackedEntitiesComboBox.Items.Remove(key);
            GlobalObjects.GameConfig.ToggleTrackedEntities.Add(key);
            GlobalObjects.GameStats.TrackedEntities.Remove(key);

            trackedEntitiesComboBox.SelectedIndex = currentIndex - 1;

            if (trackedEntitiesComboBox.SelectedIndex < 0)
            {
                trackedEntitiesComboBox.SelectedIndex = trackedEntitiesComboBox.Items.Count - 1;
            }
        }

        private void previousTrackedEntityButton_Click(object sender, EventArgs e)
        {
            if (trackedEntitiesComboBox.SelectedIndex <= 0)
            {
                trackedEntitiesComboBox.SelectedIndex = trackedEntitiesComboBox.Items.Count - 1;
            }
            else
            {
                trackedEntitiesComboBox.SelectedIndex--;
            }
        }

        private void nextTrackedEntityButton_Click(object sender, EventArgs e)
        {
            if (trackedEntitiesComboBox.SelectedIndex >= trackedEntitiesComboBox.Items.Count - 1)
            {
                trackedEntitiesComboBox.SelectedIndex = 0;
            }
            else
            {
                trackedEntitiesComboBox.SelectedIndex++;
            }
        }

        private void drawEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GlobalObjects.GameConfig.Draw = drawEnabledCheckBox.Checked;
        }
    }
}
