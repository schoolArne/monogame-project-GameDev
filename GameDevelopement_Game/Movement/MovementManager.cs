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
        public MovementManager(IInputReader ireader)
        {
            inputReader = ireader;
        }
        public void Move(Hero hero,int heroWidth, int heroHeight, List<IGameObject> objects)
        {
            hero.Direction = inputReader.ReadInput();
            hero.Direction *= hero.Snelheid;
            toekomstigePositie = hero.Positie + hero.Direction;



            #region collision detection
            Rectangle heroCollisionRectangle;
            heroCollisionRectangle = new Rectangle((int)toekomstigePositie.X, (int)toekomstigePositie.Y, heroWidth, heroHeight - 4);
            //check for X value
            bool collidesX = false;
            foreach (IGameObject obj in objects)
            {
                if (heroCollisionRectangle.Intersects(obj.CollisionRectangle)){
                    collidesX = true;
                }
            }
            if (!collidesX) { hero.ChangePosX((int)toekomstigePositie.X); }

            //check for Y value
            bool collidesY = false;
            foreach (IGameObject obj in objects)
            {
                if (heroCollisionRectangle.Intersects(obj.CollisionRectangle))
                {
                    collidesY = true;
                }
            }
            if (!collidesX) { hero.ChangePosY((int)toekomstigePositie.Y); }

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
        }
    }
}
