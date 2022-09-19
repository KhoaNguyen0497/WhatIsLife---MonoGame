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

		public int Age { get; set; }

		// List to keep track of entities currently targeting this object
		public List<Entity> Entities { get; set; }

		// Private constructor because we are driving the creation of objects through recycling disposed objects
		private Food()
		{

		}

		public static Food Create()
		{
			Food food;
			if (GlobalObject.RecycledFood.Any())
			{
				food = GlobalObject.RecycledFood.Pop();
			}
			else
			{
				food = new Food();
			}

			food.Respawn();
			return food;
		}


		public void Respawn(Vector2? position = null)
		{
			Age = 0;
			Entities = new List<Entity>();

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
			Entities.ForEach(x =>
			{			
				if ((x.Target as Food) == null)
				{
					throw new Exception("Error");
				}

				x.Target = null;
			});

			GlobalObject.RecycledFood.Push(this);
			GlobalObject.FoodList.Remove(this);
		}

		public static List<Food> NewDaySpawn()
		{
			List<Food> list = new List<Food>();
			for (int i = 0; i < GameConfig.FoodPerDay; i++)
			{
				list.Add(Create());
			}

			return list;
		}

		public void Update()
		{
			Age++;

			if (Age >= 1000)
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

			spriteBatch.DrawPoint(Position, GameConfig.Colors.Food, 5);
		}
	}
}
