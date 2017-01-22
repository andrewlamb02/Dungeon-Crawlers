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
    public class HealthBar
    {
        public Rectangle healthBarRectangle;
        public Texture2D healthBarTexture;
        public Game1 manager;
        public HealthBar(Rectangle healthBarRec, Texture2D healthBartex, Game1 man)
        {
            healthBarRectangle = healthBarRec;
            healthBarTexture = healthBartex;
            manager = man;
        }
    }
}
