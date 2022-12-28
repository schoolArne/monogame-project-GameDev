using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game
{
    internal class Floor:IGameObject
    {
        public bool isEnemy { get; } = false;
        private Texture2D floorTexture;
        private Vector2 floorPositie;
        private int width;
        private int height;
        private Rectangle deelRectangle;
        public Rectangle CollisionRectangle {
            get
            {
                return new Rectangle((int)floorPositie.X, (int)floorPositie.Y, width, height);
            }
        }

        public Floor(Texture2D t, Vector2 p, int w, int h)
        {
            floorTexture = t;
            floorPositie = p;
            width = w;
            height = h;
            deelRectangle = new Rectangle(0, 0, width, height);
        }
        public void Update(GameTime gametime)
        {

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(floorTexture, floorPositie, deelRectangle, Color.White);
        }
    }
}
