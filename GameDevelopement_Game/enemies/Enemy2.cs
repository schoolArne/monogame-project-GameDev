using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enemies
{
    internal class Enemy2 : Enemy, IGameObject
    {
        public int damage { get; } = 3;
        private Vector2 snelheid = new Vector2(3, 3);
        private Vector2 toekomstigePositie;
        protected List<Floor> floorList;
        public Enemy2(Texture2D t, Texture2D tr, Vector2 p, int _lvl, List<Floor> l)
        {
            enemyTexture = t;
            enemyTextureReversed = tr;
            positie = p;
            #region animatie
            animatie = new Animatie(10);
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 52, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(52, 0, 52, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(104, 0, 52, 64)));
            #endregion
            lvl = _lvl;
            floorList = l;
        }
        public void Update(GameTime gametime)
        {
            animatie.Update(gametime);
            this.Move();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(enemyTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
        private void Move()
        {
            toekomstigePositie = positie + snelheid;
            //collision

            positie += snelheid;
            //levelranden
            if (positie.X > 1920 - 84 || positie.X < 0)
            {
                snelheid.X *= -1;
            }
            if (positie.Y > 1080 - 96 || positie.Y < 0)
            {
                snelheid.Y *= -1;
            }
        }
    }
}
