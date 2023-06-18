using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace WhatIsLife
{
    public class CameraHandler
    {
        public OrthographicCamera Camera;
        private int _cameraBaseMovementSpeed = 10;
        private int _previousMouseScrollValue = 0;
        private float _currentSpeed;
        private int _zoom;
        private KeyboardState _previousKeyState;
        private MouseState _previousMouseState;
        public CameraHandler(GameWindow window, GraphicsDevice graphicsDevice)
        {
            BoxingViewportAdapter viewportAdapter = new BoxingViewportAdapter(window, graphicsDevice, GlobalObjects.GameConfig.WindowsWitdth, GlobalObjects.GameConfig.WindowsHeight);
            Camera = new OrthographicCamera(viewportAdapter);
            Camera.MaximumZoom = 2f;
            Camera.MinimumZoom = Math.Max(GlobalObjects.GameConfig.WindowsWitdth / (float)GlobalObjects.GameConfig.WorldWidth, GlobalObjects.GameConfig.WindowsHeight / (float)GlobalObjects.GameConfig.WorldHeight);
        }

        public void Update()
        {
            HandleInput(out Vector2 movementDirection);
            Camera.Move(movementDirection * _cameraBaseMovementSpeed * GlobalObjects.GameConfig.CameraSpeed);

            Camera.ZoomIn(_zoom / 12000f * GlobalObjects.GameConfig.ZoomSpeed);
            _zoom = 0;
            AdjustCameraBound();
        }

        private void HandleInput(out Vector2 movementDirection)
        {
            movementDirection = Vector2.Zero;
            int scrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _zoom += scrollWheelValue - _previousMouseScrollValue;
            _previousMouseScrollValue = scrollWheelValue;

            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            GlobalObjects.GameStats.Cursor = Camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));

            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                movementDirection += Vector2.UnitY;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                movementDirection -= Vector2.UnitY;
            }

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                movementDirection -= Vector2.UnitX;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                movementDirection += Vector2.UnitX;
            }

            if (keyboardState.IsKeyDown(Keys.OemMinus))
            {
                _zoom -= 100;
            }

            if (keyboardState.IsKeyDown(Keys.OemPlus))
            {
                _zoom += 100;
            }

            if (keyboardState.IsKeyDown(Keys.Space) && !_previousKeyState.IsKeyDown(Keys.Space))
            {
                if (GlobalObjects.GameConfig.SpeedMultiplier == 0)
                {
                    GlobalObjects.GameConfig.SpeedMultiplier = _currentSpeed;
                }
                else
                {
                    _currentSpeed = GlobalObjects.GameConfig.SpeedMultiplier;
                    GlobalObjects.GameConfig.SpeedMultiplier = 0;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                GlobalObjects.TempVariables.LeftClickPressed = true;
            }

            _previousKeyState = keyboardState;
            _previousMouseState = mouseState;
        }


        private void AdjustCameraBound()
        {
            Camera.Move(new Vector2
            {
                X = Math.Max(-Camera.BoundingRectangle.X, 0) + Math.Min(GlobalObjects.GameConfig.WorldWidth - Camera.BoundingRectangle.X - Camera.BoundingRectangle.Width, 0),
                Y = Math.Max(-Camera.BoundingRectangle.Y, 0) + Math.Min(GlobalObjects.GameConfig.WorldHeight - Camera.BoundingRectangle.Y - Camera.BoundingRectangle.Height, 0)
            });
        }

        public Matrix GetViewMatrix() => Camera.GetViewMatrix();
    }
}
