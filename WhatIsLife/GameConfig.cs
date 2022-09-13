using System;
using System.Collections.Generic;
using System.Text;
using WhatIsLife.Objects;

namespace WhatIsLife
{
    public static class GameConfig
    {
        public static int WorldWidth = 5000;
        public static int WorldHeight = 5000;

        public static int WindowsWitdth = 1000;
        public static int WindowsHeight = 1000;

        public static float SpeedMultiplier = 5f;

        public static float ZoomSpeed = 1f;
        public static float CameraSpeed = 10f;

        public static Random Random = new Random();
    }
}
