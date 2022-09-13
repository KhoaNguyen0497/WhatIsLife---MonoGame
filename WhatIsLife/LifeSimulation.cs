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
        private CameraHandler _cameraHandler;

        private int _debugUpdateCalls = 0;
        private int _debugDrawCalls = 0;

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



        protected override void Initialize()
        {
            base.Initialize();
            _cameraHandler = new CameraHandler(Window, GraphicsDevice);
            _graphics.PreferredBackBufferWidth = GameConfig.WindowsWitdth;
            _graphics.PreferredBackBufferHeight = GameConfig.WindowsHeight;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        

        private void PrintDebug(GameTime gameTime)
        {
            double maxLoop = 0; ;
            if (gameTime.ElapsedGameTime.TotalMilliseconds > TargetElapsedTime.TotalMilliseconds)
            {
                maxLoop = Math.Max(1, Math.Floor(_debugUpdateCalls / (gameTime.ElapsedGameTime.TotalMilliseconds / TargetElapsedTime.TotalMilliseconds)));
            }

            var averageUpdatePerSec = _debugUpdateCalls / gameTime.TotalGameTime.TotalSeconds;
            var actualFps = _debugDrawCalls / gameTime.TotalGameTime.TotalSeconds;
            var targetFps = 1000 / TargetElapsedTime.TotalMilliseconds;
            var msPerFrame = gameTime.ElapsedGameTime.TotalMilliseconds;

            Debug.WriteLine($"avg update/s: {averageUpdatePerSec}; actual fps: {actualFps}; target fps: {targetFps}; elapsed: {msPerFrame};loop {maxLoop}");
        }

        protected override void Update(GameTime gameTime)
        {
            double gameUpdateCalls = 0;
            gameUpdateCalls += GameConfig.SpeedMultiplier;


            while (gameUpdateCalls >= 1)
            {

                _debugUpdateCalls++;

                gameUpdateCalls -= 1;
                //Thread.Sleep(5);
            }

            PrintDebug(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {        
            GraphicsDevice.Clear(Color.Black);
            _cameraHandler.Update();
            _spriteBatch.Begin(transformMatrix: _cameraHandler.GetViewMatrix());
            _spriteBatch.DrawRectangle(new RectangleF(0, 0, GameConfig.WorldWidth, GameConfig.WorldHeight), Color.Red, 20);
            _spriteBatch.DrawCircle(new CircleF(new Point2(500, 500), 50), 10, Color.Red);
            DrawEntities();
            _spriteBatch.End();

            _debugDrawCalls++;
        }

        private void DrawEntities()
        {

        }
    }
}
