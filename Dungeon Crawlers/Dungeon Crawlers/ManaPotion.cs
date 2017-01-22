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
    public class ManaPotion
    {
        public Rectangle manaPotionRectangle;
        public Texture2D manaPotionTexture;
        public Random rand;
        Game1 manager;
        public ManaPotion(Rectangle manaPotionRec, Game1 man)
        {
            rand = new Random();
            manaPotionRectangle = manaPotionRec;
            manager = man;
        }

        public void Update()
    {
            for (int i = 0; i < manager.meatList.Count; i++)
            {
                if (manaPotionRectangle.Intersects(manager.meatList[i].meatRectangle))
                {
                    manaPotionRectangle.Y = rand.Next(266);
                    manaPotionRectangle.X = rand.Next(770);
                }
            }
}
    }
}
