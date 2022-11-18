using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.Animation
{
    public class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }
        public void AddAnimationFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;

            if(counter >= frames.Count)
            {
                counter = 0;
            }
        }
        
    }
}
