using GameDevelopement_Game.Animation;
using GameDevelopement_Game.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.rendering
{
    public abstract class RenderHero
    {
        public static void DrawHero(Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch, IInputReader inputreader, Texture2D textureRunning, Texture2D textureRunningReversed, Texture2D textureStandingStill, Texture2D textureStandingStillReversed, Texture2D healthbar, Texture2D coins, Vector2 positie, Animatie animatie, int invincibilityTimer, int health, Vector2 healthbarPos,int coincount, Vector2 coinbarPos)
        {
            Rectangle standingStillSourceRectangle = new Rectangle(0, 0, 84, 64);
            if (invincibilityTimer < 50)
            {
                if (invincibilityTimer % 2 == 0)
                {
                    if (inputreader.isStandingStill == true)
                    {
                        if (inputreader.lookDirection < 0)
                        {
                            _spriteBatch.Draw(textureStandingStillReversed, positie, standingStillSourceRectangle, Color.Red);
                        }
                        if (inputreader.lookDirection > 0)
                        {
                            _spriteBatch.Draw(textureStandingStill, positie, standingStillSourceRectangle, Color.Red);
                        }
                    }
                    else
                    {
                        if (inputreader.lookDirection < 0)
                        {
                            _spriteBatch.Draw(textureRunningReversed, positie, animatie.CurrentFrame.SourceRectangle, Color.Red);
                        }
                        if (inputreader.lookDirection > 0)
                        {
                            _spriteBatch.Draw(textureRunning, positie, animatie.CurrentFrame.SourceRectangle, Color.Red);
                        }
                    }
                }
                else
                {
                    if (inputreader.isStandingStill == true)
                    {
                        if (inputreader.lookDirection < 0)
                        {
                            _spriteBatch.Draw(textureStandingStillReversed, positie, standingStillSourceRectangle, Color.White);
                        }
                        if (inputreader.lookDirection > 0)
                        {
                            _spriteBatch.Draw(textureStandingStill, positie, standingStillSourceRectangle, Color.White);
                        }
                    }
                    else
                    {
                        if (inputreader.lookDirection < 0)
                        {
                            _spriteBatch.Draw(textureRunningReversed, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
                        }
                        if (inputreader.lookDirection > 0)
                        {
                            _spriteBatch.Draw(textureRunning, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
                        }
                    }
                }
            }
            //hero doesn't have invincibility frames
            else
            {
                if (inputreader.isStandingStill == true)
                {
                    if (inputreader.lookDirection < 0)
                    {
                        _spriteBatch.Draw(textureStandingStillReversed, positie, standingStillSourceRectangle, Color.White);
                    }
                    if (inputreader.lookDirection > 0)
                    {
                        _spriteBatch.Draw(textureStandingStill, positie, standingStillSourceRectangle, Color.White);
                    }
                }
                else
                {
                    if (inputreader.lookDirection < 0)
                    {
                        _spriteBatch.Draw(textureRunningReversed, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
                    }
                    if (inputreader.lookDirection > 0)
                    {
                        _spriteBatch.Draw(textureRunning, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
                    }
                }
            }
            //render hero health
            Rectangle healthbarSize = new Rectangle(0, 0, health * 100, 20);
            _spriteBatch.Draw(healthbar, healthbarPos, healthbarSize, Color.White);
            //render coin count
            Rectangle coinbarSize = new Rectangle(0, 0, coincount * 100, 20);
            _spriteBatch.Draw(coins, coinbarPos, coinbarSize, Color.White);
        }
    }
}
