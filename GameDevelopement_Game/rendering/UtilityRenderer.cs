using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDevelopement_Game.rendering
{
    public class UtilityRenderer
    {
        public Texture2D char0 { get; set; }
        public Texture2D char1 { get; set; }
        public Texture2D char2 { get; set; }
        public Texture2D char3 { get; set; }
        public Texture2D char4 { get; set; }
        public Texture2D char5 { get; set; }
        public Texture2D char6 { get; set; }
        public Texture2D char7 { get; set; }
        public Texture2D char8 { get; set; }
        public Texture2D char9 { get; set; }

        public UtilityRenderer()
        {
            
        }
        public void renderScore(SpriteBatch _spriteBatch, int posY, int[] score)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 27, 42);
            int y = posY;
            int lengthOfWholeScore = score.Length * 27;
            if(lengthOfWholeScore <= 1920)
            {
                int startX = (1920 - lengthOfWholeScore) / 2;
                foreach(int i in score)
                {
                    _spriteBatch.Draw(convertIntToTexture(i), new Vector2(startX, y), sourceRectangle, Color.White);
                    startX += 27;
                }
            }
        }
        private Texture2D convertIntToTexture(int integer)
        {
            Texture2D textureToDraw;
            switch (integer)
            {
                case 0:
                    textureToDraw = char0;
                    break;
                case 1:
                    textureToDraw = char1;
                    break;
                case 2:
                    textureToDraw = char2;
                    break;
                case 3:
                    textureToDraw = char3;
                    break;
                case 4:
                    textureToDraw = char4;
                    break;
                case 5:
                    textureToDraw = char5;
                    break;
                case 6:
                    textureToDraw = char6;
                    break;
                case 7:
                    textureToDraw = char7;
                    break;
                case 8:
                    textureToDraw = char8;
                    break;
                case 9:
                    textureToDraw = char9;
                    break;
                default:
                    textureToDraw = char0;
                    break;
            }
            return textureToDraw;
        }
    }
}
