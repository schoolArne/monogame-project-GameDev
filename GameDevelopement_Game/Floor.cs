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
    public class Floor : IGameObject
    {
        public bool isEnemy { get; } = false;
        public bool isFloor { get; } = true;
        public bool isGate { get; } = false;
        public bool isCoin { get; } = false;
        public bool isdDead { get; set; } = false;
        public int damage { get; } = 0;
        public int lvl { get; set; }
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

        public Floor(Texture2D t, Vector2 p, int w, int h, int _lvl)
        {
            floorTexture = t;
            floorPositie = p;
            width = w;
            height = h;
            deelRectangle = new Rectangle(0, 0, width, height);
            lvl = _lvl;
        }
        public void Update(GameTime gametime)
        {
            //
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(floorTexture, floorPositie, deelRectangle, Color.White);
        }
    }
}
