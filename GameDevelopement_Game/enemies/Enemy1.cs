using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enemies
{
    internal class Enemy1:IGameObject
    {
        private Texture2D enemyTexture;
        private Vector2 positie;
        private Animatie animatie;
        public bool isEnemy { get; } = true;
        public bool isdDead { get; set; } = false;
        public bool isFloor { get; } = false;
        public bool isGate { get; } = false;
        public bool isCoin { get; } = false;
        public int lvl { get; set; }
        public Enemy1(Texture2D t, Vector2 p, int _lvl)
        {
            enemyTexture = t;
            positie = p;
            #region animatie
            animatie = new Animatie();
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(72, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(144, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(216, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(288, 0, 60, 63)));
            #endregion
            lvl = _lvl;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)positie.X, (int)positie.Y, 60, 63);
            }
        }
        public void Update (GameTime gametime)
        {
            animatie.Update(gametime);
        }
        public void Draw (SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(enemyTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
