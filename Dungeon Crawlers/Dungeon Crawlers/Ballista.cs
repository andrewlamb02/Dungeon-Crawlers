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
    public class Ballista
    {
        //what the goblin looks like
        public Texture2D ballistaTexture;
        //the area the goblin takes up
        public Rectangle ballistaRectangle;
        public int health;
        public bool ballistaMove;
        public Vector2 position;
        public int shoot;
        public bool hurt;
        public int hurtCounter;
        public Color ballistaColor;
        Game1 manager;
        public Ballista(Game1 man, int hea, Rectangle ballistaRec, Vector2 place)
        {
            manager = man;
            health = hea;
            ballistaRectangle = ballistaRec;
            position = place;
        }
        public void Move(string direction)
        {

            if (direction == "Up")
            {
                ballistaRectangle.Y -= 2;
            }
            if (direction == "Down")
            {
                ballistaRectangle.Y += 2;
            }
            position.Y = ballistaRectangle.Y;
            position.X = ballistaRectangle.X;
        }
        public void Update()
        {
            if (manager.knightList.Count > -0)
            {
                Knight enemy = ClosestKnight();
                if (enemy.position.Y > position.Y)
                {
                    Move("Down");
                }
                if (enemy.position.Y < position.Y)
                {
                    Move("Up");
                }
            }
            shoot += 1;
            if (shoot >= 300)
            {
                shoot = 0;
            }
            if (hurt == true)
            {
                hurtCounter += 1;
                ballistaColor = Color.Red;
            }
            else
            {
                ballistaColor = Color.White;
            }
            if (hurtCounter == 12)
            {
                hurtCounter = 0;
                hurt = false;
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
