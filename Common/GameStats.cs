﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Common
{
    public class GameStats
    {
        public int CurrentDay { get; set; }

        public int NumberOfEntities { get; set; }

        public int EntitiesRecycled { get; set; }

        public int FoodQuantity { get; set; }

        public int FoodRecycled { get; set; }

        public Vector2 Cursor { get; set; }
        public Dictionary<int, string> TrackedEntities { get; set; } = new Dictionary<int, string>();

        public string NearestEntityData { get; set; }

        /// <summary>
        ///  List of &lt;currentSecond, totalFramesDrawn, totalUpdates&gt;
        /// </summary>
        public LinkedList<PerformanceRecord> PerformanceRecords { get; set; } = new LinkedList<PerformanceRecord>();


        public double TimeElapsed { get; set; }

        public class PerformanceRecord
        {
            public double Millisecond { get; set;}

            public int Frames { get; set; }

            public int Updates { get; set; }
        }
    }
}
