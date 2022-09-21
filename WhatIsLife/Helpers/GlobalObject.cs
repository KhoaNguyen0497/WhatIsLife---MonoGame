using System;
using System.Collections.Generic;
using System.Text;
using WhatIsLife.Objects;
using WhatIsLife.Objects.Interfaces;
using WhatIsLife.Systems;

namespace WhatIsLife.Helpers
{
    public static class GlobalObject
    {
        public static GridSystem<Entity> Entities { get; set; } = new GridSystem<Entity>();
        public static GridSystem<Food> FoodList { get; set; } = new GridSystem<Food>();
        public static Random Random { get; } = new Random();

        public static Stack<Entity> RecycledEntities { get; set; } = new Stack<Entity>();
        public static Stack<Food> RecycledFood { get; set; } = new Stack<Food>();
    }
}
