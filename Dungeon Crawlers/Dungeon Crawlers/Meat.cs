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
    public class Meat
    {
        public Rectangle meatRectangle;
        public Texture2D meatTexture;
        public Meat(Rectangle meatRec)
        {
            meatRectangle = meatRec;
        }
    }
}
