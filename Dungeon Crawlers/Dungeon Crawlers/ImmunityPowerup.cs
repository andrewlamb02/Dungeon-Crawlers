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
    public class ImmunityPowerup
    {
        public Rectangle immunityPowerupRectangle;
        public Texture2D immunityPowerupTexture;
        Game1 manager;
        public ImmunityPowerup(Rectangle immunityPowerupRec, Game1 man)
        {
            immunityPowerupRectangle = immunityPowerupRec;
            manager = man;
        }
    }
}
