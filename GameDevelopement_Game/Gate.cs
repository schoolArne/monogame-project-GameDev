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
    internal class Gate : IGameObject
    {
        public bool isEnemy { get; } = false;
        public bool isFloor { get; } = false;
        public bool isGate { get; } = true;
        public bool isCoin { get; } = false;
        public bool isdDead { get; set; } = false;
        public int damage { get; } = 0;
        public int lvl { get; set; }
        private Vector2 Positie;
        private Texture2D gateTexture;
        public Gate(Texture2D t, Vector2 p, int l)
        {
            gateTexture = t;
            Positie = p;
            lvl = l;
        }
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Positie.X, (int)Positie.Y, 84, 64);
            }
        }
        public void Update(GameTime gametime)
        {
            return;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(gateTexture, Positie, new Rectangle(0, 0, 52, 84), Color.White);
        }

        public void playInteractSound()
        {
            //
        }
    }
}
