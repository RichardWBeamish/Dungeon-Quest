using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DungeonQuest {
    public class GameTrack {
        public Player Player;
        public Room Room;
        public List<Room> Map;

        public GameTrack () {
            Map = new List<Room> ();
        }
        public void ObjectAction (int obj, string action) {
            new Action (this).SelectActionForObject (obj, action);
        }
        public void Action (int action) {
            new Action (this).PerformGenericAction (action);
        }

        /// <summary>Converts Player file into an instance of Player</summary>
        public void LoadPlayer () {
            Player = JsonConvert.DeserializeObject<Player> (File.ReadAllText ("Player.json"));
        }

        /// <summary>Converts CurrentRoom file into an instance of Room</summary>
        public void LoadRoom () {
            Room = JsonConvert.DeserializeObject<Room> (File.ReadAllText ("CurrentRoom.json"));
        }

        /// <summary>Converts Map file into Instances of Rooms and adds them to the Map list</summary>
        public void LoadMap () {
            Map = JsonConvert.DeserializeObject<List<Room>> (File.ReadAllText ("Map.json"));
        }

        /// <summary>Saves Player to player file</summary>
        /// <param Player = "player">player to save to file</param>
        public void SavePlayer () {
            File.WriteAllText ("Player.Json", JsonConvert.SerializeObject (Player));
        }

        public void SaveRoom () {
            File.WriteAllText ("CurrentRoom.json", JsonConvert.SerializeObject (Room));
        }

        public void SaveMap () {
            UpdateMap (Room);
            File.WriteAllText ("Map.json", JsonConvert.SerializeObject (Map));
        }

        /// <summary>Updates the current room in map</summary>
        public void UpdateMap (Room currentRoom) {
            int i = 0;
            foreach (Room room in Map) {
                if (room.Number == currentRoom.Number) {
                    Map[i] = currentRoom;
                    break;
                }
                i++;
            }
        }

        /// <summary>Randomly generates room appends it to Map file</summary>
        public void AddRoomToMap () {
            Room room = new Room (Map.Count);
            Map.Add (room);
            File.WriteAllText ("Map.json", JsonConvert.SerializeObject (Map));
        }

        /// <summary>Changes Current Room to newxt room</summary>
        /// <param name = "roomNumber"> The Room Number in question.</param>
        public Room ChangeRooms (string door) {
            int roomNumber = Room.Number;
            switch (door) {
                case "enter":
                    roomNumber = Room.Enter;
                    break;
                case "exit":
                    roomNumber = Room.Exit;
                    break;
            }
            Room = Map[roomNumber];
            if (roomNumber == Map.Count - 1) {
                AddRoomToMap ();
            }
            SaveRoom ();
            return Room;
        }
    }
}