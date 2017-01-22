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
    public class Rock
    {
        public Rectangle rockRectangle;
        public Texture2D rockTexture;
        public bool toRemove;
        Game1 manager;
        public Rock(Rectangle rockRec, Texture2D rockTex, Game1 man)
        {
            rockRectangle = rockRec;
            rockTexture = rockTex;
            manager = man;
        }
        public void Update()
        {
            for (int i = 0; i < manager.ogreList.Count; i++)
            {
                if (manager.ogreList[i].isOnLeft == true)
                {
                    rockRectangle.X += 5;
                    rockTexture = manager.rockTextureLeft;
                }
                if (manager.ogreList[i].isOnLeft == false)
                {
                    rockRectangle.X -= 5;
                    rockTexture = manager.rockTextureRight;
                }
            }
            if (manager.knightList.Count > 0)
            {
                Hit();
            }
            if (rockRectangle.X < 0 - rockRectangle.Width || rockRectangle.X > 800)
            {
                toRemove = true;
            }
            if (manager.ogreList.Count < 0)
            {
                toRemove = true;
            }
        }
        public void Hit()
        {
            for (int i = 0; i < manager.knightList.Count; i++)
            {
                if (rockRectangle.Intersects(manager.knightList[i].knightRectangle) && manager.knightList[i].immunity == false)
                {
                    toRemove = true;
                    manager.knightList[i].health = manager.knightList[i].health - 25;
                    manager.knightList[i].hurt = true;
                }
            }
        }
    }
}
