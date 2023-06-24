using Common.Attributes;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Common
{
    public class GameConfig
    {
        [RestartRequired]
        public int WorldWidth { get; private set; } = 10000;

        [RestartRequired]
        public int WorldHeight { get; private set; } = 10000;

        public int WindowsWitdth { get; } = 1000;

        public int WindowsHeight { get; } = 900;

        public float SpeedMultiplier { get; set; } = 1f;

        public float ZoomSpeed { get; set; } = 1f;
        public float CameraSpeed { get; set; } = 5f;

        public int UpdatesPerday { get; set; } = 100;
        public int FoodPerDay { get; set; } = 500;
        public int InitialEntities { get; set; } = 1000;
        public float BaseEntitySpeed { get; set; } = 2f;
        public float BaseEntityRadius { get; set; } = 100f;

        public float EntityTrackingRadius { get; set; } = 100f;

        public bool Debug { get; set; } = false;
        public bool DebugConsole { get; set; } = true;
        public bool EnableDeath { get; set; } = true;

        public int MaxEntity { get; set; } = 10000;
        public bool EntityMouseTracking { get; set; } = true;

        public bool TriggerRestart { get; set; } = false;

        public List<int> ToggleTrackedEntities { get; set; } = new List<int>();

        public int PerformanceMonitorInterval { get; set; } = 10000; // keep data within x milliseconds. Used for performance monitoring
        public ColorConfig Colors { get; set; } = new ColorConfig();
        public class ColorConfig
        {
            public Color Background { get; set; } = ColorHelper.FromHex("#30343F");
            public Color MaleEntity { get; set; } = ColorHelper.FromHex("#8ECEFD");
            public Color FemaleEntity { get; set; } = ColorHelper.FromHex("#F88B9D");
            public Color Food { get; set; } = ColorHelper.FromHex("#87C38F");
            public Color GridColor { get; set; } = ColorHelper.FromHex("#eab676");
        }

        /// <summary>
        /// All properties within this class with RestartRequiredAttribute must have a private setter to prevent the values from being changed mid-game since a restart is required.
        /// </summary>
        public void SanityCheck()
        {
            Type objType = typeof(GameConfig);
            foreach (PropertyInfo f in objType.GetProperties())
            {
                if (f.IsDefined(typeof(RestartRequiredAttribute)))
                {
                    if (f.SetMethod == null)
                    {
                        throw new Exception($"{f.Name} must have a private setter");
                    }
                    if (!f.SetMethod.IsPrivate)
                    {
                        throw new Exception($"Setter of {f.Name} must be private");
                    }
                }
            };
        }

        private Dictionary<PropertyInfo, Action> _queuedSetters = new Dictionary<PropertyInfo, Action>();
        /// <summary>
        /// All properties with RestartRequiredAttribute can only be changed on game restart. This queues up the actions to be invoked on restart.
        /// </summary>
        public void SetValueOnRestart<T>(Expression<Func<GameConfig, T>> expr, T value)
        {
            MemberExpression member = expr.Body as MemberExpression;
            UnaryExpression unary = expr.Body as UnaryExpression;

            member = member ?? (unary != null ? unary.Operand as MemberExpression : null);
            _queuedSetters[member.Member as PropertyInfo] = () =>
            {
                (member.Member as PropertyInfo).SetValue(this, value);
            };
        }

        public void InvokeQueuedSetters()
        {
            foreach (var action in _queuedSetters.Values)
            {
                action.Invoke();
            }

            _queuedSetters.Clear();
        }
    }
}

