using GameDevelopement_Game.Animation;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Vector2 snelheid = new Vector2(1, 1);
        private Vector2 versnelling = new Vector2(0.1f, 0.1f);
        private Vector2 positie;

        public Hero(Texture2D textureRunning, Vector2 Positie)
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
            positie = Positie;
        }

        public void Update(GameTime gametime)
        {
            animatie.Update(gametime);
            Move();
            Debug.WriteLine($"positie: {positie}");
            Debug.WriteLine($"snelheid: {snelheid}");
            Debug.WriteLine($"versnelling: {versnelling}");
        }
        
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(heroTextureRunning, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
        private Vector2 Versnel(Vector2 v, float max)
        {
            switch (v.X)
            {
                case > 0:
                    v.X += versnelling.X;
                    break;
                case < 0:
                    v.X -= versnelling.X;
                    break;
                default:
                    break;
            }
            if (v.X > max) { v.X = max; }
            if (v.X < -max) { v.X = -max; }
            switch (v.Y)
            {
                case > 0:
                    v.Y += versnelling.Y;
                    break;
                case < 0:
                    v.Y -= versnelling.Y;
                    break;
                default:
                    break;
            }
            if (v.Y > max) { v.Y = max; }
            if (v.Y < -max) { v.Y = -max; }
            return v;
        }
        private void Move()
        {
            positie += snelheid;
            float maxSpeed = 1000;
            snelheid = Versnel(snelheid, maxSpeed);           
            
            if(positie.X > 1920 - 84 || positie.X < 0)
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
