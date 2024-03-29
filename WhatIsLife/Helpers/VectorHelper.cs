﻿using Microsoft.Xna.Framework;
using System;

namespace WhatIsLife.Helpers
{
    public static class VectorHelper
    {
        public static bool WithinDistance(Vector2 p1, Vector2 p2, float distance)
        {
            return Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) <= Math.Pow(distance, 2);
        }

        public static float DistanceSquared(Vector2 p1, Vector2 p2)
        {
            return (float)(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
