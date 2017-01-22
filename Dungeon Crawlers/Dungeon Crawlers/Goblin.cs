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
    public class Goblin
    {
        //what the goblin looks like
        public Texture2D goblinTexture;
        //the area the goblin takes up
        public Rectangle goblinRectangle;
        public int health;
        public Vector2 Velocity;
        public bool goblinMove;
        public Vector2 position;
        public int goblinAttackTime;
        public bool goblinAttackCounter;
        public bool collidingG;
        public bool isLight;
        public int hurtCounter;
        public bool hurt;
        public Color goblinColor;
        Game1 manager;
        public Goblin(Game1 man, int hea, Rectangle goblinRec, Vector2 place, bool iL)
        {
            manager = man;
            health = hea;
            goblinRectangle = goblinRec;
            position = place;
            goblinMove = true;
            collidingG = false;
            isLight = iL;
            goblinColor = Color.White;
        }

            
        public void Update()
        {
            if (manager.knightList.Count > 0)
            {
                Knight enemy = ClosestKnight();
                if (goblinMove == true)
                {
                    if (enemy.knightRectangle.Y < goblinRectangle.Y)
                    {
                        goblinRectangle.Y -= 2;
                        if (isLight == true)
                        {
                            goblinTexture = manager.lightGoblinTexture;
                        }
                        else
                        {
                            goblinTexture = manager.darkGoblinTexture;
                        }
                    }
                    if (enemy.knightRectangle.Y > goblinRectangle.Y)
                    {
                        goblinRectangle.Y += 2;
                        if (isLight == true)
                        {
                            goblinTexture = manager.lightGoblinTextureDown;
                        }
                        else
                        {
                            goblinTexture = manager.darkGoblinTextureDown;
                        }
                    }
                    if (enemy.knightRectangle.X > goblinRectangle.X)
                    {
                        goblinRectangle.X += 2;
                        if (isLight == true)
                        {
                            goblinTexture = manager.lightGoblinTextureRight;
                        }
                        else
                        {
                            goblinTexture = manager.darkGoblinTextureRight;
                        }
                    }
                    if (enemy.knightRectangle.X < goblinRectangle.X)
                    {
                        goblinRectangle.X -= 2;
                        if (isLight == true)
                        {
                            goblinTexture = manager.lightGoblinTextureLeft;
                        }
                        else
                        {
                            goblinTexture = manager.darkGoblinTextureLeft;
                        }
                    }
                }
            }
            Vector2 _temprec = new Vector2(296, 0);
            if (goblinRectangle.Y > 234)
            {
                goblinRectangle.Y = 234;
            }
            if (goblinRectangle.Y < 0)
            {
                goblinRectangle.Y = 0;
            }
            if (goblinRectangle.X > 738)
            {
                goblinRectangle.X = 738;
            }
            if (goblinRectangle.X < 0)
            {
                goblinRectangle.X = 0;
            }
            if (health < 0)
            {
                health = 0;
            }
            if (goblinAttackCounter == true)
            {
                goblinAttackTime += 1;
            }
            if (hurt == true)
            {
                hurtCounter += 1;
                goblinColor = Color.Red;
            }
            else
            {
                goblinColor = Color.White;
            }
            if (hurtCounter == 12)
            {
                hurtCounter = 0;
                hurt = false;
            }

                    position.Y = goblinRectangle.Y;
                    position.X = goblinRectangle.X;
                
        }
            public void Stop ()
            {
                if (manager.knightList.Count > 0)
                {
                    Knight enemy = ClosestKnight();
                    if (goblinRectangle.Intersects(enemy.knightRectangle) && enemy.alive == true)
                    {
                        goblinAttackCounter = true;
                        goblinMove = false;
                    }
                    else if (collidingG == false)
                    {
                        goblinMove = true;
                        goblinAttackCounter = false;
                        goblinAttackTime = 0;
                    }
                }
            }
            public void Attack()
            {
                if (manager.knightList.Count > 0)
                {
                    Knight enemy = ClosestKnight();
                    if (goblinAttackTime == 25 && enemy.immunity == false)
                    {
                        if (isLight == true)
                        {
                            enemy.health = enemy.health - 10;
                        }
                        else
                        {
                            enemy.health = enemy.health - 20;
                        }
                        goblinAttackTime = -10;
                        enemy.hurt = true;
                    }
                }
            }
            public Knight ClosestKnight()
            {
                    float closestD;
                    closestD = 800;
                    int closestK;
                    closestK = 0;
                    for (int i = 0; i < manager.knightList.Count; i++)
                    {
                        if (Vector2.Distance(position, manager.knightList[i].position) < closestD /*&& manager.knightList[i].alive == true*/)
                        {
                            closestD = Vector2.Distance(position, manager.knightList[i].position);
                            closestK = i;
                        }
                    }
                        return manager.knightList[closestK];
            }
    }
}
