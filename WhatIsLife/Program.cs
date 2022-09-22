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
                    GlobalObjects.GameConfig.TriggerRestart = false;
                    GlobalObjects.GameConfig.InvokeQueuedSetters();
                    simulation.Run();
                }
            } while (GlobalObjects.GameConfig.TriggerRestart);
        }
    }
}
