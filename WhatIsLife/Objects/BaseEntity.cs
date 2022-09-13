using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Objects
{
    public abstract class BaseEntity
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
