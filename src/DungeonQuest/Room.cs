using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DungeonQuest {
    public class Room {
        public Random rand = new Random ();
        public int Number;
        public int Exit;
        public int Enter;
        public Monster Monster;
        public int Height;
        public int Diameter;
        public string Reward;

        /// Generates the next room in the dungeon
        public Room (int roomCount) {
            this.Number = roomCount;
            this.Exit = Number - 1;
            this.Enter = Number + 1;
            this.Monster = GenerateMonster ();
            GenerateEnvironment ();
        }

        /// Rondomly Generates and Returns a Monster
        public Monster GenerateMonster () {
            int monsterSelector = rand.Next (0, 4);
            Monster nextMonster = null;
            switch (monsterSelector) {
                case 0:
                    nextMonster = new Dragon ();
                    break;
                case 1:
                    nextMonster = new Beast ();
                    break;
                case 2:
                    nextMonster = new Undead ();
                    break;
                case 3:
                    nextMonster = new Humanoid ();
                    break;
            }
            return nextMonster;
        }

        /// Randomly Generates Environment
        private void GenerateEnvironment () {
            Height = rand.Next (10, 50);
            Diameter = rand.Next (30, 100);
        }
    }
}