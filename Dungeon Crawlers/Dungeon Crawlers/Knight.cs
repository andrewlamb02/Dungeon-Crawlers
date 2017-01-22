using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dungeon_Crawlers
{
    public class Knight
    {
        //what the knight looks like
        public Texture2D knightTexture;
        //knights strength
        public int strength;
        //knights agility
        public int agility;
        //knights intellect
        public int intellect;
        //knights stamina
        public int stamina;
        //knights health
        public int health;
        //knights mana
        public int mana;
        //the area the knight takes up
        public Rectangle knightRectangle;
        public Vector2 position;
        public bool knightAttackTimeCounter;
        public int knightAttackTime;
        public Color knightColor;
        public bool hurt;
        public int hurtCounter;
        public bool immunity;
        public int immunityCounter;
        public bool superSpeed;
        public int superSpeedCounter;
        public int immunityColorCounter;
        public bool superAttack;
        public int superAttackCounter;
        public int superAttackColorCounter;
        public int superSpeedColorCounter;
        public bool alive;
        public bool isGold;
        Game1 manager;
        public Knight(Game1 man, int str, int agi, int inte, int sta, Rectangle knightRec, Texture2D knightTex, Vector2 place, Color knightCo, bool iG)
        {
            manager = man;
            strength = str;
            agility = agi;
            intellect = inte;
            stamina = sta;
            health = 100 + stamina;
            mana = 50 + intellect;
            knightRectangle = knightRec;
            knightTexture = knightTex;
            position = place;
            knightColor = knightCo;
            knightAttackTimeCounter = false;
            hurt = false;
            immunity = false;
            immunityCounter = 0;
            immunityColorCounter = 0;
            superSpeed = false;
            superSpeedColorCounter = 0;
            superSpeedCounter = 0;
            alive = false;
            superAttack = false;
            superAttackCounter = 0;
            superAttackColorCounter = 0;
            knightAttackTime = 0;
            knightAttackTimeCounter = false;
            isGold = iG;
        }
        public void Move(string direction)
        {
            if (direction == "Up" && superSpeed == false)
            {
                knightRectangle.Y -= 2 + (agility / 10);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTexture;
                }
                else
                {
                    knightTexture = manager.knightTexture;
                }
            }
            if (direction == "Down" && superSpeed == false)
            {
                knightRectangle.Y += 2 + (agility / 10);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureDown;
                }
                else
                {
                    knightTexture = manager.knightTextureDown;
                }
            }
            if (direction == "Left" && superSpeed == false)
            {
                knightRectangle.X -= 2 + (agility / 10);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureLeft;
                }
                else
                {
                    knightTexture = manager.knightTextureLeft;
                }
            }
            if (direction == "Right" && superSpeed == false)
            {
                knightRectangle.X += 2 + (agility / 10);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureRight;
                }
                else
                {
                    knightTexture = manager.knightTextureRight;
                }
            }
            if (direction == "Up" && superSpeed == true)
            {
                knightRectangle.Y -= 4 + (agility / 5);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTexture;
                }
                else
                {
                    knightTexture = manager.knightTexture;
                }
            }
            if (direction == "Down" && superSpeed == true)
            {
                knightRectangle.Y += 4 + (agility / 5);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureDown;
                }
                else
                {
                    knightTexture = manager.knightTextureDown;
                }
            }
            if (direction == "Left" && superSpeed == true)
            {
                knightRectangle.X -= 4 + (agility / 5);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureLeft;
                }
                else
                {
                    knightTexture = manager.knightTextureLeft;
                }
            }
            if (direction == "Right" && superSpeed == true)
            {
                knightRectangle.X += 4 + (agility / 5);
                if (isGold == true)
                {
                    knightTexture = manager.goldKnightTextureRight;
                }
                else
                {
                    knightTexture = manager.knightTextureRight;
                }
            }
        }
        public void Update()
        {
            Vector2 _temprec = new Vector2(296, 0);
            if (knightRectangle.Y > 234)
            {
                knightRectangle.Y = 234;
            }
            if (knightRectangle.Y < 0)
            {
                knightRectangle.Y = 0;
            }
            if (knightRectangle.X > 738)
            {
                knightRectangle.X = 738;
            }
            if (knightRectangle.X < 0)
            {
                knightRectangle.X = 0;
            }
            if (health <= 0)
            {
                health = 0;
                alive = false;
            }
            if (mana < 0)
            {
                mana = 0;
            }
            if (knightAttackTimeCounter == true)
            {
                knightAttackTime += 1;
            }
            if (knightAttackTime >= 40)
            {
                knightAttackTime = 0;
                knightAttackTimeCounter = false;
            }
            for (int i = 0; i < manager.meatList.Count; i++)
            {
                if (knightRectangle.Intersects(manager.meatList[i].meatRectangle))
                {
                    health = health += 25;
                }
            }
            for (int i = 0; i < manager.manaPotionList.Count; i++)
            {
                if (knightRectangle.Intersects(manager.manaPotionList[i].manaPotionRectangle))
                {
                    mana = mana + 15;
                }
            }
            for (int i = 0; i < manager.immunityPowerupList.Count; i++)
            {
                if (knightRectangle.Intersects(manager.immunityPowerupList[i].immunityPowerupRectangle))
                {
                    immunity = true;
                }
            }
            for (int i = 0; i < manager.speedPowerupList.Count; i++)
            {
                if (knightRectangle.Intersects(manager.speedPowerupList[i].speedPowerupRectangle))
                {
                    superSpeed = true;
                }
            }
            for (int i = 0; i < manager.attackPowerupList.Count; i++)
            {
                if (knightRectangle.Intersects(manager.attackPowerupList[i].attackPowerupRectangle))
                {
                    superAttack = true;
                }
            }
            if (health > 100 + stamina)
            {
                health = 100 + stamina;
            }
            if (mana > 50 + intellect)
            {
                mana = 50 + intellect;
            }
            if (superSpeed == true)
            {
                superSpeedColorCounter += 1;
            }
            if (superSpeedCounter == 8)
            {
                superSpeed = false;
                superSpeedCounter = 0;
            }
            if (superAttack == true)
            {
                superAttackColorCounter += 1;
            }
            if (superAttackCounter == 8)
            {
                superAttack = false;
                superAttackCounter = 0;
            }
            if (immunity == true)
            {
                immunityColorCounter += 1;
            }
            if (immunityCounter == 8)
            {
                immunity = false;
                immunityCounter = 0;
            }
            else if (immunityColorCounter == 25)
            {
                knightColor = Color.White;
                immunityColorCounter = 0;
                immunityCounter += 1;
            }
            else if (superSpeedColorCounter == 25)
            {
                knightColor = Color.White;
                superSpeedColorCounter = 0;
                superSpeedCounter += 1;
            }
            else if (superAttackColorCounter == 25)
            {
                knightColor = Color.White;
                superAttackColorCounter = 0;
                superAttackCounter += 1;
            }
            else if (immunityColorCounter >= 12 && immunityColorCounter < 25)
            {
                knightColor = Color.Purple;
            }
            else if (superSpeedColorCounter >= 12 && superSpeedColorCounter < 25)
            {
                knightColor = Color.LawnGreen;
            }
            else if (superAttackColorCounter >= 12 && superAttackColorCounter < 25)
            {
                knightColor = Color.DarkOrange;
            }
            else if (hurt == true)
            {
                hurtCounter += 1;
                knightColor = Color.Red;
                if (health > 0)
                {
                    manager.hurt.Play();
                }
            }
            else
            {
                knightColor = Color.White;
            }
            if (hurtCounter == 12)
            {
                hurtCounter = 0;
                hurt = false;
            }
            position.Y = knightRectangle.Y;
            position.X = knightRectangle.X;
        }
        public void Attack()
        {
            if (manager.ballistaList.Count > 0 && manager.goblinList.Count > 0 && manager.ogreList.Count > 0)
            {
                if (Vector2.Distance(position, ClosestBallista().position) > Vector2.Distance(position, ClosestGoblin().position) && Vector2.Distance(position, ClosestOgre().position) > Vector2.Distance(position, ClosestGoblin().position))
                {
                    GoblinTakesHit();
                }
                if (Vector2.Distance(position, ClosestBallista().position) < Vector2.Distance(position, ClosestGoblin().position) && Vector2.Distance(position, ClosestBallista().position) < Vector2.Distance(position, ClosestOgre().position))
                {
                    //ballista Code
                    BallistaTakesHit();
                }
                if (Vector2.Distance(position, ClosestOgre().position) < Vector2.Distance(position, ClosestGoblin().position) && Vector2.Distance(position, ClosestOgre().position) < Vector2.Distance(position, ClosestBallista().position))
                {
                    OgreTakesHit();
                }
            }
            if (manager.ballistaList.Count > 0 && manager.goblinList.Count > 0 && manager.ogreList.Count == 0)
            {
                if (Vector2.Distance(position, ClosestBallista().position) < Vector2.Distance(position, ClosestGoblin().position))
                {
                    BallistaTakesHit();
                }
                if (Vector2.Distance(position, ClosestBallista().position) > Vector2.Distance(position, ClosestGoblin().position))
                {
                    GoblinTakesHit();
                }
            }
            if (manager.ballistaList.Count > 0 && manager.goblinList.Count == 0 && manager.ogreList.Count > 0)
            {
                if (Vector2.Distance(position, ClosestOgre().position) < Vector2.Distance(position, ClosestBallista().position))
                {
                    OgreTakesHit();
                }
                if (Vector2.Distance(position, ClosestOgre().position) > Vector2.Distance(position, ClosestBallista().position))
                {
                    BallistaTakesHit();
                }
            }
            if (manager.ballistaList.Count == 0 && manager.goblinList.Count > 0 && manager.ogreList.Count > 0)
            {
                if (Vector2.Distance(position, ClosestOgre().position) < Vector2.Distance(position, ClosestGoblin().position))
                {
                    OgreTakesHit();
                }
                if (Vector2.Distance(position, ClosestOgre().position) > Vector2.Distance(position, ClosestGoblin().position))
                {
                    GoblinTakesHit();
                }
            }
            if (manager.ballistaList.Count > 0 && manager.goblinList.Count == 0)
            {
                BallistaTakesHit();
            }
            if (manager.ballistaList.Count == 0 && manager.goblinList.Count > 0)
            {
                GoblinTakesHit();
            }
            if (manager.ballistaList.Count == 0 && manager.goblinList.Count == 0 && manager.ogreList.Count > 0)
            {
                OgreTakesHit();
            }
        }
        public void GoblinTakesHit()
        {
            Goblin enemy = ClosestGoblin();
            if (knightAttackTimeCounter == false && Vector2.Distance(position, enemy.position) < 75)
            {
                if (superAttack == false)
                {
                    enemy.health = (enemy.health - 10 - strength / 10);
                }
                if (superAttack == true)
                {
                    enemy.health = (enemy.health - 20 - strength / 5);
                }
                enemy.hurt = true;
                manager.sword.Play();
                knightAttackTimeCounter = true;
            }
        }
        public void BallistaTakesHit()
        {
            Ballista enemy = ClosestBallista();
            if (knightAttackTimeCounter == false && Vector2.Distance(position, enemy.position) < 75)
            {
                if (superAttack == false)
                {
                    enemy.health = (enemy.health - 10 - strength / 10);
                }
                if (superAttack == true)
                {
                    enemy.health = (enemy.health - 20 - strength / 5);
                }
                enemy.hurt = true;
                manager.sword.Play();
                knightAttackTimeCounter = true;
            }
        }
        public void OgreTakesHit()
        {
            Ogre enemy = ClosestOgre();
            if (knightAttackTimeCounter == false && Vector2.Distance(position, enemy.position) < 125)
            {
                if (superAttack == false)
                {
                    enemy.health = (enemy.health - 10 - strength / 10);
                }
                if (superAttack == true)
                {
                    enemy.health = (enemy.health - 20 - strength / 5);
                }
                enemy.hurt = true;
                manager.sword.Play();
                knightAttackTimeCounter = true;
            }
        }
        public void ShieldBash()
        {
            for (int i = 0; i < manager.goblinList.Count; i++)
            {
                if (mana >= 10 && Vector2.Distance(position, manager.goblinList[i].position) < 75)
                {
                    {
                        if (knightAttackTimeCounter == false && position.Y - manager.goblinList[i].position.Y < 75)
                        {
                            // make nockback in all directions
                            manager.goblinList[i].health = manager.goblinList[i].health - (10 + intellect / 5);
                            manager.goblinList[i].goblinRectangle.Y = manager.goblinList[i].goblinRectangle.Y + 200;
                            manager.shield.Play();
                            mana = mana -= 10;
                        }
                        if (knightAttackTimeCounter == false && position.Y - manager.goblinList[i].position.Y > -75)
                        {
                            // make nockback in all directions
                            manager.goblinList[i].health = manager.goblinList[i].health - (10 + intellect / 5);
                            manager.goblinList[i].goblinRectangle.Y = manager.goblinList[i].goblinRectangle.Y - 200;
                            manager.shield.Play();
                            mana = mana -= 10;
                        }
                        if (knightAttackTimeCounter == false && position.X - manager.goblinList[i].position.X < 75)
                        {
                            // make nockback in all directions
                            manager.goblinList[i].health = manager.goblinList[i].health - (10 + intellect / 5);
                            manager.goblinList[i].goblinRectangle.X = manager.goblinList[i].goblinRectangle.X + 200;
                            manager.shield.Play();
                            mana = mana -= 10;
                        }
                        if (knightAttackTimeCounter == false && position.X - manager.goblinList[i].position.X > -75)
                        {
                            // make nockback in all directions
                            manager.goblinList[i].health = manager.goblinList[i].health - (10 + intellect / 5);
                            manager.goblinList[i].goblinRectangle.X = manager.goblinList[i].goblinRectangle.X - 200;
                            manager.shield.Play();
                            mana = mana -= 10;
                        }
                    }
                }
                knightAttackTimeCounter = true;
            }
        }
        public Goblin ClosestGoblin()
        {
            float closestD;
            closestD = 800;
            int closestG;
            closestG = 0;
            for (int i = 0; i < manager.goblinList.Count; i++)
            {
                if (Vector2.Distance(position, manager.goblinList[i].position) < closestD)
                {
                    closestD = Vector2.Distance(position, manager.goblinList[i].position);
                    closestG = i;
                }
            }
            return manager.goblinList[closestG];
        }
        public Ballista ClosestBallista()
        {
            float closestD;
            closestD = 800;
            int closestB;
            closestB = 0;
            for (int i = 0; i < manager.ballistaList.Count; i++)
            {
                if (Vector2.Distance(position, manager.ballistaList[i].position) < closestD)
                {
                    closestD = Vector2.Distance(position, manager.ballistaList[i].position);
                    closestB = i;
                }
            }
            return manager.ballistaList[closestB];
        }
        public Ogre ClosestOgre()
        {
            float closestD;
            closestD = 800;
            int closestO;
            closestO = 0;
            for (int i = 0; i < manager.ogreList.Count; i++)
            {
                if (Vector2.Distance(position, manager.ogreList[i].position) < closestD)
                {
                    closestD = Vector2.Distance(position, manager.ogreList[i].position);
                    closestO = i;
                }
            }
            return manager.ogreList[closestO];
        }
    }
    }

