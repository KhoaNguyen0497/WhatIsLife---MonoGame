using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using WhatIsLife.Objects;

namespace WhatIsLife
{
    public static class GameConfig
    {
        public static int WorldWidth = 10000;
        public static int WorldHeight = 10000;

        public static int WindowsWitdth = 1000;
        public static int WindowsHeight = 1000;

        public static float SpeedMultiplier = 10f;

        public static float ZoomSpeed = 1f;
        public static float CameraSpeed = 10f;

        public static Random Random = new Random();

        public static class Colors
        {
            public static Color Background = ColorHelper.FromHex("#30343F");
            public static Color MaleEntity = ColorHelper.FromHex("#8ECEFD");
            public static Color FemaleEntity = ColorHelper.FromHex("#F88B9D");
        }
    }
}
