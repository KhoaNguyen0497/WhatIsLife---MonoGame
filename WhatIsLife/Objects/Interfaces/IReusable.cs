using Microsoft.Xna.Framework;

namespace WhatIsLife.Objects.Interfaces
{
    // To reuse objects and avoid garbage collection
    public interface IReusable
    {
        public bool IsActive { get; set; }
        public void Respawn(Vector2? position = null);
    }
}
