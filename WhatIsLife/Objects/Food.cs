using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatIsLife.Helpers;
using WhatIsLife.Objects.Interfaces;

namespace WhatIsLife.Objects
{
    public class Food : BaseObject, IReusable, IDisposable
    {
        public bool IsActive { get; set; }

        public static Food Create()
        {
            Food food;
            if (GlobalObject.RecycledFood.Any())
            {
                food = GlobalObject.RecycledFood.Pop();
                food.Respawn();
            }
            else
            {
                food = new Food();
                food.Spawn();
            }

            return food;
        }

        public void Respawn()
        {
            Spawn();
        }

        public void Spawn(Vector2? position = null)
        {
            if (position == null)
            {
                Position = new Vector2
                {
                    X = GlobalObject.Random.Next(GameConfig.WorldLength),
                    Y = GlobalObject.Random.Next(GameConfig.WorldHeight)
                };
            }
            else
            {
                Position = (Vector2)position;
            }

            IsActive = true;
        }

        public void Dispose()
        {
            IsActive = false;
            GlobalObject.RecycledFood.Push(this);

            // TEMP
            GlobalObject.FoodList.Remove(this);
        }

        public static List<Food> NewDaySpawn()
        {
            List<Food> list = new List<Food>();
            for (int i = 0; i < GameConfig.FoodPerDay; i++)
            {
                list.Add(Food.Create());
            }

            return list;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive)
            {
                return;
            }

            spriteBatch.DrawPoint(Position,GameConfig.Colors.Food, 5);
        }


    }
}
