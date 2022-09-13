using System;

namespace WhatIsLife
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var simulation = new LifeSimulation())
                simulation.Run();
        }
    }
}
