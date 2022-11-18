using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game
{
    public class Hero
    {
        Texture2D heroTextureRunning;
        public Hero(Texture2D textureRunning)
        {
            heroTextureRunning = textureRunning;
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {

        }
    }
}
