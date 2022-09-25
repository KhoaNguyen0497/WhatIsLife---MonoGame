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
		public bool IsActive { get; set; }
		// List to keep track of entities currently targeting this object
		public List<Entity> Entities { get; set; }

		// Private constructor because we are driving the creation of objects through recycling disposed objects
		public Food()
		{

		}

		public void Respawn(Vector2? position = null)
		{
			_startDay = GlobalObjects.GameStats.CurrentDay;
			Entities = new List<Entity>();

			if (position == null)
			{
				Position = new Vector2
				{
					X = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldWidth),
					Y = GameObjects.Random.Next(GlobalObjects.GameConfig.WorldHeight)
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
