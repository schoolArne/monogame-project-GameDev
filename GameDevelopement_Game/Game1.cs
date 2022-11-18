using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopement_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroSpriteSheet;
        private Rectangle _deelrectangle;
        private int schuifop_X = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.PreferredBackBufferWidth = 1920;
            //_graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _deelrectangle = new Rectangle(schuifop_X, 0, 84, 64);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _heroSpriteSheet = Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _spriteBatch.Draw(_heroSpriteSheet, new Vector2(0, 0),_deelrectangle ,Color.White);
            _spriteBatch.End();

            schuifop_X += 128;
            if(schuifop_X > 888)
            {
                schuifop_X = 0;
            }
            _deelrectangle.X = schuifop_X;

            base.Draw(gameTime);
        }
    }
}