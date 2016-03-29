using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace EnemyMods.Projectiles
{
    public class MartyrBomb : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.HappyBomb);
            projectile.timeLeft = 120;
            projectile.hostile = false;
        }
        public override void Kill(int timeLeft)
        {
            int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.Landmine, projectile.damage, 0);
        }
    }
}
