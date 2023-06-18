namespace Common
{
    public static class GlobalObjects
    {
        public static GameConfig GameConfig { get; set; } = new GameConfig();

        public static GameStats GameStats { get; set; } = new GameStats();

        public static TempVariable TempVariables { get; set; } = new TempVariable();
    }
}
