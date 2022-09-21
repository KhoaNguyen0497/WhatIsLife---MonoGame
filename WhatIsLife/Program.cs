using Common;
using SettingsManager;
using System;

namespace WhatIsLife
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            do
            {
                using (var simulation = new LifeSimulation())
                {
                    GameConfig.TriggerRestart = false;
                    simulation.Run();
                }
            } while (GameConfig.TriggerRestart);
        }
    }
}
