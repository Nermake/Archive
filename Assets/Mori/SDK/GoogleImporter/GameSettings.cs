using System;
using System.Collections.Generic;

namespace Mori.SDK.GoogleImporter
{
    [Serializable]
    public class GameSettings
    {
        public List<ItemSettings> Items;
        public List<LevelSettings> Levels;
    }
}

