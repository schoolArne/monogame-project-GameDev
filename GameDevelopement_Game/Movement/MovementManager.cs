using GameDevelopement_Game.enums;
using GameDevelopement_Game.Input;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
        public void Move(Hero hero, int heroWidth, int heroHeight, List<IGameObject> objects)
        {
            hero.Direction = inputReader.ReadInput();
            hero.Direction *= hero.Snelheid;
            toekomstigePositie = hero.Positie + hero.Direction;
            hero.invincibilityTimer = invincibilityTimer;


            #region hero gamestate to integer to check with gameobjects conversion
            int IntegerToCheckWithGameObjects;
            switch (hero._GameState)
            {
                case GameState.CurrentGameState.level_1:
                    IntegerToCheckWithGameObjects = 1;
                    break;
                case GameState.CurrentGameState.level_2:
                    IntegerToCheckWithGameObjects = 2;
                    break;
                case GameState.CurrentGameState.level_3:
                    IntegerToCheckWithGameObjects = 4;
                    break;
                default:
                    IntegerToCheckWithGameObjects = -1;
                    break;
            }

            #endregion

            #region collision detection
            bool hashit = false;
            Rectangle heroCollisionRectangle;
            heroCollisionRectangle = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, heroWidth, heroHeight - 4);
            //check for X value
            bool collidesX = false;
            foreach (IGameObject obj in objects)
            {
                if (obj.lvl == IntegerToCheckWithGameObjects && obj.isdDead == false)
                {
                    if (heroCollisionRectangle.Intersects(obj.CollisionRectangle))
                    {
                        if (obj.isEnemy == true && invincibilityTimer > 50)
                        {
                            hashit = true;
                            hero.Health -= obj.damage;
                            invincibilityTimer = 0;
                        }
                        if (obj.isGate == true)
                        {
                            hero.levelCompleted = true;
                        }
                        if (obj.isCoin == true)
                        {
                            obj.isdDead = true;
                            hero.coinCount++;
                        }
                        else if (!obj.isEnemy)
                        {
                            Rectangle rectangleToCeck = new Rectangle(obj.CollisionRectangle.Location.X, obj.CollisionRectangle.Location.Y + 10, obj.CollisionRectangle.Size.X, obj.CollisionRectangle.Size.Y - 10); 
                            if(heroCollisionRectangle.Intersects(rectangleToCeck))
                            {
                                collidesX = true;
                            }
                        }
                    }
                }
            }
            if (!collidesX) { hero.ChangePosX(toekomstigePositie.X); }

            //check for Y value
            bool collidesY = false;
            foreach (IGameObject obj in objects)
            {
                if (obj.lvl == IntegerToCheckWithGameObjects && obj.isdDead == false)
                {
                    if (heroCollisionRectangle.Intersects(obj.CollisionRectangle))
                    {
                        if (obj.isEnemy == true && invincibilityTimer > 50)
                        {
                            if (hashit == false)
                            {
                                hero.Health -= obj.damage;
                                invincibilityTimer = 0;
                            }
                        }
                        if (obj.isGate == true)
                        {
                            hero.levelCompleted = true;
                        }
                        if (obj.isCoin == true)
                        {
                            obj.isdDead = true;
                            hero.coinCount++;
                        }
                        else if (!obj.isEnemy)
                        {
                            collidesY = true;
                        }
                    }
                }
            }
            if (!collidesY) { hero.ChangePosY(toekomstigePositie.Y); }
            hashit = false;
            invincibilityTimer++;
            if (invincibilityTimer == 2000000000)
            {
                invincibilityTimer = 100;
            }



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
            if (hero.Health <= 0)
            {
                hero.isdDead = true;
            }
        }
    }    
}
