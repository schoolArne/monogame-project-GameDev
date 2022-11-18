using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GameDevelopement_Game
{
    public class Hero:IGameObject
    {
        Texture2D heroTextureRunning;
        Animatie animatie;


        public Hero(Texture2D textureRunning)
        {
            heroTextureRunning = textureRunning;
            animatie = new Animatie();
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(128, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(256, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(384, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(512, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(640, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(768, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(896, 0, 84, 64)));
        }

        public void Update(GameTime gametime)
        {
            animatie.Update(gametime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(heroTextureRunning, new Vector2(0, 0), animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
