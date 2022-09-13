using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Diagnostics;
using System.Threading;
using WhatIsLife.Objects;

namespace WhatIsLife
{
    public class LifeSimulation : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int updateCall = 0;
        private int drawCall = 0;
        private double UpdateCalls = 1;
        private double SpeedMultiplier = 10;


        private int WindowsWitdth = 1000;
        private int WindowsHeight = 1000;

        private int WorldWidth = 5000;
        private int WorldHeight = 5000;

        private int CurrentMouseWheelValue = 0;
        private float ZoomSpeed = 1f;
        public LifeSimulation()
        {
            InactiveSleepTime = new TimeSpan(0);
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // These are important. Its so that 1) the fps is capped at monitor's refresh rate (vsync), and 2) if update calls take too long, the game is slowed down (fewer draw calls) instead of skipping draw calls
            _graphics.SynchronizeWithVerticalRetrace = true;
            IsFixedTimeStep = false;
        }

        private OrthographicCamera _camera;

        protected override void Initialize()
        {
            base.Initialize();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, WindowsWitdth, WindowsHeight);
            _camera = new OrthographicCamera(viewportAdapter);
            _camera.MaximumZoom = 2f;
            _camera.MinimumZoom = Math.Max(WindowsWitdth / (float)WorldWidth, WindowsHeight / (float)WorldHeight);


           _graphics.PreferredBackBufferWidth = WindowsWitdth;
            _graphics.PreferredBackBufferHeight = WindowsHeight;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                movementDirection += Vector2.UnitX;
            }
            return movementDirection;
        }

 
        private void AdjustCameraBound()
        {
            _camera.Move(new Vector2
            {
                X = Math.Max(-_camera.BoundingRectangle.X, 0) + Math.Min(WorldWidth - _camera.BoundingRectangle.X - _camera.BoundingRectangle.Width, 0),
                Y = Math.Max(-_camera.BoundingRectangle.Y, 0) + Math.Min(WorldHeight - _camera.BoundingRectangle.Y - _camera.BoundingRectangle.Height, 0)
            });
        }

        private void PrintDebug(GameTime gameTime)
        {
            double maxLoop = 0; ;
            if (gameTime.ElapsedGameTime.TotalMilliseconds > TargetElapsedTime.TotalMilliseconds)
            {
                maxLoop = Math.Max(1, Math.Floor(UpdateCalls / (gameTime.ElapsedGameTime.TotalMilliseconds / TargetElapsedTime.TotalMilliseconds)));
            }

            var averageUpdatePerSec = updateCall / gameTime.TotalGameTime.TotalSeconds;
            var actualFps = drawCall / gameTime.TotalGameTime.TotalSeconds;
            var targetFps = 1000 / TargetElapsedTime.TotalMilliseconds;
            var msPerFrame = gameTime.ElapsedGameTime.TotalMilliseconds;

            Debug.WriteLine($"avg update/s: {averageUpdatePerSec}; actual fps: {actualFps}; target fps: {targetFps}; elapsed: {msPerFrame};loop {maxLoop}");
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateCalls +=  SpeedMultiplier;
            

            while (UpdateCalls >= 1)
            {

                updateCall++;

                UpdateCalls -= 1;
                //Thread.Sleep(5);
            }

            PrintDebug(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            const float movementSpeed = 200;
            _camera.Move(GetMovementDirection() * movementSpeed * (float)SpeedMultiplier);

            int scrollWheelValue = Mouse.GetState().ScrollWheelValue;
            _camera.ZoomIn((scrollWheelValue - CurrentMouseWheelValue) / 12000f * ZoomSpeed);
            CurrentMouseWheelValue = scrollWheelValue;
            AdjustCameraBound();
            GraphicsDevice.Clear(Color.Black);

            var transformMatrix = _camera.GetViewMatrix();

            _spriteBatch.Begin(transformMatrix: transformMatrix);
            _spriteBatch.DrawRectangle(new RectangleF(0, 0, WorldWidth, WorldHeight), Color.Red, 20);
            _spriteBatch.DrawCircle(new CircleF(new Point2(50, 50), 50), 10, Color.Red);
            _spriteBatch.End();
            drawCall++;
        }
    }
}
