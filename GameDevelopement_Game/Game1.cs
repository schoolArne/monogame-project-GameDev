using GameDevelopement_Game.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;

namespace GameDevelopement_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Hero Hero;
        Floor Vloer1;
        Floor Vloer2;
        Floor Vloer3;

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
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObjects()
        {
            Hero = new Hero(Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x"),Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x_reversed"), new Vector2(0, 100), new KeyboardReader(1));
            Vloer1 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 1680, 100);
            Vloer2 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1680, 100);
            Vloer3 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 1680, 100);
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

            Hero.Draw(_spriteBatch);
            Vloer1.Draw(_spriteBatch);
            Vloer2.Draw(_spriteBatch);
            Vloer3.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}