﻿using Common;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void debug_CheckedChanged(object sender, EventArgs e)
        {
            GameConfig.Debug = debug.Checked;
        }

        private void updateSpeed_Scroll(object sender, EventArgs e)
        {
            GameConfig.SpeedMultiplier = updateSpeed.Value / 100f;
        }
    }
}
