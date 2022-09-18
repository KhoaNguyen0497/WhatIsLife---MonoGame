using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using WhatIsLife.Objects;

namespace WhatIsLife.Helpers
{
    public static class GameConfig
    {
        public static int WorldLength = 15000;
        public static int WorldHeight = 20000;

        public static int WindowsWitdth = 1000;
        public static int WindowsHeight = 1000;

        public static float SpeedMultiplier = 1f;

        public static float ZoomSpeed = 1f;
        public static float CameraSpeed = 10f;

        public static int UpdatesPerday = 200;
        public static int FoodPerDay = 200;
        public static int InitialEntities = 1000;

        public static bool Debug = true;
        public static class Colors
        {
            public static Color Background = ColorHelper.FromHex("#30343F");
            public static Color MaleEntity = ColorHelper.FromHex("#8ECEFD");
            public static Color FemaleEntity = ColorHelper.FromHex("#F88B9D");
            public static Color Food = ColorHelper.FromHex("#87C38F");
        }

    }
}
