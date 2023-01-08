using GameDevelopement_Game.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.rendering
{
    public abstract class RenderEnemy
    {
        public static void DrawEnemy(Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch, Vector2 positie, Texture2D enemyTexture, Texture2D enemyTextureReversed, Animatie animatie, int direction)
        {
            if (direction == 1)
            {
                _spriteBatch.Draw(enemyTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
            }
            if (direction == -1)
            {
                _spriteBatch.Draw(enemyTextureReversed, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
            }
        }
    }
}
