using Common.Attributes;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Common
{
	public class GameConfig
	{
        [RestartRequired]
		public static int WorldWidth { get; private set; } = 5000;

		public static int WorldHeight { get; } = 5000;

		public static int WindowsWitdth { get; } = 1920;
		public static int WindowsHeight { get; } = 1080;

		public static float SpeedMultiplier { get; set; } = 1f;

		public static float ZoomSpeed { get; set; } = 1f;
		public static float CameraSpeed { get; set; } = 5f;

		public static int UpdatesPerday { get; set; } = 100;
		public static int FoodPerDay { get; set; } = 10;
		public static int InitialEntities { get; set; } = 100;
		public static float BaseEntitySpeed { get; set; } = 2f;
		public static float BaseEntityRadius { get; set; } = 100f;

		public static bool Debug { get; set; } = true;

		public static bool TriggerRestart { get; set; } = false;

		public static class Colors
		{
			public static Color Background { get; set; } = ColorHelper.FromHex("#30343F");
			public static Color MaleEntity { get; set; } = ColorHelper.FromHex("#8ECEFD");
			public static Color FemaleEntity { get; set; } = ColorHelper.FromHex("#F88B9D");
			public static Color Food { get; set; } = ColorHelper.FromHex("#87C38F");
			public static Color GridColor { get; set; } = ColorHelper.FromHex("#eab676");
		}
		
		/// <summary>
		/// All properties within this class with RestartRequiredAttribute must have a private setter to prevent the values from being changed mid-game since a restart is required.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public static void SanityCheck()
        {
			Type objType = typeof(GameConfig);
			foreach (PropertyInfo f in objType.GetProperties())
			{
				if (f.IsDefined(typeof(RestartRequiredAttribute)))
				{
					if (!f.SetMethod.IsPrivate)
                    {
						throw new Exception($"Setter of {f.Name} must be private");
                    }
				}
			};
		}

		private static List<Action> QueuedSetters = new List<Action>();
		/// <summary>
		/// All properties with RestartRequiredAttribute can only be changed on game restart. This queues up the actions to be invoked on restart.
		/// </summary>
		public static void QueueSetters(Action action)
        {
			//QueuedSetters.GroupBy(x=>x.)

		}
		public static PropertyInfo GetPropertyInfo<TSource, TProperty>(
	TSource source,
	Expression<Func<TSource, TProperty>> propertyLambda)
		{
			Type type = typeof(TSource);

			MemberExpression member = propertyLambda.Body as MemberExpression;
			if (member == null)
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a method, not a property.",
					propertyLambda.ToString()));

			PropertyInfo propInfo = member.Member as PropertyInfo;
			if (propInfo == null)
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a field, not a property.",
					propertyLambda.ToString()));

			if (type != propInfo.ReflectedType &&
				!type.IsSubclassOf(propInfo.ReflectedType))
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a property that is not from type {1}.",
					propertyLambda.ToString(),
					type));

			return propInfo;
		}

	}
}

