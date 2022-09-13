using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Objects
{
    public class Entity : BaseEntity
    {
        public Entity()
        {
            Spawn();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawPoint(Position, Color.Blue, 50);
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
        }
    }
}
