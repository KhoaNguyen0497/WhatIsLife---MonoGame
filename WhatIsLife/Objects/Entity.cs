using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Objects
{
    public enum Gender
    {
        Male,
        Female
    }



    public class Entity : BaseEntity
    {
        public Gender Gender { get; } = (Gender)GameConfig.Random.Next(2);
        public Entity()
        {
            Spawn();
        }

        public float Speed = 1;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(Position, Gender == Gender.Male ? GameConfig.Colors.MaleEntity : GameConfig.Colors.FemaleEntity, 10);
        }

        public void Spawn(Vector2? position = null)
        {
            if (position == null)
            {
                Position = new Vector2
                {
                    X = GameConfig.Random.Next(GameConfig.WorldWidth),
                    Y = GameConfig.Random.Next(GameConfig.WorldHeight)
                };
            }
            else
            {
                Position = (Vector2)position;
            }

            GameConfig.Random.NextUnitVector(out Velocity);
          
        }

        public void Move()
        {
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
        }
    }
}
