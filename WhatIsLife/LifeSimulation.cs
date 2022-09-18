using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using WhatIsLife.Helpers;
using WhatIsLife.Objects;
using WhatIsLife.Systems;

namespace WhatIsLife
{
    public class LifeSimulation : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private CameraHandler _cameraHandler;

        private int _debugUpdateCalls = 0;
        private int _debugDrawCalls = 0;

        private float _frames = 0;

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

            for (int i = 0; i < GameConfig.InitialEntities; i++)
            {
                Entity entity = new Entity();
                GlobalObject.Entities.Add(entity);
            }
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
            var msPerFrame = gameTime.ElapsedGameTime.TotalMilliseconds;

            Debug.WriteLine($"avg update/s: {averageUpdatePerSec}; actual fps: {actualFps}; elapsed: {msPerFrame};loop {maxLoop}; foodSize {GlobalObject.FoodList.AllObjects().Count}/{GlobalObject.FoodList.AllObjects().Count(x=>!x.IsActive)}; RecycledFood {GlobalObject.RecycledFood.Count};");
        }

        private void ProcessFrame()
        {
            _debugUpdateCalls++;

            if (_debugUpdateCalls % GameConfig.UpdatesPerday == 0)
            {
                GlobalObject.FoodList.AddRange(Food.NewDaySpawn());
            }

            _frames -= 1;
            GlobalObject.Entities.AllObjects().ForEach(x => x.Update());
        }

        protected override void Update(GameTime gameTime)
        {

            _frames += GameConfig.SpeedMultiplier;
            while (_frames >= 1)
            {
                ProcessFrame();
            }

            PrintDebug(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {        
            GraphicsDevice.Clear(GameConfig.Colors.Background);
            _cameraHandler.Update();
            _spriteBatch.Begin(transformMatrix: _cameraHandler.GetViewMatrix());
            _spriteBatch.DrawRectangle(new RectangleF(0, 0, GameConfig.WorldLength, GameConfig.WorldHeight), Color.Black, 2);
            DrawEntities();
            _spriteBatch.End();

            _debugDrawCalls++;
        }

        private void DrawEntities()
        {
            GlobalObject.Entities.AllObjects().ForEach(x => x.Draw(_spriteBatch));
            GlobalObject.FoodList.AllObjects().ForEach(x => x.Draw(_spriteBatch));
        }
    }
}
