using GameDevelopement_Game.Input;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.Movement
{
    public class MovementManager
    {
        private IInputReader inputReader;
        private Vector2 toekomstigePositie;
        private int jumpTimer;
        private int invincibilityTimer;
        public MovementManager(IInputReader ireader)
        {
            inputReader = ireader;
            jumpTimer = 0;
            invincibilityTimer = 50;
        }
        public void Move(Hero hero,int heroWidth, int heroHeight, List<IGameObject> objects)
        {
            hero.Direction = inputReader.ReadInput();
            hero.Direction *= hero.Snelheid;
            toekomstigePositie = hero.Positie + hero.Direction;
            
            if (inputReader.triesToJump)
            {
                
            }

            #region collision detection
            bool hashit = false;
            Rectangle heroCollisionRectangle;
            heroCollisionRectangle = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, heroWidth, heroHeight - 4);
            //check for X value
            bool collidesX = false;
            foreach (IGameObject obj in objects)
            {
                if(obj.lvl == (int)hero._GameState)
                {
                    if (heroCollisionRectangle.Intersects(obj.CollisionRectangle))
                    {
                        if (obj.isEnemy == true && invincibilityTimer > 50)
                        {
                            hashit = true;
                            hero.Health -= 1;
                            invincibilityTimer = 0;
                        }
                        if (obj.isGate == true)
                        {
                            hero.levelCompleted = true;
                        }
                        else
                        {
                            collidesX = true;

                        }
                    }
                }                
            }
            if (!collidesX) { hero.ChangePosX(toekomstigePositie.X); }

            //check for Y value
            bool collidesY = false;
            foreach (IGameObject obj in objects)
            {
                if(obj.lvl == (int)hero._GameState)
                {
                    if (heroCollisionRectangle.Intersects(obj.CollisionRectangle))
                    {
                        if (obj.isEnemy == true && invincibilityTimer > 50)
                        {
                            if (hashit == false)
                            {
                                hero.Health -= 1;
                                invincibilityTimer = 0;
                            }
                        }
                        else
                        {
                            collidesY = true;
                        }
                    }
                }                
            }
            if (!collidesX) { hero.ChangePosY(toekomstigePositie.Y); }
            hashit = false;
            invincibilityTimer++;



            //check for screen border
            if (hero.Positie.X < 0)
            {
                hero.ChangePosX(0);
            }
            if (hero.Positie.Y < 0)
            {
                hero.ChangePosY(0);
            }
            if (hero.Positie.X > 1920 - 84)
            {
                hero.ChangePosX(1920 - 84);
            }
            if (hero.Positie.Y > 1080 - 96)
            {
                hero.ChangePosY(1080 - 96);
            }
            #endregion
            if (hero.Health == 0)
            {
                hero.isdDead = true;
            }
        }
    }
}
