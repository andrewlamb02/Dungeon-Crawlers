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
    public class SpeedPowerup
    {
        public Rectangle speedPowerupRectangle;
        public Texture2D speedPowerupTexture;
        public Random rand;
        Game1 manager;
        public SpeedPowerup(Rectangle speedPowerupRec, Game1 man)
        {
            rand = new Random();
            speedPowerupRectangle = speedPowerupRec;
            manager = man;
        }
    }
}
