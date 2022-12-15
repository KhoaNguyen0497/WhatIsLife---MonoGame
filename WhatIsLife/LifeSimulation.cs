using Common;
using Common.Attributes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using SettingsManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
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


        // Settings below are important. Its so that 1) the fps is capped at monitor's refresh rate (vsync), and 2) if update calls take too long, the game is slowed down (fewer draw calls) instead of skipping draw calls
        // Marked with *
        public LifeSimulation()
        {
            InactiveSleepTime = new TimeSpan(0);
            IsMouseVisible = true;
            IsFixedTimeStep = false; //*

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            _graphics.PreferredBackBufferWidth = GlobalObjects.GameConfig.WindowsWitdth;
            _graphics.PreferredBackBufferHeight = GlobalObjects.GameConfig.WindowsHeight;
       
            _graphics.SynchronizeWithVerticalRetrace = true; //*
            _graphics.ApplyChanges();

            GlobalObjects.GameStats = new GameStats();
            GlobalObjects.GameConfig.SanityCheck();
            SetupGameObjects();
        }

        // Called on game start and restart
        private void SetupGameObjects()
        {
            // Reinitiate grid to apply
            GameObjects.Entities.Initiate();
            GameObjects.FoodList.Initiate();

            for (int i = 0; i < GlobalObjects.GameConfig.InitialEntities; i++)
            {
                GameObjects.Entities.CreateNewObject();
            }
        }

        protected override void LoadContent()
        {
            _cameraHandler = new CameraHandler(Window, GraphicsDevice);
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

            Debug.WriteLine($"avg update/s: {averageUpdatePerSec}; actual fps: {actualFps}; elapsed: {msPerFrame};loop {maxLoop}; foodSize {GameObjects.FoodList.AllObjects().Count};");
        }

        private void ProcessFrame()
        {
            _debugUpdateCalls++;
            _frames -= 1;

            GameObjects.Entities.RepopulateGrid();
            GameObjects.FoodList.RepopulateGrid();

            if (_debugUpdateCalls % GlobalObjects.GameConfig.UpdatesPerday == 0)
            {
                GlobalObjects.GameStats.CurrentDay += 1;
                GameObjects.NewDay = true;
                Food.NewDaySpawn();
            }

            GameObjects.Entities.AllObjects().ForEach(x =>
            {
                x.Update();
                x.Move();
            });

            GameObjects.FoodList.AllObjects().ForEach(x => x.Update());

            GameObjects.NewDay = false;
        }

        private void UpdateStats()
        {
            GlobalObjects.GameStats.NumberOfEntities = GameObjects.Entities.Count();
            GlobalObjects.GameStats.EntitiesRecycled = GameObjects.Entities.RecycledCount();
            GlobalObjects.GameStats.FoodQuantity = GameObjects.FoodList.Count();
            GlobalObjects.GameStats.FoodRecycled = GameObjects.FoodList.RecycledCount();

            GameObjects.MainForm.RefreshStats();
        }

        protected override void Update(GameTime gameTime)
        {

            _frames += GlobalObjects.GameConfig.SpeedMultiplier;
            while (_frames >= 1)
            {
                if (GlobalObjects.GameConfig.TriggerRestart)
                {
                    this.Exit();
                }

                ProcessFrame();
            }

            if (GlobalObjects.GameConfig.Debug)
			{
                UpdateStats();
                PrintDebug(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {        
            GraphicsDevice.Clear(GlobalObjects.GameConfig.Colors.Background);
            _cameraHandler.Update();
            _spriteBatch.Begin(transformMatrix: _cameraHandler.GetViewMatrix());
            DrawGrids();
            DrawEntities();
            _spriteBatch.DrawRectangle(new RectangleF(0, 0, GlobalObjects.GameConfig.WorldWidth, GlobalObjects.GameConfig.WorldHeight), Color.Black, 2);
            _spriteBatch.End();

            _debugDrawCalls++;
        }

        private void DrawGrids()
        {
            if (GlobalObjects.GameConfig.Debug)
            {
                GameObjects.Entities.Draw(_spriteBatch, _cameraHandler.Camera.Zoom);
            }
        }

        private void DrawEntities()
        {
            GameObjects.Entities.AllObjects().ForEach(x => x.Draw(_spriteBatch));
            GameObjects.FoodList.AllObjects().ForEach(x => x.Draw(_spriteBatch));
        }
    }
}
