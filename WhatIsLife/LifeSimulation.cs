﻿using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Linq;
using WhatIsLife.Helpers;
using WhatIsLife.Objects;
using static Common.GameStats;

namespace WhatIsLife
{
    public class LifeSimulation : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private CameraHandler _cameraHandler;

        private int _updateCalls = 0;
        private int _drawCalls = 0;

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
            GlobalObjects.TempVariables = new TempVariable();
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
            var currentStat = new PerformanceRecord
            {
                Millisecond = gameTime.TotalGameTime.TotalMilliseconds,
                Frames = _drawCalls,
                Updates = _updateCalls
            };
            GlobalObjects.GameStats.PerformanceRecords.AddLast(currentStat);

            // This should always break. Worst case it will remove everything, but that should not be possible
            while (true)
            {
                PerformanceRecord firstNode = GlobalObjects.GameStats.PerformanceRecords.First();
                if (currentStat.Millisecond - firstNode.Millisecond > GlobalObjects.GameConfig.PerformanceMonitorInterval)
                {
                    GlobalObjects.GameStats.PerformanceRecords.RemoveFirst();
                }
                else
                {
                    break;
                }

            }
        }

        private void ProcessFrame()
        {
            _updateCalls++;
            _frames -= 1;

            GameObjects.Entities.RepopulateGrid();

            if (_updateCalls % GlobalObjects.GameConfig.UpdatesPerday == 0)
            {
                GlobalObjects.GameStats.DailyStats.Update(
                    GlobalObjects.GameStats.CurrentDay,
                    GameObjects.Entities.ActiveCount(), 
                    GameObjects.FoodList.ActiveCount(), 
                    GameObjects.Entities.AllObjects().Select(x => (double)x.Attributes.Speed.Value)
                );
                GlobalObjects.GameStats.CurrentDay += 1;
                GameObjects.MainForm.RefreshGraphs();
                GlobalObjects.TempVariables.NewDay = true;
                Food.NewDaySpawn();
            }


            GameObjects.Entities.AllObjects().ForEach(x =>
            {
                x.Update();
                x.Move();
            });


            GameObjects.FoodList.AllObjects().ForEach(x => x.Update());

            GlobalObjects.TempVariables.NewDay = false;
        }

        private void UpdateStats(GameTime gameTime)
        {
            if (GlobalObjects.GameConfig.Debug)
            {
                GlobalObjects.GameStats.NumberOfEntities = GameObjects.Entities.ActiveCount();
                GlobalObjects.GameStats.EntitiesRecycled = GameObjects.Entities.RecycledCount();
                GlobalObjects.GameStats.FoodQuantity = GameObjects.FoodList.ActiveCount();
                GlobalObjects.GameStats.FoodRecycled = GameObjects.FoodList.RecycledCount();

                GameObjects.MainForm.RefreshDebugStats();
            }

            if (GlobalObjects.GameConfig.DebugConsole)
            {
                PrintDebug(gameTime);
            }

            if (GlobalObjects.GameConfig.Debug)
            {
                #region entity tracking
                foreach (var id in GlobalObjects.GameConfig.ToggleTrackedEntities)
                {
                    Entity trackedEntity = GameObjects.Entities.AllObjects(true).FirstOrDefault(x => x.Id == id);

                    if (trackedEntity != null)
                    {
                        trackedEntity.IsTracked = !trackedEntity.IsTracked;
                    }
                }

                GlobalObjects.GameConfig.ToggleTrackedEntities.Clear();


                var radiusSquared = Math.Pow(GlobalObjects.GameConfig.EntityTrackingRadius, 2);
                GlobalObjects.GameStats.NearestEntityData = "";
                Entity entityNearCursor = null;
                GameObjects.Entities.AllObjects(true).ForEach(x =>
                {
                    if (x.IsTracked)
                    {
                        GlobalObjects.GameStats.TrackedEntities[x.Id] = x.ToString();
                    }

                    if (GlobalObjects.GameConfig.EntityMouseTracking)
                    {
                        if (x.IsActive)
                        {
                            if (VectorHelper.WithinDistance(GlobalObjects.GameStats.Cursor, x.Position, GlobalObjects.GameConfig.EntityTrackingRadius))
                            {
                                var currentDistanceSquared = VectorHelper.DistanceSquared(GlobalObjects.GameStats.Cursor, x.Position);
                                if (currentDistanceSquared <= radiusSquared)
                                {
                                    entityNearCursor = x;
                                    radiusSquared = currentDistanceSquared;
                                }
                            }
                        }
                    }
                });

                if (entityNearCursor != null)
                {
                    GlobalObjects.GameStats.NearestEntityData = entityNearCursor.ToString();

                    if (GlobalObjects.TempVariables.LeftClickPressed)
                    {
                        entityNearCursor.IsTracked = true;
                    }
                }
                #endregion
            }


            GlobalObjects.TempVariables.LeftClickPressed = false;
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

            UpdateStats(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(GlobalObjects.GameConfig.Colors.Background);

            if (!GlobalObjects.GameConfig.Draw)
            {
                return;
            }

            _drawCalls++;
            _cameraHandler.Update();
            _spriteBatch.Begin(transformMatrix: _cameraHandler.GetViewMatrix());
            DrawGrids();
            DrawEntities();
            _spriteBatch.DrawRectangle(new RectangleF(0, 0, GlobalObjects.GameConfig.WorldWidth, GlobalObjects.GameConfig.WorldHeight), Color.Black, 2);
            _spriteBatch.End();

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
