using System;
using System.IO;

namespace DungeonQuest {
    public class FlavorText {
        public Player Player;
        public Room Room;
        public FlavorText (Player player, Room room) {
            this.Player = player;
            this.Room = room;
        }

        public void Enter (Room newRoom) {
            if (Room.Monster.HP < 1) {
                Room.Monster.Name = ($"dead {Room.Monster.Name}");
            }
            string text = ($"Stepping slowly through the doorway, you see a { newRoom.Monster.Name }.");
            Console.WriteLine (text);
        }

        public void PlayerAttack (int damage) {
            string text = ($"Gripping your { Player.Weapon.Name } tightly, you leap towards the { Room.Monster.Name } slashing deep into its chest dealing { damage } damgae.");
            Console.WriteLine (text);
            if (Room.Monster.HP < 1) {
                Console.WriteLine ($"The { Room.Monster.Name }'s lifeless body falls limp to the ground.");
            } else {
                Console.WriteLine ($"The {Room.Monster.Name} has {Room.Monster.HP} HP remaining.");
            }
        }
    }
}