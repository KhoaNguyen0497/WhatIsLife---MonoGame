using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;

namespace Common
{
    public static class GameConfig
    {
        public static int WorldLength = 5000;
        public static int WorldHeight = 5000;

        public static int WindowsWitdth = 1920;
        public static int WindowsHeight = 1080;

        public static float SpeedMultiplier = 1f;

        public static float ZoomSpeed = 1f;
        public static float CameraSpeed = 5f;

        public static int UpdatesPerday = 100;
        public static int FoodPerDay = 10;
        public static int InitialEntities = 100;
        public static float BaseEntitySpeed = 2f;
        public static float BaseEntityRadius = 100f;

        public static bool Debug = true;

        public static bool TriggerRestart = false;
        public static class Colors
        {
            public static Color Background = ColorHelper.FromHex("#30343F");
            public static Color MaleEntity = ColorHelper.FromHex("#8ECEFD");
            public static Color FemaleEntity = ColorHelper.FromHex("#F88B9D");
            public static Color Food = ColorHelper.FromHex("#87C38F");
            public static Color GridColor = ColorHelper.FromHex("#eab676");
        }

    }
}

