using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DungeonQuest {
    public class Equipment {
        public Random Rand = new Random ();
        public string Name;
        public string Type;
        public int ToHit;
        public int DiceQuantity;
        public int DiceType;
        public int Range;
        public Equipment PickUpItem (string name) {
            List<Equipment> itemList = JsonConvert.DeserializeObject<List<Equipment>> (File.ReadAllText ("Equipment.json"));
            foreach (Equipment item in itemList) {
                if (name.Contains (item.Type)) {
                    item.Name = name;
                    return item;
                }
            }
            return new Weapon (name);
        }

        public class Utility : Equipment { }

        public class Weapon : Equipment {
            public Weapon (string name) {
                this.Name = name;
                this.ToHit = 3;
                this.DiceQuantity = 2;
                this.DiceType = 4;
                this.Range = 5;
            }
        }
    }
}