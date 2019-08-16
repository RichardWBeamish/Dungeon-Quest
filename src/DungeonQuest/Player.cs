using System;
using System.Collections.Generic;
using System.IO;

namespace DungeonQuest {
    public class Player : Creature {
        public int CurrentRoom;
        public int Level;
        public Equipment Weapon;
        public List<string> Inventory;

        /// Generates starting character
        public Player () {
            this.CurrentRoom = 0;
            this.Name = "";
            this.HP = 20;
            this.AC = 10;
            this.Level = 1;
            this.Inventory = new List<string> ();
        }
        public int Attack (Creature defender) {
            int roll = Rand.Next (1, 21);
            int damage = 0;
            if (roll + Weapon.ToHit >= defender.AC) {
                for (int i = 0; i < Weapon.DiceQuantity; i++) {
                    damage = damage + Rand.Next (1, Weapon.DiceType);
                }
            }
            defender.HP = defender.HP - damage;
            return damage;
        }
    }
}