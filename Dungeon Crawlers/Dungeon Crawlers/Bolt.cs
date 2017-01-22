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
    public class Bolt
    {
        public Rectangle boltRectangle;
        public bool ballistaShot;
        public bool draw;
        public Texture2D boltTexture;
        Game1 manager;
        public bool toRemove;
        public Bolt(Rectangle boltRec, Texture2D boltTex, Game1 man)
        {
            boltRectangle = boltRec;
            boltTexture = boltTex;
            manager = man;
            draw = false;
            toRemove = false;

        }
        public void Move(string direction)
        {
            if (direction == "Left")
            {
                boltRectangle.X -= 5;
            }
        }
        public void Hit()
        {
            for (int i = 0; i < manager.knightList.Count; i++)
            {
                if (boltRectangle.Intersects(manager.knightList[i].knightRectangle) && manager.knightList[i].immunity == false)
                {
                    toRemove = true;
                    manager.knightList[i].health = manager.knightList[i].health -= 15;
                    manager.knightList[i].hurt = true;
                }
            }
        }
        public void Update()
        {
            /*
            for (int i = 0; i < manager.ballistaList.Count; i++)
            {
                if (manager.ballistaList[i].shoot > 90)
                {
                    draw = true;
                }
            }
            if (boltRectangle.X < 0)
            {
                if (manager.ballistaList.Count > 0)
                {
                    boltRectangle = new Rectangle(manager.ballista.ballistaRectangle.X + 10, manager.ballista.ballistaRectangle.Y + 10, 40, 20);
                }
                draw = false;
            }*/
            if (boltRectangle.X < 0)
            {
                toRemove = true;
            }
        }
    }
}
