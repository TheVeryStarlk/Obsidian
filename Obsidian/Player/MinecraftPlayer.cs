﻿// This would be saved in a file called [playeruuid].dat which holds a bunch of NBT data.
// https://wiki.vg/Map_Format
using Obsidian.Concurrency;
using System.Collections.Generic;

namespace Obsidian.Entities
{
    public class MinecraftPlayer
    {
        // ETC
        public string UUID { get; set; }

        // Properties set by Minecraft (official)
        public Location Location { get; set;}
        public bool OnGround { get; set; }
        public bool Sleeping { get; set; }
        public short Air { get; set; }
        public short AttackTime { get; set; }
        public short DeathTime { get; set; }
        public short Fire { get; set; }
        public short Health { get; set; }
        public short HurtTime { get; set; }
        public short SleepTimer { get; set; }
        public int Dimension { get; set; }
        public int FoodLevel { get; set; }
        public int FoodTickTimer { get; set; }
        public int PlayerGameType { get; set; }
        public int XpLevel { get; set; }
        public int XpTotal { get; set; }
        public float FallDistance { get; set; }
        public float FoodExhastionLevel { get; set; } // not a type, it's in docs like this
        public float FoodSaturationLevel { get; set; }
        public float XpP { get; set; } // idfk, xp points?

        /* Missing for now:
            NbtCompound(inventory)
            NbtList(Motion)
            NbtList(Pos)
            NbtList(Rotation)
        */

        // Properties set by Obsidian (unofficial)
        // Not sure whether these should be saved to the NBT file.
        // These could be saved under nbt tags prefixed with "obsidian_"
        // As minecraft might just ignore them.
        public ConcurrentHashSet<string> Permissions { get; }
        public string Username { get; }
        public World World;

        public MinecraftPlayer(string UUID, string Username)
        {
            this.UUID = UUID;
            this.Username = Username;
            this.Permissions = new ConcurrentHashSet<string>();
            this.Location = new Location();
        }

        public void LoadPerms(List<string> permissions)
        {
            foreach(var perm in permissions)
            {
                Permissions.Add(perm);
            }
        }
    }
}
