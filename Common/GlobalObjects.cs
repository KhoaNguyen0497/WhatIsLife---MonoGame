using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class GlobalObjects
    {
        public static GameConfig GameConfig { get; set; } = new GameConfig();

        public static GameStats GameStats { get; set; } = new GameStats();
    }
}
