using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Helpers
{
    public static class VectorHelper
    {
        public static bool WithinDistance(Vector2 p1, Vector2 p2, float distance)
        {
            return Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) <= Math.Pow(distance, 2);
        }
    }
}
