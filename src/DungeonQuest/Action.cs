using System;
using System.IO;

namespace DungeonQuest {
    public class Action {
        public Random rand = new Random ();
        public Player Player;
        public Room Room;
        public GameTrack GameTrack;
        public FlavorText FlavorText;
        public Action (GameTrack gameTrack) {
            this.GameTrack = gameTrack;
            this.Room = GameTrack.Room;
            this.Player = GameTrack.Player;
            this.FlavorText = new FlavorText (Player, Room);
        }

        public void SelectActionForObject (int objType, string input) {
            switch (objType) {
                case 1:
                    Console.WriteLine ("The Room Object does not exist... yet");
                    break;
                case 2:
                    Console.WriteLine ("The Monster Object does not exist... yet");
                    break;
                case 3:
                    Console.WriteLine ("The Pack Object does not exist... yet");
                    break;
                case 4:
                    Console.WriteLine ("The Inventory Object does not exist... yet");
                    break;
                case 5:
                    Console.WriteLine ("The Reward Object does not exist... yet");
                    break;
                case 6:
                    Console.WriteLine ("The Puzzle Object does not exist... yet");
                    break;
            }
        }

        public void PerformGenericAction (int wordType) {
            switch (wordType) {
                case 1:
                    Console.WriteLine ("The Statistics action does not exist... yet.");
                    break;
                case 2:
                    Console.WriteLine ("The Inspect action does not exist... yet.");
                    break;
                case 3:
                    Console.WriteLine ("The Search action does not exist... yet.");
                    break;
                case 4:
                    GameTrack.SaveMap ();
                    Room roomEnter = GameTrack.ChangeRooms ("enter");
                    FlavorText.Enter (roomEnter);
                    break;
                case 5:
                    GameTrack.SaveMap ();
                    Room roomExit = GameTrack.ChangeRooms ("exit");
                    FlavorText.Enter (roomExit);
                    break;
                case 6:
                    int damage = Player.Attack (Room.Monster);
                    FlavorText.PlayerAttack (damage);
                    GameTrack.SaveRoom ();
                    break;
                case 7:
                    Console.WriteLine ("The Retreat action does not exist... yet.");
                    break;
                case 8:
                    Console.WriteLine ("The Jump action does not exist... yet.");
                    break;
                case 9:
                    Console.WriteLine ("The Climb action does not exist... yet.");
                    break;
                case 10:
                    Console.WriteLine ("The Sneak action does not exist... yet.");
                    break;
                case 11:
                    Console.WriteLine ("The Hide action does not exist... yet.");
                    break;
                case 12:
                    Console.WriteLine ("The Eat/Drink action does not exist... yet.");
                    break;
                case 13:
                    Console.WriteLine ("The Throw action does not exist... yet.");
                    break;
                case 14:
                    Console.WriteLine ("The Aproach action does not exist... yet.");
                    break;
                case 15:
                    Console.WriteLine ("The Speak action does not exist... yet.");
                    break;
                case 16:
                    Console.WriteLine ("The Read action does not exist... yet.");
                    break;
                case 17:
                    Console.WriteLine ("The Write action does not exist... yet.");
                    break;
                default:
                    Console.WriteLine ("command not understood. try again...");
                    break;
            }
        }
    }
}