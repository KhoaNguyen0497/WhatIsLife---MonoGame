using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WhatIsLife.Objects
{
    public abstract class BaseObject
    {
        public int Id { get; set; }

        public Vector2 Position = new Vector2();
        public abstract void Draw(SpriteBatch spriteBatch);

        public bool IsActive { get; set; }
        public int Age { get; set; }
    }
}
