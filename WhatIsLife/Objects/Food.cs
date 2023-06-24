using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using WhatIsLife.Helpers;
using WhatIsLife.Objects.Interfaces;

namespace WhatIsLife.Objects
{
    public class Food : BaseObject, IReusable, IDisposable
    {
        private static int _currentId { get; set; } = 0;

        // List to keep track of entities currently targeting this object
        // This is needed because Food can be Expired and Respawned the next day, which causes issues in the targetting system
        public List<Entity> Entities { get; set; }

        public void Respawn(Vector2? position = null)
        {
            if (Id == 0)
            {
                _currentId++;
                Id = _currentId;
            }
            Entities = new List<Entity>();
            Age = 0;

            if (position == null)
            {
                Position.X = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldWidth);
                Position.Y = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldHeight);
            }
            else
            {
                Position.X = ((Vector2)position).X;
                Position.Y = ((Vector2)position).Y;
            }

            IsActive = true;
        }


        public void Dispose()
        {
            IsActive = false;
            Entities.ForEach(x =>
            {
                if ((x.Target as Food) != this)
                {
                    throw new Exception("Error");
                }
                else
                {
                    x.Target = null;
                }
            });

            GameObjects.FoodList.Remove(this);
        }

        public static void NewDaySpawn()
        {
            for (int i = 0; i < GlobalObjects.GameConfig.FoodPerDay; i++)
            {
                GameObjects.FoodList.CreateNewObject();
            }
        }

        public void Update()
        {
            if (GlobalObjects.TempVariables.NewDay)
            {
                Age++;
            }

            if (Age >= 10)
            {
                Dispose();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive)
            {
                return;
            }

            spriteBatch.DrawPoint(Position, GlobalObjects.GameConfig.Colors.Food, 5);
        }
    }
}
