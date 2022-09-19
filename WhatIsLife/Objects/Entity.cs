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
	public enum Gender
	{
		Male,
		Female
	}

	public class Entity : BaseObject, IReusable, IDisposable
	{
		public Vector2 Velocity;
		public int Age { get; set; }
		public bool IsActive { get; set; }

		public BaseObject Target { get; set; }

		public Gender Gender { get; set; }

		public float Speed { get; set; }

		public float Radius { get; set; }

		/// <summary>
		/// Chance of turning every update
		/// </summary>
		public int NoiseRandomness { get; } = 20;

		/// <summary>
		/// The Entity can turn x degrees to the left or right
		/// </summary>
		public float RotationAngle { get; } = 45;
		public float RotationAngleRadian { get; }

		public List<Tuple<Vector2, BaseObject>> History = new List<Tuple<Vector2, BaseObject>>();

		// Private constructor because we are driving the creation of objects through recycling disposed objects
		private Entity()
		{
			RotationAngleRadian = (float)Math.PI / 180 * RotationAngle;
		}

		public static Entity Create()
		{
			Entity entity;
			if (GlobalObject.RecycledEntities.Any())
			{
				entity = GlobalObject.RecycledEntities.Pop();
			}
			else
			{
				entity = new Entity();
			}

			entity.Respawn();
			return entity;
		}

		public void Dispose()
		{
			IsActive = false;
			GlobalObject.RecycledEntities.Push(this);
			GlobalObject.Entities.Remove(this);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Color genderColor = Gender == Gender.Male ? GameConfig.Colors.MaleEntity : GameConfig.Colors.FemaleEntity;
			spriteBatch.DrawPoint(Position, genderColor, 10);

			if (GameConfig.Debug)
			{
				spriteBatch.DrawCircle(Position, Radius, 20, genderColor, 1);
				if (Target != null)
				{
					spriteBatch.DrawLine(Position, Target.Position, genderColor, 2);
				}			
			}
		}

		// Spawn and Respawn
		public void Respawn(Vector2? position = null)
		{
			// Reset everything just in case since we are utilizing dispose()
			Gender = (Gender)GlobalObject.Random.Next(2);
			Target = null;
			Speed = GameConfig.BaseEntitySpeed;
			Radius = GameConfig.BaseEntityRadius;
			IsActive = true;
			Age = 0;
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

			GlobalObject.Random.NextUnitVector(out Velocity);
			Velocity *= Speed;
		}

		// Find and move to Food, or consume it
		public void FindFood()
		{
			if (Target != null)
			{
				if (Target.GetType() == typeof(Food))
				{
					// Consume the food
					if (Target.Position == Position)
					{
						(Target as Food).Dispose();
					}
				}
			}
			
			if (Target == null)
			{
				Food food = GlobalObject.FoodList.GetNearbyObjects(Position, Radius).FirstOrDefault(x => VectorHelper.WithinDistance(x.Position, Position, Radius));

				if (food != null)
				{
					Target = food;
					food.Entities.Add(this);
				}
			}		
		}

		public void Wander()
		{
			if (Target != null)
			{
				return;
			}
	
			if (Velocity == Vector2.Zero || GlobalObject.Random.Next(100) < NoiseRandomness)
			{
				Velocity = Velocity.Rotate(GlobalObject.Random.NextSingle(-RotationAngleRadian, RotationAngleRadian));
			}
		}

		public void Update()
		{
			Age++;

			if (GameConfig.Debug)
			{
				if (Target != null)
				{
					if (!VectorHelper.WithinDistance((Target as Food).Position, Position, Radius))
					{
						GameConfig.SpeedMultiplier = 0;
					}
				}
			}

			FindFood();
			Wander();
			Move();
		}

		public void Move()
		{
			if (GameConfig.Debug)
			{
				History.Add(new Tuple<Vector2, BaseObject>(Position, Target));
				if (History.Count > 10)
				{
					History.RemoveAt(0);
				}
			}

			if (Target != null)
			{
				Vector2 directionToTarget = new Vector2
				{
					X = Target.Position.X - Position.X,
					Y = Target.Position.Y - Position.Y
				};

				Velocity = directionToTarget;
				
				if (Velocity.Length() > Speed)
				{
					Velocity.Normalize();
					Velocity *= Speed;
				}              
			}

			Position += Velocity;

			if (Position.X <= 0f)
			{
				Position.X = 0;
				Velocity.X *= -1;
			}

			if (Position.X >= GameConfig.WorldLength)
			{
				Position.X = GameConfig.WorldLength - 1;
				Velocity.X *= -1;
			}

			if (Position.Y <= 0)
			{
				Position.Y = 0;
				Velocity.Y *= -1;
			}

			if (Position.Y >= GameConfig.WorldHeight)
			{
				Position.Y = GameConfig.WorldHeight - 1;
				Velocity.Y *= -1;
			}

			// Reset velocity because sometimes entities slow down to not go pass its Target
			// Sometimes Velocity can get to Zero. E.g. when a target spawns at the same position, causing the the path finding system to output velocity of Zero
			if (Velocity == Vector2.Zero)
			{
				GlobalObject.Random.NextUnitVector(out Velocity);
			}
			else
			{
				Velocity.Normalize();
			}

			Velocity *= Speed;
		}
	}
}
