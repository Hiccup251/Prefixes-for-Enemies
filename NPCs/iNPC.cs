using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnemyMods.NPCs
{
    public class iNPC : NPCInfo
    {
        public int specialTimer = 0;
        public int timerAI = 0;
        public int timerSuffix = 0;
        public int countSuffix = 0;
        public int lives;
        public int debuffTimer = 0;
        public int debuffTimer2 = 0;
        public string prefixes = "";
        public string suffixes = "";
        public bool rangedResist, meleeResist, magicResist, minionResist;
        public int rangedResistTimer, meleeResistTimer, magicResistTimer, minionResistTimer = 0;
        public int postMoonTimer = 0;
        public int postMoonCount = 0;
        public bool nameConfirmed = false;
    }
}