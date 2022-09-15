using System;
using System.Collections.Generic;
using System.Text;
using WhatIsLife.Objects;
using WhatIsLife.Objects.Interfaces;

namespace WhatIsLife.Helpers
{
    public static class GlobalObject
    {
        public static List<Entity> Entities { get; } = new List<Entity>();
        public static List<Food> FoodList { get; } = new List<Food>();
        public static Random Random { get; } = new Random();

        public static Stack<Entity> RecycledEntities { get; set; } = new Stack<Entity>();
        public static Stack<Food> RecycledFood { get; set; } = new Stack<Food>();
    }
}
