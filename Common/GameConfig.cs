using Common.Attributes;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;

namespace Common
{
	public static class GameConfig
	{ 
		[RestartRequired]
		public static int WorldWidth { get; set; } = 5000;

		[RestartRequired]
		public static int WorldHeight { get; set; } = 5000;

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

	}
}

