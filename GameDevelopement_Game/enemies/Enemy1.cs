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
    internal class Enemy1: Enemy, IGameObject
    {
        public int damage { get; } = 1;
        public Enemy1(Texture2D t, Vector2 p, int _lvl)
        {
            enemyTexture = t;
            positie = p;
            #region animatie
            animatie = new Animatie(10);
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(72, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(144, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(216, 0, 60, 63)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(288, 0, 60, 63)));
            #endregion
            lvl = _lvl;
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
