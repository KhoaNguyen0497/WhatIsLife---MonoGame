using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsLife.Objects.Interfaces
{
    // To reuse objects and avoid garbage collection
    public interface IReusable
    {
        public bool IsActive { get; set; }
        public void Respawn(Vector2? position = null);
    }
}
