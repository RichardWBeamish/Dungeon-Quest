using System;
using System.Collections.Generic;
using System.IO;

namespace DungeonQuest {
    public abstract class Creature {
        public Random Rand = new Random ();
        public string Name;
        public int HP;
        public int AC;
    }
}