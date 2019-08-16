using System;
using System.IO;
using Newtonsoft.Json;

namespace DungeonQuest {
    class Program {
        static void Main (string[] args) {
            GameLoop gameLoop = new GameLoop ();

            /// if RestartGame = true: start new game; else, load saved game
            switch (gameLoop.StartGame ()) {
                case true:
                    gameLoop.NewGame ();
                    break;
                default:
                    gameLoop.LoadGame ();
                    break;
            }

            /// Starts Game Loop
            gameLoop.ListenForObject ();
        }
    }
}