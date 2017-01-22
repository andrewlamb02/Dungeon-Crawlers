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
    public class Ogre
    {
        public Rectangle ogreRectangle;
        public Vector2 position;
        public Texture2D ogreTexture;
        public Color ogreColor;
        public int stage;
        public int stageTimer;
        public int chargeCounter;
        public bool isOnLeft;
        public bool charge;
        public bool frozen;
        public int toss;
        public int health;
        public int hurtCounter;
        public bool hurt;
        Game1 manager;
        public Ogre(Rectangle ogreRec, Game1 man, int hea, Vector2 place)
        {
            ogreRectangle = ogreRec;
            manager = man;
            health = hea;
            position = place;
            stage = 0;
            stageTimer = 0;
            frozen = false;
            charge = false;
            isOnLeft = false;
            hurt = false;
            hurtCounter = 0;
            ogreColor = Color.White;
        }
        public void Update()
        {
            if (manager.knightList.Count > 0)
            {
                Knight enemy = ClosestKnight();
                if (enemy.knightRectangle.Y - 32 > ogreRectangle.Y && charge == false && frozen == false)
                {
                    ogreRectangle.Y += 4;
                }
                if (enemy.knightRectangle.Y - 32 < ogreRectangle.Y&& charge == false && frozen == false)
                {
                    ogreRectangle.Y -= 4;
                }
            }
            if (stage == 1 || stage == 2 || stage == 3 || stage == 4)
            {
                stageTimer += 1;
            }
            if (stage == 1)
            {
                toss += 1;
            }
            if (toss == 75)
            {
                toss = 0;
            }
            if (stageTimer == 600 && stage == 1)
            {
                stage = 2;
                stageTimer = 0;
            }
            else if (hurt == true)
            {
                ogreColor = Color.Red;
            }
            else if (stage == 2)
            {
                ogreColor = Color.Orange;
            }
            else
            {
                ogreColor = Color.White;
            }
            if (stageTimer == 50)
            {
                stage = 3;
            }
            if (stage == 3 && isOnLeft == true)
            {
                ogreRectangle.X += 5;
            }
            if (stage == 3 && isOnLeft == false)
            {
                ogreRectangle.X -= 5;
            }
            if (isOnLeft == true && frozen == false && toss > 50 && stage == 1)
            {
                ogreTexture = manager.ogreRight;
            }
            if (isOnLeft == false && frozen == false && toss > 50 && stage == 1)
            {
                ogreTexture = manager.ogreLeft;
            }
            if (toss > 0 && toss < 50 && isOnLeft == true && stage == 1)
            {
                ogreTexture = manager.ogreRightThrown;
            }
            if (toss > 0 && toss < 50 && isOnLeft == false && stage == 1)
            {
                ogreTexture = manager.ogreLeftThrown;
            }
            if (ogreRectangle.X < 0)
            {
                stage = 4;
                charge = false;
                isOnLeft = true;
            }
            if (ogreRectangle.X > 800 - ogreRectangle.Width)
            {
                stage = 4;
                charge = false;
                isOnLeft = false;
            }
            if (stage == 4)
            {
                frozen = true;
            }
            if (stage == 4 && stageTimer == 200)
            {
                stage = 1;
                frozen = false;
            }
            if (frozen == true && isOnLeft == true && (stageTimer == 0 || stageTimer == 50 || stageTimer == 100 || stageTimer == 150 || stageTimer == 200) && stage == 4)
            {
                ogreTexture = manager.ogreLeftDizzyDown;
            }
            if (frozen == true && isOnLeft == true && (stageTimer == 25 || stageTimer == 75 || stageTimer == 125 || stageTimer == 175) && stage == 4)
            {
                ogreTexture = manager.ogreLeftDizzyUp;
            }
            if (frozen == true && isOnLeft == false && (stageTimer == 0 || stageTimer == 50 || stageTimer == 100 || stageTimer == 150 || stageTimer == 200) && stage == 4)
            {
                ogreTexture = manager.ogreRightDizzyDown;
            }
            if (frozen == true && isOnLeft == false && (stageTimer == 25 || stageTimer == 75 || stageTimer == 125 || stageTimer == 175) && stage == 4)
            {
                ogreTexture = manager.ogreRightDizzyUp;
            }
            for (int i = 0; i < manager.knightList.Count; i++)
            {
                if (charge == true && ogreRectangle.Intersects(manager.knightList[i].knightRectangle) && manager.knightList[i].immunity == false)
                {
                    manager.knightList[i].health = manager.knightList[i].health - 2;
                }
            }
            if (ogreRectangle.Y < 0)
            {
                ogreRectangle.Y = 0;
            }
            if (ogreRectangle.Y > 296 - ogreRectangle.Height)
            {
                ogreRectangle.Y = 296 - ogreRectangle.Height;
            }
            if (ogreRectangle.X < 0)
            {
                ogreRectangle.X = 0;
            }
            if (ogreRectangle.X > 800 - ogreRectangle.Width)
            {
                ogreRectangle.X = 800 - ogreRectangle.Width;
            }
            if (health < 0)
            {
                health = 0;
            }
            if (hurt == true)
            {
                hurtCounter += 1;
            }
            if (hurtCounter == 12)
            {
                hurtCounter = 0;
                hurt = false;
            }
            position.X = ogreRectangle.X;
            position.Y = ogreRectangle.Y;
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