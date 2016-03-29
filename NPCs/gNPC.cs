using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections;

namespace EnemyMods.NPCs
{
    public class gNPC : GlobalNPC
    { 
        int roll;
        int[] types = { 7, 10, 13, 39, 87, 95, 98, 117, 134, 402, 412, 454, 510, 513 };//worm-type heads to be specially included
        //int[] doomsayerTypes = {2, 3, 6, 7, 31, 32, 34, 42, 62,  };//types that can recieve the doomsayer suffix, not implemented
        public override void SetDefaults(NPC npc)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (npc.aiStyle != 7 && !(npc.catchItem > 0) && ((npc.aiStyle != 6 && npc.aiStyle !=37) ^ Array.Exists(types, element => element == npc.type)) && npc.type != 401 && npc.type != 488 && npc.lifeMax > 1)
            {
                #region ?????
                if (Main.rand.Next(0, 1000) == 0)//?????
                {
                    if (npc.displayName.Equals("Zombie"))
                    {
                        npc.displayName = "Actually-A-Penguin " + npc.displayName;
                        info.prefixes += "Actually-A-Penguin #";
                        npc.catchItem = 2205;
                    }
                    if (npc.displayName.Equals("Demon Eye"))
                    {
                        npc.displayName = "Actually-A-Bird " + npc.displayName;
                        info.prefixes += "Actually-A-Bird #";
                        npc.catchItem = 2015;
                    }
                }
                #endregion
                #region stat mods
                if (Main.rand.Next(0, 4) == 0)//25% to start stat mods block
                {
                    npc.value *= 2;
                    roll = Main.rand.Next(0, 81);
                    if (roll <= 10)//tough
                    {
                        npc.displayName = "Tough " + npc.displayName;
                        info.prefixes += "Tough #";
                        npc.lifeMax = (int)(1.5 * npc.lifeMax);
                    }
                    if (roll > 10 && roll <= 20)//dangerous
                    {
                        npc.displayName = "Dangerous " + npc.displayName;
                        info.prefixes += "Dangerous #";
                        npc.damage = (int)(1.4 * npc.damage);
                    }
                    if (roll > 20 && roll <= 30)//armored
                    {
                        npc.displayName = "Armored " + npc.displayName;
                        info.prefixes += "Armored #";
                        npc.defense = (int)(1.2 * npc.defense + 4);
                    }
                    if (roll > 30 && roll <= 40)//small
                    {
                        npc.displayName = "Small " + npc.displayName;
                        info.prefixes += "Small #";
                        npc.scale *= 0.7f;
                    }
                    if (roll > 40 && roll <= 50)//big
                    {
                        npc.displayName = "Big " + npc.displayName;
                        info.prefixes += "Big #";
                        npc.scale *= 1.4f;
                    }
                    if (roll > 50 && roll <= 60)//persistent
                    {
                        npc.displayName = "Persistent " + npc.displayName;
                        info.prefixes += "Persistent #";
                        npc.knockBackResist = npc.knockBackResist / 1.5f;
                    }
                    if (roll > 60 && roll <= 70)
                    {
                        npc.displayName = "Enduring " + npc.displayName;
                        info.prefixes += "Enduring #";
                        npc.takenDamageMultiplier *= .8f;
                    }
                    if (roll > 70 && roll <= 75)
                    {
                        npc.displayName = "Colossal " + npc.displayName;
                        info.prefixes += "Colossal #";
                        npc.scale *= 1.8f;
                        npc.damage = (int)(npc.damage*1.2);
                    }
                    if (roll > 75 && roll <= 80)
                    {
                        npc.displayName = "Miniature " + npc.displayName;
                        info.prefixes += "Miniature #";
                        npc.scale *= .45f;
                        npc.damage = (int)(npc.damage * .8);
                    }
                }
                #endregion
                #region debuff weaknesses
                if (Main.rand.Next(0, 5) == 0)//debuff weaknesses block
                {
                    roll = Main.rand.Next(0, 4);
                    if (roll == 0)
                    {
                        npc.displayName = "Flammable " + npc.displayName;
                        info.prefixes += "Flammable #";
                    }
                    if (roll == 1)
                    {
                        npc.displayName = "Cryophobic " + npc.displayName;
                        info.prefixes += "Cryophobic #";
                    }
                    if (roll == 2)
                    {
                        npc.displayName = "Toxiphobic " + npc.displayName;
                        info.prefixes += "Toxiphobic #";
                    }
                    if (roll == 3)
                    {
                        npc.displayName = "Pyophobic " + npc.displayName;
                        info.prefixes += "Pyophobic #";
                    }

                }
                #endregion
                #region special effects
                if (Main.rand.Next(0, 1) == 0)//special effects block
                {
                    npc.value *= 2;
                    roll = Main.rand.Next(0, 175);
                    if (roll <= 10)//burning
                    {
                        npc.displayName = "Burning " + npc.displayName;
                        info.prefixes += "Burning #";
                    }
                    if (roll <= 15 && roll > 10)//hellfire
                    {
                        npc.displayName = "Hellfire " + npc.displayName;
                        info.prefixes += "Hellfire #";
                    }
                    if (roll <= 22 && roll > 15)//frozen
                    {
                        npc.displayName = "Frozen " + npc.displayName;
                        info.prefixes += "Frozen #";
                        npc.coldDamage = true;
                    }
                    if (roll <= 28 && roll > 22 && Main.hardMode)//electrified
                    {
                        npc.displayName = "Electrified " + npc.displayName;
                        info.prefixes += "Electrified #";
                    }
                    if (roll <= 33 && roll > 28)//breaker
                    {
                        npc.displayName = "Breaker " + npc.displayName;
                        info.prefixes += "Breaker #";
                    }
                    if (roll <= 38 && roll > 33)//Dark
                    {
                        npc.displayName = "Dark " + npc.displayName;
                        info.prefixes += "Dark #";
                    }
                    if (roll <= 44 && roll > 38)//Confusing
                    {
                        npc.displayName = "Trickster " + npc.displayName;
                        info.prefixes += "Trickster #";
                    }
                    if (roll <= 50 && roll > 44)
                    {
                        npc.displayName = "Hexing " + npc.displayName;
                        info.prefixes += "Hexing #";
                    }
                    if (roll <= 55 && roll > 50)
                    {
                        npc.displayName = "Slowing " + npc.displayName;
                        info.prefixes += "Slowing #";
                    }
                    if (roll <= 60 && roll > 55)
                    {
                        npc.displayName = "Venomous " + npc.displayName;
                        info.prefixes += "Venomous #";
                    }
                    if (roll <= 65 && roll > 60)
                    {
                        npc.displayName = "Petrifying " + npc.displayName;
                        info.prefixes += "Petrifying #";
                    }
                    if (roll <= 75 && roll > 65)
                    {
                        npc.displayName = "Regenerating " + npc.displayName;
                        info.prefixes += "Regenerating #";
                    }
                    if (roll <= 82 && roll > 75)
                    {
                        npc.displayName = "Martyr " + npc.displayName;
                        info.prefixes += "Martyr #";
                    }
                    if (roll <= 90 && roll > 82)
                    {
                        npc.displayName = "Vampiric " + npc.displayName;
                        info.prefixes += "Vampiric #";
                    }
                    if (roll <= 97 && roll > 90)
                    {
                        npc.displayName = "Magebane " + npc.displayName;
                        info.prefixes += "Magebane #";
                    }
                    if (roll <= 107 && roll > 97)
                    {
                        npc.displayName = "Voodoo " + npc.displayName;
                        info.prefixes += "Voodoo #";
                    }
                    if (roll <= 115 && roll > 107)
                    {
                        npc.displayName = "Vengeful " + npc.displayName;
                        info.prefixes += "Vengeful #";
                    }
                    if (roll <= 122 && roll > 115)
                    {
                        npc.displayName = "Mutilator " + npc.displayName;
                        info.prefixes += "Mutilator #";
                    }
                    if (roll <= 129 && roll > 122)
                    {
                        npc.displayName = "Executioner " + npc.displayName;
                        info.prefixes += "Executioner #";
                    }
                    if (roll <= 139 && roll > 129)
                    {
                        npc.displayName = "Stealthy " + npc.displayName;
                        info.prefixes += "Stealthy #";
                    }
                    if (roll <= 146 && roll > 139 && npc.type != 13 && npc.type != 439 && npc.aiStyle != 94)
                    {
                        npc.displayName = "Splitter " + npc.displayName;
                        info.prefixes += "Splitter #";
                    }
                    if (roll <= 153 && roll > 146)
                    {
                        npc.displayName = "Forceful " + npc.displayName;
                        info.prefixes += "Forceful #";
                    }
                    if (roll <= 160 && roll > 153)
                    {
                        npc.displayName = "Launching " + npc.displayName;
                        info.prefixes += "Launching #";
                    }
                    if (roll <= 167 && roll > 160)
                    {
                        npc.displayName = "Halting " + npc.displayName;
                        info.prefixes += "Halting #";
                    }
                    if (roll <= 174 && roll > 167)
                    {
                        npc.displayName = "Wing Clipper " + npc.displayName;
                        info.prefixes += "Wing Clipper #";
                    }/*
                    if (roll <= 181 && roll > 174)
                    {
                        npc.displayName = "Magnetic " + npc.displayName;
                        info.prefixes += "Magnetic #";
                    }*/
                }
                #endregion
                #region projectiles
                if (Main.rand.Next(0, 12) == 0 && npc.type != NPCID.Creeper)//extra projectiles block
                {
                    npc.value *= 2;
                    roll = Main.rand.Next(0, 121);
                    if (roll <= 10)
                    {
                        npc.displayName = "Volcanic " + npc.displayName;
                        info.prefixes += "Volcanic #";
                    }
                    if (roll > 10 && roll <= 20)
                    {
                        npc.displayName = "Shadowmage " + npc.displayName;
                        info.prefixes += "Shadowmage #";
                    }
                    if (roll > 20 && roll <= 30 && Main.hardMode)
                    {
                        npc.displayName = "Lightning Rod " + npc.displayName;
                        info.prefixes += "Lightning Rod #";
                    }
                    if (roll > 30 && roll <= 40)
                    {
                        npc.displayName = "Rune Mage " + npc.displayName;
                        info.prefixes += "Rune Mage #";
                    }
                    if (roll > 40 && roll <= 50)
                    {
                        npc.displayName = "Party Animal " + npc.displayName;
                        info.prefixes += "Party Animal #";
                    }
                    if (roll > 50 && roll <= 60)
                    {
                        npc.displayName = "Flametrail " + npc.displayName;
                        info.prefixes += "Flametrail #";
                    }
                    if (roll > 60 && roll <= 70)
                    {
                        npc.displayName = "Bionic " + npc.displayName;
                        info.prefixes += "Bionic #";
                    }
                    if (roll > 70 && roll <= 80 && Main.hardMode)
                    {
                        npc.displayName = "Shadowflame " + npc.displayName;
                        info.prefixes += "Shadowflame #";
                    }
                    if (roll > 80 && roll <= 90 && Main.hardMode)
                    {
                        npc.displayName = "Dune Mage " + npc.displayName;
                        info.prefixes += "Dune Mage #";
                    }
                    if (roll > 90 && roll <= 100)
                    {
                        npc.displayName = "Bubbly " + npc.displayName;
                        info.prefixes += "Bubbly #";
                    }
                    if (roll > 100 && roll <= 110)
                    {
                        npc.displayName = "Hellwing " + npc.displayName;
                        info.prefixes += "Hellwing #";
                    }
                    if (roll > 110 && roll <= 120)
                    {
                        npc.displayName = "Sonorous " + npc.displayName;
                        info.prefixes += "Sonorous #";
                    }
                }
                #endregion
                #region post-Moonlord
                if (Main.rand.Next(0, 10) == 0 && NPC.downedMoonlord)//post-moonlord block
                {
                    npc.value *= 3;
                    roll = Main.rand.Next(0, 61);
                    if(roll <= 10)
                    {
                        npc.displayName = "Mirrored " + npc.displayName;
                        info.prefixes += "Mirrored #";
                    }
                    if(roll > 10 && roll <= 20)
                    {
                        npc.displayName = "Malefic " + npc.displayName;
                        info.prefixes += "Malefic #";
                    }
                    if (roll > 20 && roll <= 30)
                    {
                        npc.displayName = "Adaptive " + npc.displayName;
                        info.prefixes += "Adaptive #";
                    }
                    if (roll > 30 && roll <= 40)
                    {
                        npc.displayName = "Channeler " + npc.displayName;
                        info.prefixes += "Channeler #";
                    }
                    if (roll > 40 && roll <= 50)
                    {
                        npc.displayName = "Leeching " + npc.displayName;
                        info.prefixes += "Leeching #";
                    }
                    if (roll > 50 && roll <= 60)
                    {
                        npc.displayName = "Psychic " + npc.displayName;
                        info.prefixes += "Psychic #";
                    }
                }
                #endregion
                #region suffixes
                if (Main.rand.Next(0, 100) == 0 && NPC.downedBoss3 && !npc.boss)//suffixes block
                {
                    npc.value *= 10;
                    roll = Main.rand.Next(0, 7);
                    if (roll == 0)
                    {
                        npc.displayName = npc.displayName + " the Juggernaut";
                        info.suffixes += " the Juggernaut";
                        npc.defense *= 2;
                        npc.lifeMax *= 3;
                        npc.knockBackResist = 0;
                        npc.scale *= 1.3f;
                    }
                    if (roll == 1)
                    {
                        npc.displayName = npc.displayName + " the Reaper";
                        info.suffixes += " the Reaper";
                        npc.defense /= 2;
                        npc.lifeMax = (int)(npc.lifeMax * .666);
                    }
                    if(roll == 2)
                    {
                        npc.displayName = npc.displayName + " the Immortal";
                        info.suffixes += " the Immortal";
                        info.lives = 8;
                    }
                    if(roll == 3 && Main.hardMode)
                    {
                        npc.displayName = npc.displayName + " the Nullifier";
                        info.suffixes += " the Nullifier";
                        for (int i=0; i < npc.buffImmune.Length; i++)
                        {
                            npc.buffImmune[i] = true;
                        }
                    }
                    if(roll == 4)
                    {
                        npc.displayName = npc.displayName + " the Necromancer";
                        info.suffixes += " the Necromancer";
                    }
                    if(roll == 5 && !npc.dontTakeDamage)
                    {
                        npc.displayName = npc.displayName + " the Master Ninja";
                        info.suffixes += " the Master Ninja";
                        npc.damage = (int)(npc.damage*1.5);
                    }
                    if (roll == 6)
                    {
                        npc.displayName = npc.displayName + " the Lightning God";
                        info.suffixes += " the Lightning God";
                    }
                }
                #endregion
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Burning "))
            {
                target.AddBuff(BuffID.OnFire, 300);
            }
            if (info.prefixes.Contains("Hellfire "))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
            if (info.prefixes.Contains("Frozen "))
            {
                target.AddBuff(BuffID.Frostburn, 300);
                if(Main.rand.Next(1, 12) == 1)
                {
                    target.AddBuff(BuffID.Frozen, 120);
                }
            }
            if (info.prefixes.Contains("Electrified "))
            {
                target.AddBuff(BuffID.Electrified, 300);
            }
            if (info.prefixes.Contains("Breaker "))
            {
                target.AddBuff(BuffID.BrokenArmor, 600);
            }
            if (info.prefixes.Contains("Dark "))
            {
                target.AddBuff(BuffID.Darkness, 300);
            }
            if (info.prefixes.Contains("Trickster "))
            {
                target.AddBuff(BuffID.Confused, 120);
            }
            if (info.prefixes.Contains("Hexing "))
            {
                if (Main.rand.Next(0, 3) == 0)
                {
                    target.AddBuff(BuffID.Cursed, 180);
                }
            }
            if (info.prefixes.Contains("Slowing "))
            {
                target.AddBuff(BuffID.Slow, 300);
            }
            if (info.prefixes.Contains("Venomous "))
            {
                target.AddBuff(BuffID.Venom, 300);
            }
            if (info.prefixes.Contains("Petrifying "))
            {
                if (Main.rand.Next(0, 3) == 0 && target.HasBuff(BuffID.Stoned)==-1)//test
                {
                    target.AddBuff(BuffID.Stoned, 180);
                }
            }
            if (info.prefixes.Contains("Forceful "))
            {
                if (npc.Center.X <= target.Center.X)
                {
                    target.velocity.X += 15;
                }
                else target.velocity.X -= 15;
            }
            if (info.prefixes.Contains("Launching "))
            {
                target.velocity.Y -= 30;
            }
            if (info.prefixes.Contains("Halting "))
            {
                target.velocity = Vector2.Zero;
            }
            if (info.prefixes.Contains("Wing Clipper "))
            {
                target.wingTime = 0;
                target.rocketTime = 0;
                target.jumpAgainBlizzard = false;
                target.jumpAgainCloud = false;
                target.jumpAgainFart = false;
                target.jumpAgainSail = false;
                target.jumpAgainSandstorm = false;
                target.jumpAgainUnicorn = false;
            }
            if (info.prefixes.Contains("Vampiric "))
            {
                npc.life += damage;
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 50, npc.width, npc.height), new Color(20, 120, 20, 200), "" + damage);
                if (npc.life > npc.lifeMax)
                {
                    npc.life = npc.lifeMax;
                }
            }
            if (info.suffixes.Contains(" the Nullifier"))
            {
                for (int i = 0; i < target.buffType.Length; i++)
                {
                    target.DelBuff(i);
                }
            }
        }
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Magebane "))
            {
                damage += target.statMana / 4;
                target.statMana /= 2;
                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 50, target.width, target.height), new Color(20, 20, 120, 200), "" + target.statMana);
            }
            if (info.suffixes.Contains(" the Reaper"))
            {
                if(damage < target.statLife)
                {
                    damage = target.statLife - 1 + target.statDefense / 2;
                }
            }
            if (info.prefixes.Contains("Mutilator "))
            {
                if (target.statLife==target.statLifeMax2)
                {
                    damage *= 2;
                }
            }
            if (info.prefixes.Contains("Executioner "))
            {
                if (target.statLife <= target.statLifeMax2/5)
                {
                    damage *= 2;
                }
            }
            if (info.prefixes.Contains("Vengeful "))
            {
                damage += (int)((npc.life / (npc.life + npc.lifeMax)) * damage);
            }
        }
        public override bool CheckDead(NPC npc)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.lives > 0 && info.suffixes.Contains(" the Immortal"))
            {
                info.lives--;
                npc.damage = (int)(npc.damage * 1.1);
                npc.life = npc.lifeMax;
                Main.PlaySound(15, npc.position, 0);
                return false;
            }
            return true;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Regenerating ") && npc.HasBuff(BuffID.OnFire)==-1 && npc.HasBuff(BuffID.Poisoned)==-1 && npc.HasBuff(BuffID.Poisoned)==-1 && npc.HasBuff(BuffID.CursedInferno)==-1)
            {
                npc.lifeRegen += (int) Math.Sqrt(npc.lifeMax - npc.life)/2 + 1;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Martyr "))
            {
                int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("MartyrBomb"), npc.damage * 2, 10);
            }
            if (info.prefixes.Contains("Splitter "))
            {
                int x = 2 + Main.rand.Next(0, 3);
                for(int i=0; i < x; i++)
                {
                    int n = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, npc.type);
                    Main.npc[n].velocity.X = Main.rand.Next(-3, 4);
                    Main.npc[n].velocity.Y = Main.rand.Next(-3, 4);
                    Main.npc[n].life /= 2;
                    Main.npc[n].scale *= .85f;
                    Main.npc[n].lifeMax /= 2;
                    Main.npc[n].damage = (int)(Main.npc[n].damage * .8);
                }
            }
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Mirrored "))
            {
                npc.reflectingProjectiles = true;
                info.postMoonTimer = 60;
            }
            if (info.prefixes.Contains("Stealthy "))
            {
                npc.alpha -= 100;
                if(npc.alpha < 0)
                {
                    npc.alpha = 0;
                }
            }
            if (info.suffixes.Contains(" the Master Ninja"))
            {
                if (info.countSuffix == -1)
                {
                    npc.alpha = 250;
                    npc.dontTakeDamage = true;
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, 75, npc.damage, 0);
                    Main.projectile[p].Kill();
                }
                else
                {
                    npc.alpha = 0;
                    info.countSuffix++;
                }
            }
        }
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Stealthy "))
            {
                npc.alpha -= 100;
                if (npc.alpha < 0)
                {
                    npc.alpha = 0;
                }
            }
            if (info.suffixes.Contains(" the Master Ninja"))
            {
                if (info.countSuffix == -1)
                {
                    npc.alpha = 250;
                    npc.dontTakeDamage = true;
                    int p=Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, 75, (int)(npc.damage * .7), 0);
                    Main.projectile[p].Kill();                  
                }
                else
                {
                    npc.alpha = 0;
                    info.countSuffix++;
                }
            }
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Pyophobic "))
            {
                int buffindex = npc.HasBuff(69);
                if (buffindex != -1)
                    if (npc.buffTime[buffindex] > 0)
                    {
                        damage *= 1.3;
                    }
            }
            return true;
        }
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Adaptive "))
            {
                if (item.melee)
                {
                    if (info.meleeResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.meleeResist = true;
                    info.meleeResistTimer = 180;
                }                    
                if (item.ranged)
                {
                    if (info.rangedResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.rangedResist = true;
                    info.rangedResistTimer = 180;
                }
                if (item.magic)
                {
                    if (info.magicResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.magicResist = true;
                    info.magicResistTimer = 180;
                }
                if (item.summon)
                {
                    if (info.minionResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.minionResist = true;
                    info.minionResistTimer = 180;
                }

            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (info.prefixes.Contains("Adaptive "))
            {
                if (projectile.melee)
                {
                    if (info.meleeResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.meleeResist = true;
                    info.meleeResistTimer = 180;
                }
                if (projectile.ranged)
                {
                    if (info.rangedResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.rangedResist = true;
                    info.rangedResistTimer = 180;
                }
                if (projectile.magic)
                {
                    if (info.magicResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.magicResist = true;
                    info.magicResistTimer = 180;
                }
                if (projectile.minion)
                {
                    if (info.minionResist)
                    {
                        damage = (int)(damage * .3);
                    }
                    info.minionResist = true;
                    info.minionResistTimer = 180;
                }
            }
        }

        public override void AI(NPC npc)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            Player target = Main.player[npc.target];
            int distance = (int) Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
            if (info.prefixes.Contains("Volcanic ") && distance < 450)
            {
                if (Main.rand.Next(0, 10) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.EmberBolt);
                }
                info.timerAI = Math.Min(info.timerAI+1, 300);
                if(info.timerAI >= 300 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 6, 467, (int)(npc.damage * .7), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Shadowmage ") && distance < 450)
            {
                info.timerAI = Math.Min(info.timerAI + 1, 300);
                if (info.timerAI >= 300 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 6, 468, (int)(npc.damage * .7), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Psychic ") && distance < 600)
            {
                info.postMoonTimer = Math.Min(info.timerAI + 1, 100);
                if ((info.postMoonTimer >= 90 || Main.rand.Next(0, 100)==0) && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    target.velocity += new Vector2(Main.rand.Next(-25, 26) / 2, Main.rand.Next(-25, 26) / 2);
                    info.postMoonTimer = 0;
                }
            }
            /*
            if (info.prefixes.Contains("Magnetic ") && distance < 400)
            {
                info.timerAI++;
                if (distance > 8 && info.timerAI >=10)//target.velocity.Y != 0 || target.velocity.X != 0
                {
                    Vector2 disp = new Vector2(-target.position.X + npc.position.X, -target.position.Y + npc.position.Y);
                    disp.Normalize();
                    disp.X = (float)Math.Abs(disp.X*20 / Math.Sqrt(distance)) < .0001f ? 0 : (float)(disp.X / Math.Sqrt(distance));
                    disp.Y = (float)Math.Abs(disp.Y*20 / Math.Sqrt(distance)) < .0001f ? 0 : (float)(disp.Y / Math.Sqrt(distance));
                    target.velocity += disp;
                    info.timerAI = 0;
                }
            }
            */
            if (info.prefixes.Contains("Bionic ") && distance < 450)
            {
                info.timerAI = Math.Min(info.timerAI + 1, 240);
                if (info.timerAI >= 240 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 10, -(npc.position.Y - target.position.Y) / distance * 10, ProjectileID.DeathLaser, (int)(npc.damage * .7), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Shadowflame ") && distance < 450)
            {
                info.timerAI += 1;
                if (info.timerAI > 360)
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, 299, (int)(npc.damage * .7), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Dune Mage ") && distance < 300)
            {
                info.timerAI += 1;
                if (info.timerAI > 180)
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 1.5f, -(npc.position.Y - target.position.Y) / distance * 1.5f, 596, (int)(npc.damage*1.1), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Bubbly ") && distance < 250)
            {
                info.timerAI = Math.Min(info.timerAI + Main.rand.Next(1, 3), 90);
                if (info.timerAI >= 90 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    Vector2 vector82 = -target.Center + npc.Center;
                    vector82 = -vector82;
                    Vector2 vector83 = Vector2.Normalize(vector82) * 9f;
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, vector83.X, vector83.Y, 410, npc.damage - 5, 0);
                    Main.projectile[p].scale *= 1.4f;
                    Main.projectile[p].damage /= 2;
                    Main.projectile[p].hostile = true;
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].timeLeft = 90;
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Sonorous ") && distance < 450)
            {
                info.timerAI = Math.Min(info.timerAI + Main.rand.Next(1, 3), 150);
                if (info.timerAI >= 150 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    Vector2 vector82 = -target.Center + npc.Center;
                    vector82 = -vector82;
                    Vector2 vector83 = Vector2.Normalize(vector82) * 4f;
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, vector83.X, vector83.Y, Main.rand.Next(76, 79), (int)(npc.damage * .7), 0);
                    Main.projectile[p].damage /= 2;
                    Main.projectile[p].hostile = true;
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].timeLeft = 300;
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Hellwing ") && distance < 350)
            {
                info.timerAI = Math.Min(info.timerAI + 1, 90);
                if (info.timerAI >= 90 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    Vector2 vector82 = -target.Center + npc.Center;
                    vector82 = -vector82;
                    Vector2 vector83 = Vector2.Normalize(vector82) * 7f;
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, vector83.X, vector83.Y, 485, (int)(npc.damage*.7), 0, Main.myPlayer, vector82.ToRotation());
                    Main.projectile[p].hostile = true;
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].timeLeft = 90;
                    Main.projectile[p].ai[0] = Main.rand.Next(-6, 13)/2;
                    Main.projectile[p].ai[1] = Main.rand.Next(-6, 13)/2;
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Lightning Rod ") && distance < 450)
            {
                if (Main.rand.Next(0, 10) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric);
                }
                info.timerAI = Math.Min(info.timerAI + 1, 180);
                if (info.timerAI >= 180 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 12, -(npc.position.Y - target.position.Y) / distance * 12, 435, (int)(npc.damage *.8), 0);
                    info.timerAI = 0;
                }
            }
            if (info.suffixes.Contains(" the Lightning God") && distance < 800)
            {
                if (Main.rand.Next(0, 3) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric);
                }
                info.timerSuffix = Math.Min(info.timerSuffix + 1, 90);
                if (Main.rand.Next(0, 80) == 0)
                {
                    Vector2 vector82 = new Vector2(Main.rand.Next(-50,51), 800);
                    float ai = Main.rand.Next(100);
                    Vector2 vector83 = Vector2.Normalize(vector82.RotatedByRandom(0.78539818525314331)) * 8;
                    Projectile.NewProjectile(target.position.X + Main.rand.Next(-100,101), target.position.Y - 900, vector83.X, vector83.Y, 466, npc.damage, 0f, target.whoAmI, vector82.ToRotation(), ai);
                }
                if (info.timerSuffix >= 60 && Collision.CanHitLine(target.position, target.width, target.height, npc.position, npc.width, npc.height))
                {
                    Vector2 vector82 = target.position - npc.position;
                    float ai = Main.rand.Next(100);
                    Vector2 vector83 = Vector2.Normalize(vector82.RotatedByRandom(0.78539818525314331)) * 8;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector83.X, vector83.Y, 580, npc.damage, 0f, target.whoAmI, vector82.ToRotation(), ai);
                    info.timerSuffix = 0;
                }
            }
            if (info.prefixes.Contains("Rune Mage ") && distance < 450)
            {
                info.timerAI += 1;
                if (info.timerAI > 480)
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, 129, (int)(npc.damage * .8), 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Party Animal ") && distance < 400)
            {
                info.timerAI += 1;
                if (info.timerAI > 180)
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 8, -(npc.position.Y - target.position.Y) / distance * 8, 289, npc.damage, 0);
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Flametrail "))
            {
                info.timerAI += 1;
                if (info.timerAI > 15)
                {
                    int p = Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, 400+Main.rand.Next(0, 3), npc.damage/2, 0);
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                    info.timerAI = 0;
                }
            }
            if (info.prefixes.Contains("Voodoo "))
            {
                info.specialTimer++;
                if (info.specialTimer > 60)
                {
                    for (int i = 0; i < npc.buffType.Length; i++)
                    {
                        if (npc.buffTime[i] > 0 && npc.buffType[i] > 0)
                        {
                            target.AddBuff(npc.buffType[i], npc.buffTime[i]);
                        }
                    }
                    info.specialTimer = 0;
                }
            }
            if (info.prefixes.Contains("Adaptive "))
            {
                info.minionResistTimer--;
                if (info.minionResistTimer < 0)
                    info.minionResist = false;
                info.magicResistTimer--;
                if (info.magicResistTimer < 0)
                    info.magicResist = false;
                info.meleeResistTimer--;
                if (info.meleeResistTimer < 0)
                    info.meleeResist = false;
                info.rangedResistTimer--;
                if (info.rangedResistTimer < 0)
                    info.rangedResist = false;
            }
            if (info.prefixes.Contains("Malefic "))
            {
                info.postMoonTimer += 800/distance;
                if (info.postMoonTimer > 60)
                {
                    if(target.statLife > 1)
                    {
                        int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Shadowflame);
                        target.statLife -= 1;
                        CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 50, target.width, target.height), new Color(255, 65, 0, 255), "" + 1);

                    }
                    info.postMoonTimer = 0;
                }
            }
            if (info.prefixes.Contains("Channeler "))
            {
                info.postMoonTimer += 1000 / distance;
                if (info.postMoonTimer > 600)
                {
                    target.statMana = Math.Max(target.statMana-10, 0);
                    info.postMoonCount++;
                    CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 50, target.width, target.height), new Color(0, 30, 200, 255), "" + 10);
                    info.postMoonTimer = 0;
                }
                if (info.postMoonCount >= 5)
                {
                    info.postMoonCount = 0;
                    ArrayList toBuff = getNPCsInRange(npc, 400);
                    for(int i=0; i < toBuff.Count; i++)
                    {
                        NPC n = (NPC)toBuff[i];
                        n.damage = (int)(n.damage * 1.1);
                        n.defense = (int)(n.defense * 1.1);
                        n.knockBackResist = (float)(n.knockBackResist / 1.1);
                        n.lifeMax = (int)(n.lifeMax * 1.1);
                        n.life = Math.Min(n.life + 200, n.lifeMax);
                        CombatText.NewText(new Rectangle((int)n.position.X, (int)n.position.Y - 20, n.width, n.height), new Color(50, 255, 50, 255), "" + 200);
                        CombatText.NewText(new Rectangle((int)n.position.X, (int)n.position.Y - 50, n.width, n.height), new Color(255, 65, 0, 255), "Status Up!");
                    }
                }
            }
            if (info.prefixes.Contains("Leeching "))
            {
                info.postMoonTimer += 1;
                if (info.postMoonTimer >= 250)
                {
                    info.postMoonTimer = 0;
                    ArrayList toBuff = getNPCsInRange(npc, 300);
                    for (int i = 0; i < toBuff.Count; i++)
                    {
                        NPC n = (NPC)toBuff[i];
                        int damC = (int)(n.damage * .1);
                        n.damage = (int)(n.damage * .9);
                        int defC = (int)(n.defense * .1);
                        n.defense = (int)(n.defense * .9);
                        int lifeMaxC = (int)(n.lifeMax * .1);
                        n.lifeMax = (int)(n.lifeMax * .9);
                        int lifeC = (int)(n.life * .1);
                        n.life = (int)(n.life * .9);
                        n.life = Math.Max(1, n.life);
                        npc.lifeMax += lifeMaxC;
                        npc.life += lifeC;
                        npc.defense += Math.Max(defC, 1);
                        npc.damage += Math.Max(damC, 1);
                        CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 20, npc.width, npc.height), new Color(50, 255, 50, 255), "" + lifeC);
                        CombatText.NewText(new Rectangle((int)n.position.X, (int)n.position.Y - 20, n.width, n.height), new Color(255, 140, 0, 255), "" + lifeC);
                    }
                }
            }
            if (info.prefixes.Contains("Mirrored "))
            {
                if(Main.rand.Next(0, 10) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.SilverCoin);
                }
                if (npc.reflectingProjectiles)
                {
                    if (Main.rand.Next(0, 4) == 0)
                    {
                        int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.SilverCoin);
                    }
                    info.postMoonTimer--;
                    if (info.postMoonTimer <= 0)
                    {
                        npc.reflectingProjectiles = false;
                    }
                }
            }
            if (info.suffixes.Contains(" the Necromancer"))
            {
                info.timerSuffix += 1;
                if (info.timerSuffix > 480)
                {
                    if (NPC.downedPlantBoss)
                    {
                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 269 + Main.rand.Next(0, 17));//269-286
                    }
                    else if (Main.hardMode)
                    {
                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.ArmoredSkeleton + Main.rand.Next(0,1)*33);//77 or 110
                    }
                    else
                    {
                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.Skeleton);
                    }   
                    for(int i=0; i<10; i++)
                    {
                        int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Shadowflame);
                    }
                    Main.PlaySound(2, npc.position, 8);
                    info.timerSuffix = 0;
                }
            }
            if (info.prefixes.Contains("Flammable "))
            {
                npc.buffImmune[BuffID.OnFire] = false;
                npc.buffImmune[BuffID.CursedInferno] = false;
                int buffindex = npc.HasBuff(24);
                if(buffindex != -1)
                if (npc.buffTime[buffindex] > 0)
                {
                    info.debuffTimer++;
                    if(info.debuffTimer >= 15)
                    {
                        npc.life -= 4;
                        CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 30, npc.width, npc.height), new Color(255, 140, 0, 255), "" + 4);
                            if (npc.realLife != -1) { npc = Main.npc[npc.realLife]; }
                            if (npc.life <= 0)
                            {
                                npc.life = 1;
                                if (Main.netMode != 1)
                                {
                                    npc.StrikeNPC(9999, 0f, 0, false, false);
                                    if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, "", npc.whoAmI, 1f, 0f, 0f, 9999); }
                                }
                            }
                            info.debuffTimer = 0;
                    }
                }
                buffindex = npc.HasBuff(39);
                if (buffindex != -1)
                    if (npc.buffTime[buffindex] > 0)
                {
                    info.debuffTimer++;
                    if (info.debuffTimer >= 15)
                    {
                        npc.life -= 4;
                        CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 30, npc.width, npc.height), new Color(255, 140, 0, 255), "" + 4);
                            if (npc.realLife != -1) { npc = Main.npc[npc.realLife]; }
                            if (npc.life <= 0)
                            {
                                npc.life = 1;
                                if (Main.netMode != 1)
                                {
                                    npc.StrikeNPC(9999, 0f, 0, false, false);
                                    if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, "", npc.whoAmI, 1f, 0f, 0f, 9999); }
                                }
                            }
                            info.debuffTimer = 0;
                    }
                }
            }
            if (info.prefixes.Contains("Toxiphobic "))
            {
                npc.buffImmune[BuffID.Poisoned] = false;
                npc.buffImmune[BuffID.Venom] = false;
                int buffindex = npc.HasBuff(20);
                if(buffindex != -1)
                if (npc.buffTime[buffindex] > 0)
                {
                    info.debuffTimer++;
                    if (info.debuffTimer >= 15)
                    {
                        npc.life -= (int)(Math.Sqrt(npc.lifeMax - npc.life)/16) + 2;
                        CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 30, npc.width, npc.height), new Color(255, 140, 0, 255), "" + ((int)(Math.Sqrt(npc.lifeMax - npc.life) / 16)+2));
                            if (npc.realLife != -1) { npc = Main.npc[npc.realLife]; }
                            if (npc.life <= 0)
                            {
                                npc.life = 1;
                                if (Main.netMode != 1)
                                {
                                    npc.StrikeNPC(9999, 0f, 0, false, false);
                                    if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, "", npc.whoAmI, 1f, 0f, 0f, 9999); }
                                }
                            }
                            info.debuffTimer = 0;
                    }
                }
                buffindex = npc.HasBuff(70);
                if (buffindex != -1)
                    if (npc.buffTime[buffindex] > 0)
                    {
                    info.debuffTimer2++;
                    if (info.debuffTimer2 >= 15)
                    {
                        npc.life -= (int)(Math.Sqrt(npc.lifeMax - npc.life) / 8)+1;
                        CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 30, npc.width, npc.height), new Color(255, 140, 0, 255), "" + ((int)(Math.Sqrt(npc.lifeMax - npc.life) / 8)+1));
                            if (npc.realLife != -1) { npc = Main.npc[npc.realLife]; }
                            if (npc.life <= 0)
                            {
                                npc.life = 1;
                                if (Main.netMode != 1)
                                {
                                    npc.StrikeNPC(9999, 0f, 0, false, false);
                                    if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, "", npc.whoAmI, 1f, 0f, 0f, 9999); }
                                }
                            }
                            info.debuffTimer2 = 0;
                    }
                }
            }
            if (info.prefixes.Contains("Cryophobic "))
            {
                npc.buffImmune[BuffID.Frostburn] = false;
                int buffindex = npc.HasBuff(44);
                if (buffindex != -1)
                    if (npc.buffTime[buffindex] > 0)
                    {
                    info.debuffTimer++;
                    if (info.debuffTimer >= 30)
                    {
                        npc.defense--;
                        if(npc.defense <= 0)
                        {
                            npc.defense++;
                            npc.life -= 4;
                            CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 30, npc.width, npc.height), new Color(255, 140, 0, 255), "" + 4);
                                if (npc.realLife != -1) { npc = Main.npc[npc.realLife]; }
                                if (npc.life <= 0)
                                {
                                    npc.life = 1;
                                    if (Main.netMode != 1)
                                    {
                                        npc.StrikeNPC(9999, 0f, 0, false, false);
                                        if (Main.netMode == 2) { NetMessage.SendData(28, -1, -1, "", npc.whoAmI, 1f, 0f, 0f, 9999); }
                                    }
                                }
                            }
                        info.debuffTimer = 0;
                    }
                }
            }
            if (info.prefixes.Contains("Pyophobic "))
            {
                npc.buffImmune[BuffID.Ichor] = false;
            }
            if (info.prefixes.Contains("Stealthy "))
            {
                npc.alpha++;
                if(npc.alpha > 240)
                {
                    npc.alpha = 240;
                }
            }
            if (info.suffixes.Contains(" the Master Ninja"))
            {
                if (info.countSuffix > 0)
                {
                    info.timerSuffix += info.countSuffix;
                    if (info.timerSuffix >= 360)
                    {
                        info.countSuffix = -1;
                        info.timerSuffix = 120;
                    }
                }
                else if (info.countSuffix == -1)
                {
                    info.timerSuffix--;
                    if (info.timerSuffix <= 0)
                    {
                        info.countSuffix = 0;
                        npc.dontTakeDamage = false;
                    }
                }
                else
                {
                    npc.alpha += 10;
                    if (npc.alpha > 250)
                    {
                        npc.alpha = 250;
                    }
                }
            }
            if (info.suffixes.Contains(" the Reaper"))
            {
                if (Main.rand.Next(0, 6) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PortalBoltTrail);
                }
            }
                if (info.suffixes.Contains(" the Nullifier"))
            {
                if (Main.rand.Next(0, 6) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.CrystalPulse2);
                }
                if (distance < 250)
                {
                    info.timerSuffix++;
                    if (info.timerSuffix > 15)
                    {
                        target.AddBuff(BuffID.Cursed, 20);
                        info.timerSuffix = 0;
                    }
                }

            }
            base.AI(npc);
        }
        public override bool PreAI(NPC npc)
        {
            iNPC info = (iNPC)npc.GetModInfo(mod, "iNPC");
            if (!info.nameConfirmed)//block to ensure all enemies retain prefixes in their displayNames
            {
                if(info.prefixes.Length > 1)//has prefixes
                {
                    String[] prefixes = info.prefixes.Split('#');
                    for(int i=0; i < prefixes.Length; i++)
                    {
                        if (!npc.displayName.Contains(prefixes[i]))
                        {
                            npc.displayName = prefixes[i] + npc.displayName;
                        }
                    }
                }
                if(info.suffixes.Length > 1)//has suffixes
                {
                    if (!npc.displayName.Contains(info.suffixes))
                    {
                        npc.displayName += info.suffixes;
                    }
                }
                info.nameConfirmed = true;
            }
            return base.PreAI(npc);
        }
        //gets all NPCs that can have prefixes within given distance of given NPC
        private ArrayList getNPCsInRange(NPC focus, int distance)
        {
            ArrayList NPCsInRange = new ArrayList();
            for (int i = 0; i < 100; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.Distance(focus.position) < distance && npc.aiStyle != 7 && !(npc.catchItem > 0) && ((npc.aiStyle != 6 && npc.aiStyle != 37) ^ Array.Exists(types, element => element == npc.type)) && npc.type != 401 && npc.type != 488 && npc.life > 0 && npc!=focus)
                {
                    NPCsInRange.Add(npc);
                }
            }
            return NPCsInRange;
        }
    }
}
