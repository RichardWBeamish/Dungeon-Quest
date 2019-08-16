using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DungeonQuest {
    public class GameLoop {
        public bool QuitGame;
        public GameTrack GameTrack;
        public Player Player;
        public GameLoop () {
            QuitGame = false;
            GameTrack = new GameTrack ();
        }

        /// <summary>Asks player to Load game or Start New game</summary>
        /// <returns>true = start new; false = load game</returns>
        public bool StartGame () {
            string playerInfo = File.ReadAllText ("Player.json");
            if (playerInfo.Contains ("Name")) {
                Player = JsonConvert.DeserializeObject<Player> (playerInfo);
                Console.WriteLine ($"Continue as {Player.Name}? Y/N");
                string input = Console.ReadLine ().ToLower ();
                switch (input.Contains ("n")) {
                    case true:
                        return true;
                    default:
                        return false;
                }
            } else { return true; }
        }

        /// <summary>Resets all files to Game Start and begins new game</summary>
        public void NewGame () {
            GameTrack.Player = new Player ();
            GameTrack.Room = FirstRoom ();
            GameTrack.Map.Add (GameTrack.Room);
            GameTrack.AddRoomToMap ();
            Tutorial ();
            ResetFiles ();
        }

        /// <summary>Creates the first room of the game</summary>
        /// <returns>first room in game</returns>
        public Room FirstRoom () {
            Room room = new Room (0);
            room.Exit = 0;
            room.Monster = new OldMan ();
            room.Diameter = 100;
            room.Height = 100;
            return room;
        }
        /// Sets txt Files to Game Start
        public void ResetFiles () {
            GameTrack.SavePlayer ();
            GameTrack.SaveRoom ();
        }

        /// Sets the sceen for the campaign and uses player input to build character
        public void Tutorial () {
            Console.WriteLine ("Rumors led you on a journey through the snowy mountains of SkrimShaw,\ncrossing icy rivers and  crumbling cliffs to get to the long forgotten cavern of Nordem’s Tomb,\nAs you crest over the final peak and the mouth of the cave comes into view a weathered old man approaches you.\n'You there, Adventurer! Who approaches  the sacred tomb of Nordem the Necromancer?'");
            string name = Console.ReadLine ();
            Console.WriteLine ($"'Ah, {name}, I’ve heard tell of your coming. I hope you’ve come prepared,\nthe tomes are full of unspeakable horrors. What weapon have you brought with you?'");
            string weapon = Console.ReadLine ().ToLower ();
            GameTrack.Player.Name = name;
            GameTrack.Player.Weapon = new Equipment ().PickUpItem (weapon);
            if (GameTrack.Player.Weapon.Type == null) {
                Console.WriteLine ($"'Show me this {weapon}.\nI do not believe I have seen one like this before. I hope it serves you well'");
            } else {
                Console.WriteLine ($"'Oh ho, the mighty {weapon},\nthis should serve you well on your descent.'");
            }
            Console.WriteLine ("'Now go with haste, for the necromancer waits for no man.'");
        }

        /// Search through txt files for last Player and Room stats and begins game from last save
        public void LoadGame () {
            GameTrack.LoadPlayer ();
            GameTrack.LoadRoom ();
            GameTrack.LoadMap ();
        }

        /// listens for input from user, parses through string for keywords, then invokes the action for keyword
        public void ListenForObject () {
            if (QuitGame == true) {
                Console.WriteLine ("All progress has been saved. Come back soon.");
            } else {
                string[] lines = File.ReadAllLines ("ObjectList.txt");
                string input = Console.ReadLine ().ToLower ();
                int objectType = KeyWord (input, lines);
                switch (objectType) {
                    case 0:
                        ListenForAction (input);
                        break;
                    default:
                        GameTrack.ObjectAction (objectType, input);
                        break;
                }
                ListenForObject ();
            }
        }

        /// listens for input from user, parses through string for keywords, then invokes the action for keyword
        public void ListenForAction (string input) {
            string[] lines = File.ReadAllLines ("ActionList.txt");
            int actionType = KeyWord (input, lines);
            switch (actionType) {
                case 1:
                    QuitGame = true;
                    break;
                default:
                    GameTrack.Action (actionType - 1);
                    break;
            }
        }

        /// Searches through a list and returns the numerical value attached to the first keyword found
        public int KeyWord (string input, string[] lines) {
            int i = 1;
            foreach (string line in lines) {
                string[] words = line.Split (",");
                foreach (string word in words) {
                    if (input.Contains (word)) {
                        return i;
                    }
                }
                i++;
            }
            return 0;
        }
    }
}