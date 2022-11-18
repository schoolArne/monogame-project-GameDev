﻿using Microsoft.Xna.Framework;
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

        private double secondCounter = 0;
        public void Update(GameTime gametime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gametime.ElapsedGameTime.TotalSeconds;
            int fps = 1;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }

        }

    }
}
