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
        public Enemy2(Texture2D t, Vector2 p, int _lvl)
        {
            enemyTexture = t;
            positie = p;
            #region animatie
            animatie = new Animatie();
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
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(enemyTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
