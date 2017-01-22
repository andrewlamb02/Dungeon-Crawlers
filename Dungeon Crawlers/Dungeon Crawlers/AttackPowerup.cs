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
    public class AttackPowerup
    {
        public Rectangle attackPowerupRectangle;
        public Texture2D attackPowerupTexture;
        Game1 manager;
        public AttackPowerup(Rectangle attackPowerupRec, Game1 man)
        {
            attackPowerupRectangle = attackPowerupRec;
            manager = man;
        }
    }
}
