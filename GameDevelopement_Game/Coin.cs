using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game
{
    internal class Coin : IGameObject
    {
        public bool isEnemy { get; } = false;
        public bool isFloor { get; } = false;
        public bool isGate { get; } = false;
        public bool isCoin { get; } = true;
        public bool isdDead { get; set; } = false;
        public int damage { get; } = 0;
        public int lvl { get; set; }
        private Texture2D coinTexture;
        private Vector2 coinPositie;
        private SoundEffect collectSound;
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)coinPositie.X, (int)coinPositie.Y, 30, 30);
            }
        }
        public Coin(Texture2D t, Vector2 p, int _lvl, SoundEffect _collectSound)
        {
            coinTexture = t;
            coinPositie = p;
            lvl = _lvl;
            this.collectSound = _collectSound;
        }
        public void Update(GameTime gametime)
        {
            //
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if(this.isdDead == false)
            {
                _spriteBatch.Draw(coinTexture, coinPositie, new Rectangle(0, 0, 30, 30), Color.White);
            }            
        }
        public void playInteractSound()
        {
            collectSound.Play();
        }
    }
}
