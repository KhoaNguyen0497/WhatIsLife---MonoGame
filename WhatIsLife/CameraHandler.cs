using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WhatIsLife.Helpers;

namespace WhatIsLife
{
    public class CameraHandler
    {
        public OrthographicCamera Camera;
        private int _cameraBaseMovementSpeed = 10;
        private int _previousMouseScrollValue = 0;
        public CameraHandler(GameWindow window, GraphicsDevice graphicsDevice)
        {
            BoxingViewportAdapter viewportAdapter = new BoxingViewportAdapter(window, graphicsDevice, GameConfig.WindowsWitdth, GameConfig.WindowsHeight);
            Camera = new OrthographicCamera(viewportAdapter);
            Camera.MaximumZoom = 2f;
            Camera.MinimumZoom = Math.Max(GameConfig.WindowsWitdth / (float)GameConfig.WorldWidth, GameConfig.WindowsHeight / (float)GameConfig.WorldHeight);
        }

        public void Update()
        {
            Camera.Move(GetMovementDirection() * _cameraBaseMovementSpeed * GameConfig.CameraSpeed);

            int scrollWheelValue = Mouse.GetState().ScrollWheelValue;
            Camera.ZoomIn((scrollWheelValue - _previousMouseScrollValue) / 12000f * GameConfig.ZoomSpeed);
            _previousMouseScrollValue = scrollWheelValue;
            AdjustCameraBound();
        }

        private Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                movementDirection += Vector2.UnitX;
            }
            return movementDirection;
        }


        private void AdjustCameraBound()
        {
            Camera.Move(new Vector2
            {
                X = Math.Max(-Camera.BoundingRectangle.X, 0) + Math.Min(GameConfig.WorldWidth - Camera.BoundingRectangle.X - Camera.BoundingRectangle.Width, 0),
                Y = Math.Max(-Camera.BoundingRectangle.Y, 0) + Math.Min(GameConfig.WorldHeight - Camera.BoundingRectangle.Y - Camera.BoundingRectangle.Height, 0)
            });
        }

        public Matrix GetViewMatrix() => Camera.GetViewMatrix();
    }
}
