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

        public void RefreshStats()
        {
            currentDayLabel.Text = $"Current Day: {GlobalObjects.GameStats.CurrentDay}";
            numOfEntitiesLabel.Text = $"Entities (total/active/recycled): {GlobalObjects.GameStats.NumberOfEntities + GlobalObjects.GameStats.EntitiesRecycled}/{GlobalObjects.GameStats.NumberOfEntities}/{GlobalObjects.GameStats.EntitiesRecycled}";
            foodLabel.Text = $"Food (total/active/recycled): {GlobalObjects.GameStats.FoodQuantity + GlobalObjects.GameStats.FoodRecycled}/{GlobalObjects.GameStats.FoodQuantity}/{GlobalObjects.GameStats.FoodRecycled}";
            lastUpdatedLabel.Text = $"Last Updated: {DateTime.Now:T}";
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
    }
}
