using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnemyMods
{
    public class GloabalMod : Mod
    {
        public override void SetModInfo(out string name, ref ModProperties properties)
        {
            name = "EnemyMods";
            properties.Autoload = true;
        }
    }
}
