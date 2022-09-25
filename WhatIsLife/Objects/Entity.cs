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
	public enum Gender
	{
		Male,
		Female
	}

	public class Entity : BaseObject, IReusable, IDisposable
	{

		public Vector2 Velocity;

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
		public Entity()
		{
			RotationAngleRadian = (float)Math.PI / 180 * RotationAngle;
		}


		public void Dispose()
		{
			IsActive = false;
			GameObjects.Entities.Remove(this);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Color genderColor = Gender == Gender.Male ? GlobalObjects.GameConfig.Colors.MaleEntity : GlobalObjects.GameConfig.Colors.FemaleEntity;
			spriteBatch.DrawPoint(Position, genderColor, 10);

			if (GlobalObjects.GameConfig.Debug)
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
			Gender = (Gender)GameObjects.Random.Next(2);
			Target = null;
			Speed = GlobalObjects.GameConfig.BaseEntitySpeed;
			Radius = GlobalObjects.GameConfig.BaseEntityRadius;
			IsActive = true;
			_startDay = GlobalObjects.GameStats.CurrentDay;
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

			GameObjects.Random.NextUnitVector(out Velocity);
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
				Food food = GameObjects.FoodList.GetNearbyObjects(Position, Radius).FirstOrDefault(x => VectorHelper.WithinDistance(x.Position, Position, Radius));

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
	
			if (Velocity == Vector2.Zero || GameObjects.Random.Next(100) < NoiseRandomness)
			{
				Velocity = Velocity.Rotate(GameObjects.Random.NextSingle(-RotationAngleRadian, RotationAngleRadian));
			}
		}

		// {Age - 60}% chance to die every day after turning 60
		public bool RandomDeathChance()
        {
			if (Age >= 60)
            {
				if (GameObjects.Random.Next(100) < Age - 60)
                {
					return true;
                }
            }

			return false;
        }

		public void Update()
		{
			if (GlobalObjects.GameConfig.Debug)
			{
				if (Target != null)
				{
					if (!VectorHelper.WithinDistance((Target as Food).Position, Position, Radius))
					{
						GlobalObjects.GameConfig.SpeedMultiplier = 0;
					}
				}
			}

			if (RandomDeathChance())
            {
				Dispose();
            }

			if (!IsActive)
            {
				return;
            }

			FindFood();
			Wander();		
		}

		public void Move()
		{
			if (GlobalObjects.GameConfig.Debug)
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

			if (Position.X >= GlobalObjects.GameConfig.WorldWidth)
			{
				Position.X = GlobalObjects.GameConfig.WorldWidth - 1;
				Velocity.X *= -1;
			}

			if (Position.Y <= 0)
			{
				Position.Y = 0;
				Velocity.Y *= -1;
			}

			if (Position.Y >= GlobalObjects.GameConfig.WorldHeight)
			{
				Position.Y = GlobalObjects.GameConfig.WorldHeight - 1;
				Velocity.Y *= -1;
			}

			// Reset velocity because sometimes entities slow down to not go pass its Target
			// Sometimes Velocity can get to Zero. E.g. when a target spawns at the same position, causing the the path finding system to output velocity of Zero
			if (Velocity == Vector2.Zero)
			{
				GameObjects.Random.NextUnitVector(out Velocity);
			}
			else
			{
				Velocity.Normalize();
			}

			Velocity *= Speed;
		}
	}
}
