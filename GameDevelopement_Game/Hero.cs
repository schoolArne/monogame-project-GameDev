﻿using GameDevelopement_Game.Animation;
using GameDevelopement_Game.enums;
using GameDevelopement_Game.Input;
using GameDevelopement_Game.interfaces;
using GameDevelopement_Game.Movement;
using GameDevelopement_Game.rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GameDevelopement_Game
{
    public class Hero:IGameObject
    {
        //identifiers
        public bool isEnemy { get; } = false;
        public bool isFloor { get; } = false;
        public bool isdDead { get; set; } = false;
        public bool isGate { get; } = false;
        public bool isCoin { get; } = false;
        public int lvl { get; set; }
        public bool levelCompleted { get; set; }
        public int damage { get; } = 0;
        //input
        private IInputReader inputreader;

        //animaties
        Texture2D heroTextureRunning;
        Texture2D heroTextureRunningReversed;
        Texture2D heroTextureStandingStill;
        Texture2D heroTextureStandingStillReversed;
        Texture2D healthBar;
        Texture2D coinBar;
        private Rectangle standingStillSourceRectangle = new Rectangle(0, 0, 84, 64);
        Animatie animatie;

        //hero movement
        private Vector2 snelheid;
        public Vector2 Snelheid
        {
            get { return snelheid; }
            set { snelheid = value; }
        }

        private Vector2 versnelling;
        public Vector2 Versnelling
        {
            get { return versnelling; }
            set { versnelling = value; }
        }
        private Vector2 positie;
        public Vector2 Positie
        {
            get { return positie; }
            set { positie = value; }
        }
        public void ChangePosX(float x)
        {
            positie.X = x;
        }
        public void ChangePosY(float y)
        {
            positie.Y = y;
        }
        private Vector2 direction;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }   
        }
        public void ChangeDirectionX(float x)
        {
            direction.X = x;
        }
        public void ChangeDirectionY(float y)
        {
            direction.Y = y;
        }
        private MovementManager heroMovementManager;
        public bool isStandingStill;

        //health
        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        private Vector2 healthbarPos = new Vector2(0, 0);
        private Rectangle healthbarSize;
        public int invincibilityTimer;

        //coins
        public int coinCount { get; set; }
        private Vector2 coinbarPos = new Vector2(1000, 0);
        private Rectangle coinbarSize;

        //score
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int[] getScoreAsArrayOfInts()
        {
            string scoreString = score.ToString();
            int[] scoreArray = new int[scoreString.Length];

            for (int i = 0; i < scoreString.Length; i++)
            {
                scoreArray[i] = int.Parse(scoreString[i].ToString());
            }

            return scoreArray;
        }

        //collision
        private List<IGameObject> otherObjList = new List<IGameObject>();

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Positie.X, (int)Positie.Y, 84, 64);
            }
        }
        private GameState.CurrentGameState gameState;
        public GameState.CurrentGameState _GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                gameState = value;
            }
        }
        public Hero(Texture2D textureRunning,Texture2D textureRunningReversed,Texture2D textureStandingStill,Texture2D textureStandingStillReversed , Texture2D healthbar, Texture2D coins, Vector2 Positie, IInputReader Inputreader, List<IGameObject> otherObj,GameState.CurrentGameState g, int _lvl)
        {
            heroTextureRunning = textureRunning;
            heroTextureRunningReversed = textureRunningReversed;
            this.heroTextureStandingStill = textureStandingStill;
            this.heroTextureStandingStillReversed = textureStandingStillReversed;
            this.healthBar = healthbar;
            this.coinBar = coins;
            inputreader = Inputreader;
            #region animation
            animatie = new Animatie(15);
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(0, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(128, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(256, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(384, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(512, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(640, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(768, 0, 84, 64)));
            animatie.AddAnimationFrame(new AnimationFrame(new Rectangle(896, 0, 84, 64)));
            #endregion
            positie = Positie;
            snelheid = new Vector2(10, 10);
            versnelling = new Vector2(0.1f, 0.1f);
            otherObjList = otherObj;
            heroMovementManager = new MovementManager(inputreader);
            health = 10;
            healthbarSize = new Rectangle(0, 0, health * 100, 20);
            lvl = _lvl;
            levelCompleted = false;
            gameState = g;
            coinCount = 0;
            coinbarSize = new Rectangle(0, 0, coinCount * 100, 20);
        }

        public void Update(GameTime gametime)
        {
            heroMovementManager.Move(this, 84, 64, otherObjList);
            animatie.Update(gametime);
        }
        
        public void Draw(SpriteBatch _spriteBatch)
        {
            RenderHero.DrawHero(_spriteBatch, inputreader, heroTextureRunning, heroTextureRunningReversed, heroTextureStandingStill, heroTextureStandingStillReversed, healthBar, coinBar, positie, animatie, invincibilityTimer, health, healthbarPos, coinCount, coinbarPos);
        }

        public void playInteractSound()
        {
            //
        }
    }
}
