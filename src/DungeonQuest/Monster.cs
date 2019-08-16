using System;
using System.Collections.Generic;
using System.IO;

namespace DungeonQuest {
    public class Monster : Creature {
        public string Type;
        public int ToHit;
        public int DiceQuantity;
        public int DiceType;
        public int[] Dice = { 4, 6, 8, 10, 12, 20 };
        public Monster () { }
    }

    public class OldMan : Monster {
        public OldMan () {
            this.Name = "Gailik";
            this.Type = "Humanoid";
            this.HP = 150;
            this.AC = 18;
            this.ToHit = 10;
            this.DiceQuantity = 5;
            this.DiceType = Dice[3];
        }
    }

    public class Dragon : Monster {
        public Dragon () {
            string[] nameList = { "Red Dragon", "White Dragon", "Black Dragon", "Blue Dragon", "Green Dragon" };
            this.Name = nameList[Rand.Next (0, nameList.Length)];
            this.Type = "Dragon";
            this.HP = Rand.Next (85, 130);
            this.AC = Rand.Next (13, 19);
            this.ToHit = Rand.Next (7, 10);
            this.DiceQuantity = Rand.Next (5, 8);
            this.DiceType = Dice[Rand.Next (2, 4)];
        }
    }

    public class Beast : Monster {
        public Beast () {
            string[] nameList = { "Ape", "Bear", "Boar", "Snake", "Wolf", "Giant Spider", "Tiger", "Elephant", "Chupacabra", "Jackalobe" };
            this.Name = nameList[Rand.Next (0, nameList.Length)];
            this.Type = "Beast";
            this.HP = Rand.Next (30, 50);
            this.AC = Rand.Next (7, 12);
            this.ToHit = Rand.Next (3, 5);
            this.DiceQuantity = Rand.Next (2, 4);
            this.DiceType = Dice[Rand.Next (0, 2)];
        }
    }

    public class Undead : Monster {
        public Undead () {
            string[] nameList = { "Banshee", "Mummy", "Vampire", "Zombie", "Ghost", "Ghoul", "Poltergeist", "Skeleton" };
            this.Name = nameList[Rand.Next (0, nameList.Length)];
            this.Type = "Undead";
            this.HP = Rand.Next (45, 70);
            this.AC = Rand.Next (10, 13);
            this.ToHit = Rand.Next (4, 6);
            this.DiceQuantity = Rand.Next (2, 4);
            this.DiceType = Dice[Rand.Next (0, 3)];
        }
    }

    public class Humanoid : Monster {
        public Humanoid () {
            string[] nameList = { "Drow", "Cyclops", "Tiefling", "Birdman", "Evil Farting Mo", "Clown", "Man in a Banana Hammock", "Mother-in-Law", "Drunkard", };
            this.Name = nameList[Rand.Next (0, nameList.Length)];
            this.Type = "Humanoid";
            this.HP = Rand.Next (10, 35);
            this.AC = Rand.Next (7, 12);
            this.ToHit = Rand.Next (0, 5);
            this.DiceQuantity = Rand.Next (1, 3);
            this.DiceType = Dice[Rand.Next (0, 3)];
        }
    }
}