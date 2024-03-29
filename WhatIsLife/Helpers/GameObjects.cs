﻿using SettingsManager;
using System;
using WhatIsLife.Objects;
using WhatIsLife.Systems;

namespace WhatIsLife.Helpers
{
    public static class GameObjects
    {
        public static GridSystem<Entity> Entities { get; set; } = new GridSystem<Entity>();
        public static GridSystem<Food> FoodList { get; set; } = new GridSystem<Food>();
        public static Random Random { get; } = new Random();
        public static SettingsManagerForm MainForm { get; set; } = new SettingsManagerForm();
    }
}
