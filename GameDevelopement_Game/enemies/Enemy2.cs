using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enemies
{
    internal class Enemy2 : Enemy, IGameObject
    {
        public int damage { get; } = 3;
        public Enemy2(Texture2D t, Vector2 p, int _lvl)
        {
            enemyTexture = t;
            positie = p;
            #region animatie
            animatie = new Animatie(17);
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 60, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(60, 0, 60, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(120, 0, 60, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(180, 0, 60, 64)));
            #endregion
            lvl = _lvl;
        }
        public void Update(GameTime gametime)
        {
            animatie.Update(gametime);
            //this.Move();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(enemyTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
        /*
        private void Move()
        {
            positie += snelheid;
            float maxSpeed = 1000;
            snelheid = Versnel(snelheid, maxSpeed);

            if (positie.X > 1920 - 84 || positie.X < 0)
            {
                snelheid.X *= -1;
            }
            if (positie.Y > 1080 - 96 || positie.Y < 0)
            {
                snelheid.Y *= -1;
            }
        }
        */
    }
}
