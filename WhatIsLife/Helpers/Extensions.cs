using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Helpers
{
    public static class Extensions
    {
        public static bool Chance(this Random random, int chance)
        {
            return random.Next(1, 100) < chance;
        }
    }
}
