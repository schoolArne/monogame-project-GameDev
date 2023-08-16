using GameDevelopement_Game.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enemies
{
    public abstract class Enemy
    {
        protected Texture2D enemyTexture;
        protected Texture2D enemyTextureReversed;
        public Vector2 positie;
        protected Animatie animatie;
        public bool isEnemy { get; } = true;
        public bool isdDead { get; set; } = false;
        public bool isFloor { get; } = false;
        public bool isGate { get; } = false;
        public bool isCoin { get; } = false;
        public int lvl { get; set; }
        
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)positie.X, (int)positie.Y, 60, 63);
            }
        }

        public void playInteractSound()
        {
            //
        }
    }
}
