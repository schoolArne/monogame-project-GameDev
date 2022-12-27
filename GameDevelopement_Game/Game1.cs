﻿using GameDevelopement_Game.Input;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;

namespace GameDevelopement_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;

        //hero
        Hero Hero;
        //andere gameobjects
        public List<IGameObject> GameObjectsList = new List<IGameObject>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObjects();
            background = Content.Load<Texture2D>("background");
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObjects()
        {
            Hero = new Hero(Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x"),Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x_reversed"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Standing_Still_4x"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Stinding_Still_4x_Reversed"), Content.Load<Texture2D>("Green_full"), new Vector2(0, 0), new KeyboardReader(1, true), GameObjectsList);
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 1680, 100));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1680, 100));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 1680, 100));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            Hero.Draw(_spriteBatch);
            foreach(var obj in GameObjectsList)
            {
                obj.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}