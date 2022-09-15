using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatIsLife.Helpers;

namespace WhatIsLife.Objects
{
    public enum Gender
    {
        Male,
        Female
    }



    public class Entity : BaseObject
    {
        public Vector2 Velocity;

        public BaseObject Target { get; set; }
        public Gender Gender { get; } = (Gender)GlobalObject.Random.Next(2);
        public Entity()
        {
            Spawn();
        }

        public float Speed = 0.5f;

        public float Radius = 50;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(Position, Gender == Gender.Male ? GameConfig.Colors.MaleEntity : GameConfig.Colors.FemaleEntity, 10);

            if (GameConfig.Debug)
            {
                spriteBatch.DrawCircle(Position, Radius, 20, Gender == Gender.Male ? GameConfig.Colors.MaleEntity : GameConfig.Colors.FemaleEntity, 1);
                if (Target != null)
                {
                    spriteBatch.DrawLine(Position, Target.Position, Color.Wheat, 2);
                }
            }          
        }

        // Spawn and Respawn
        public void Spawn(Vector2? position = null)
        {
            if (position == null)
            {
                Position = new Vector2
                {
                    X = GlobalObject.Random.Next(GameConfig.WorldWidth),
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
            // Only if the entity is not targetting something else
            if (Target == null)
            {
                Food food = GlobalObject.FoodList.FirstOrDefault(x => x.IsActive && VectorHelper.WithinDistance(x.Position, this.Position, Radius));

                if (food != null)
                {
                    Target = food;
                }
            }
            else
            {
                if (Target.GetType() == typeof(Food) )
                {
                    // If food is already consumed. Clear the Target
                    if (!(Target as Food).IsActive)
                    {
                        Target = null;
                    }
                    // Consume the food
                    else if (Target.Position == Position)
                    {
                        (Target as Food).Dispose();
                        Target = null;
                    }
                    
                }
            }
        }

        public void Update()
        {
            FindFood();

            Move();
        }

        public void Move()
        {
            if (Target != null)
            {
                Vector2 directionToTarget = new Vector2
                {
                    X = Target.Position.X - Position.X,
                    Y = Target.Position.Y - Position.Y
                };

                Velocity = directionToTarget;
                Velocity.Normalize();
                Velocity *= Math.Min(directionToTarget.Length(), Speed);
            }

            Position += Velocity;

            if (Position.X <= 0f)
            {
                Position.X = 0;
                Velocity.X *= -1;
            }

            if (Position.X >= GameConfig.WorldWidth)
            {
                Position.X = GameConfig.WorldWidth;
                Velocity.X *= -1;
            }

            if (Position.Y <= 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
            }

            if (Position.Y >= GameConfig.WorldHeight)
            {
                Position.Y = GameConfig.WorldHeight;
                Velocity.Y *= -1;
            }

            // Reset velocity because sometimes entities slow down to not go pass its Target
            Velocity.Normalize();
            Velocity *= Speed;
        }
    }
}
