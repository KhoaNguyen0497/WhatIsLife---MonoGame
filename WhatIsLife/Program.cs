using Common;
using System;
using WhatIsLife.Helpers;

namespace WhatIsLife
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            GameObjects.MainForm.Show();

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
