using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsManager
{
	public partial class SettingsManagerForm : Form
	{
		private int _currentTrackedEntity = 0;
		public SettingsManagerForm()
		{
			InitializeComponent();
			InitializeValues();
		}

		private void InitializeValues()
		{
			updateSpeedBar.Value = (int)(GlobalObjects.GameConfig.SpeedMultiplier * 100);
			debugCheckBox.Checked = GlobalObjects.GameConfig.Debug;
			worldWidthInput.Value = GlobalObjects.GameConfig.WorldWidth;
			worldHeightInput.Value = GlobalObjects.GameConfig.WorldHeight;
		}

		public void RefreshDebugStats()
		{
			currentDayLabel.Text = $"Current Day: {GlobalObjects.GameStats.CurrentDay}";

			SetObjectStat(ref entityStatTextBox, GlobalObjects.GameStats.NumberOfEntities + GlobalObjects.GameStats.EntitiesRecycled, GlobalObjects.GameStats.NumberOfEntities, GlobalObjects.GameStats.EntitiesRecycled);
			SetObjectStat(ref foodStatTextBox, GlobalObjects.GameStats.FoodQuantity + GlobalObjects.GameStats.FoodRecycled, GlobalObjects.GameStats.FoodQuantity, GlobalObjects.GameStats.FoodRecycled);
			lastUpdatedLabel.Text = $"Last Updated: {DateTime.Now:T}";
		}

		public void RefreshStats()
		{
			updateSpeedBar.Value = (int)(GlobalObjects.GameConfig.SpeedMultiplier * 100f);
			cursorCoordinate.Text = $"Cursor: {GlobalObjects.GameStats.Cursor.X:#},{GlobalObjects.GameStats.Cursor.Y:#}";

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

			
			nearestEntityTextBox.Rtf = GlobalObjects.GameStats.NearestEntityData;
		}

		private void SetObjectStat(ref RichTextBox textBox, int total, int active, int recycled)
		{
			var sb = new StringBuilder();
			sb.Append(@"{\rtf1\ansi");
			sb.Append($@"\b {active}\b0/{recycled}/{total}");
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
				sb.Append(@"{\rtf1\ansi ");
				sb.Append($@"Error: no data Entity {key}");
				GlobalObjects.GameStats.TrackedEntities[key] = sb.ToString();
				trackedEntitiesComboBox.Items.Add(key);

				if (trackedEntitiesComboBox.SelectedIndex == -1)
				{
					trackedEntitiesComboBox.SelectedIndex = 0;
				}

				nextTrackedEntityButton.Enabled = true;
				previousTrackedEntityButton.Enabled = true;
			}
		}

		private void removeEntityButton_Click(object sender, EventArgs e)
		{
			int key = Convert.ToInt32(trackedEntitiesComboBox.SelectedItem);
			int currentIndex = trackedEntitiesComboBox.SelectedIndex;

			if ( key == 0 )
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

			if (trackedEntitiesComboBox.Items.Count == 0)
			{
				nextTrackedEntityButton.Enabled = false;
				previousTrackedEntityButton.Enabled = false;
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
	}
}
