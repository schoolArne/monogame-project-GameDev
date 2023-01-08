using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using GameDevelopement_Game.rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enemies
{
    internal class Enemy3 : Enemy, IGameObject
    {
        public int damage { get; } = 2;
        private int wanderRadius = 100;
        private int wandered = 0;
        private int speed = 3;
        private int direction = 1;
        public Enemy3(Texture2D t, Texture2D tr, Vector2 p, int _lvl)
        {
            enemyTexture = t;
            enemyTextureReversed = tr;
            positie = p;
            #region animatie
            animatie = new Animatie(10);
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 69, 70)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(84, 0, 69, 70)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(168, 0, 69, 70)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(252, 0, 69, 70)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(336, 0, 69, 70)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(420, 0, 69, 70)));
            #endregion
            lvl = _lvl;
        }
        public void Update(GameTime gametime)
        {
            animatie.Update(gametime);
            this.Move();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            RenderEnemy.DrawEnemy(_spriteBatch, positie, enemyTexture, enemyTextureReversed, animatie, direction);
        }
        private void Move()
        {
            if (direction == 1)
            {
                positie.X += speed;
                wandered++;
            }
            if (direction == -1)
            {
                positie.X -= speed;
                wandered++;
            }
            if (wandered >= wanderRadius)
            {
                direction *= -1;
                wandered = 0;
            }
        }
    }
}
