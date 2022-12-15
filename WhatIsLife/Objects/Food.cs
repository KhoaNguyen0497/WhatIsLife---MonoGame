using Common;
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
        public static int Id { get; set; } = 1;

        public bool IsActive { get; set; }
		// List to keep track of entities currently targeting this object
		public List<Entity> Entities { get; set; }

		

		public void Respawn(Vector2? position = null)
		{
			Id += 1;
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
				if ((x.Target as Food) == null)
				{
					throw new Exception("Error");
				}

				x.Target = null;
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
			if (GameObjects.NewDay)
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
