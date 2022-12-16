using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Objects
{
    public abstract class BaseObject
    {
        public int Id { get; set; }

        public Vector2 Position = new Vector2();
        public abstract void Draw(SpriteBatch spriteBatch);


        public int Age { get; set; }
    }
}
