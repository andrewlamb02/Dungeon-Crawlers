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
    public class InputHandler
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        Game1 manager;
        public InputHandler()
        {
        }
        public InputHandler(Game1 man)
        {
            manager = man;
            keyboardState = Keyboard.GetState();
            lastKeyboardState = Keyboard.GetState();
        }
        public void InputControl()
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) && manager.gameStarted == false && manager.gameOver == false)
            {
                manager.gameStarted = true;
                manager.level = 1;
                manager.levelMessage = true;
                manager.knight.alive = true;
                manager.knightList.Add(manager.knight);
                for (int i = 0; i < manager.knightList.Count; i++)
                {
                    if (manager.knightList[i].isGold == true)
                    {
                        manager.knightList[i].knightTexture = manager.goldKnightTextureRight;
                    }
                    else
                    {
                        manager.knightList[i].knightTexture = manager.knightTextureRight;
                    }
                }
            }
            if (keyboardState.IsKeyDown(Keys.Space) && manager.gameStarted == false && manager.gameOver == false)
            {
                manager.gameStarted = true;
                manager.level = 1;
                manager.levelMessage = true;
                manager.knight.alive = true;
                manager.knightTwo.alive = true;
                manager.knightList.Add(manager.knight);
                manager.knightList.Add(manager.knightTwo);
                manager.twoPlayer = true;
                for (int i = 0; i < manager.knightList.Count; i++)
                {
                    if (manager.knightList[i].isGold == true)
                    {
                        manager.knightList[i].knightTexture = manager.goldKnightTextureRight;
                    }
                    else
                    {
                        manager.knightList[i].knightTexture = manager.knightTextureRight;
                    }
                }
            }
            if (keyboardState.IsKeyDown(Keys.Back) && lastKeyboardState.IsKeyUp(Keys.Back) && (manager.gameOver == true || manager.win == true))
            {
                manager.gameStarted = false;
                manager.gameOver = false;
                manager.Init();
                manager.SetTextures();
            }
            if (manager.knight.alive == true && manager.gameStarted == true)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    manager.knight.Move("Up");
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    manager.knight.Move("Down");
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    manager.knight.Move("Left");
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    manager.knight.Move("Right");
                }
                if (keyboardState.IsKeyDown(Keys.R) && lastKeyboardState.IsKeyUp(Keys.R))
                {
                    manager.knight.Attack();
                }
                if (keyboardState.IsKeyDown(Keys.E) && lastKeyboardState.IsKeyUp(Keys.E))
                {
                        if (manager.knight.knightAttackTimeCounter == false)
                        {
                            manager.knight.ShieldBash();
                        }
                }
            }
            if (manager.knightTwo.alive == true && manager.gameStarted == true)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    manager.knightTwo.Move("Up");
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    manager.knightTwo.Move("Down");
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    manager.knightTwo.Move("Left");
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    manager.knightTwo.Move("Right");
                }
                if (keyboardState.IsKeyDown(Keys.K) && lastKeyboardState.IsKeyUp(Keys.K))
                {
                    manager.knightTwo.Attack();
                }
                if (keyboardState.IsKeyDown(Keys.L) && lastKeyboardState.IsKeyUp(Keys.L))
                {
                    if (manager.knightTwo.knightAttackTimeCounter == false)
                    {
                        manager.knightTwo.ShieldBash();
                    }
                }
            }
            lastKeyboardState = Keyboard.GetState();
        }
    }
}
