﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.interfaces
{
    public interface IGameObject
    {
        public bool isEnemy { get; }
        public bool isFloor { get; }
        public bool isGate { get;}
        public bool isCoin { get; }
        public bool isdDead { get; set; }
        public int lvl { get; set; }
        public int damage { get; }
        public Rectangle CollisionRectangle { get; }
        void Update(GameTime gametime);

        void Draw(SpriteBatch _spriteBatch);

        void playInteractSound();
    }
}
