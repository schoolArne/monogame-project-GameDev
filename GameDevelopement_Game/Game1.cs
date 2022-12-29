using GameDevelopement_Game.enemies;
using GameDevelopement_Game.enums;
using GameDevelopement_Game.Input;
using GameDevelopement_Game.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace GameDevelopement_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Texture2D gameOver;
        private Texture2D finished;
        private GameState.CurrentGameState gameState = GameState.CurrentGameState.level_1;
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
            gameOver = Content.Load<Texture2D>("game_over");
            finished = Content.Load<Texture2D>("success");
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObjects()
        {
            //hero
            Hero = new Hero(Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x"),Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x_reversed"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Standing_Still_4x"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Stinding_Still_4x_Reversed"), Content.Load<Texture2D>("Red_full"), new Vector2(0, 0), new KeyboardReader(1, true, false), GameObjectsList,gameState, 3); //lvl 3 ==> in beide lvls
            //lvl 1
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 1680, 100, 1));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1680, 100, 1));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 1680, 100, 1));            
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), new Vector2(500, 500), 1));
            GameObjectsList.Add(new Gate(Content.Load<Texture2D>("gate"), new Vector2(0, 956), 1));
            //lvl 2
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 840, 100, 2));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(1080, 250), 840, 100, 2));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1440, 100, 2));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 840, 100, 2));
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(1080, 750), 840, 100, 2));
            GameObjectsList.Add(new Gate(Content.Load<Texture2D>("gate"), new Vector2(1920-52, 956), 2));
            //all levels
            GameObjectsList.Add(new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 1040), 1920, 10, 3));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (gameState == GameState.CurrentGameState.main_menu)
            {
                //
            }
            if (gameState == GameState.CurrentGameState.level_1)
            {
                Hero.Update(gameTime);               
                foreach (var obj in GameObjectsList)
                {
                    if(obj.lvl == 1 || obj.lvl == 3)
                    {
                        if (obj.isFloor == false)
                        {
                            obj.Update(gameTime);
                        }
                    }                    
                }
            }
            if(Hero.isdDead == true && gameState == GameState.CurrentGameState.level_1)
            {
                gameState = GameState.CurrentGameState.gameover;
            }
            if(Hero.levelCompleted == true && gameState == GameState.CurrentGameState.level_1)
            {
                Hero.isdDead = false;
                Hero.levelCompleted = false;
                Hero.Positie = new Vector2(500, 0);
                Hero._GameState = GameState.CurrentGameState.level_2;
                gameState = GameState.CurrentGameState.level_2;
            }
            if (gameState == GameState.CurrentGameState.level_2)
            {
                Hero.Update(gameTime);
                foreach (var obj in GameObjectsList)
                {
                    if (obj.lvl == 2 || obj.lvl == 3)
                    {
                        if (obj.isFloor == false)
                        {
                            obj.Update(gameTime);
                        }
                    }
                }
            }
            if (Hero.levelCompleted == true && gameState == GameState.CurrentGameState.level_2)
            {
                Hero.isdDead = false;
                Hero.levelCompleted = false;
                Hero.Positie = new Vector2(500, 0);
                Hero._GameState = GameState.CurrentGameState.finished;
                gameState = GameState.CurrentGameState.finished;
            }
            if (gameState == GameState.CurrentGameState.gameover)
            {
                //
            }           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if(gameState == GameState.CurrentGameState.main_menu)
            {
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            }
            if(gameState == GameState.CurrentGameState.level_1)
            {
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                Hero.Draw(_spriteBatch);
                foreach (var obj in GameObjectsList)
                {
                    if(obj.lvl == 1 || obj.lvl == 3)
                    {
                        obj.Draw(_spriteBatch);
                    }                    
                }
            }
            if(gameState == GameState.CurrentGameState.level_2)
            {
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                Hero.Draw(_spriteBatch);
                foreach (var obj in GameObjectsList)
                {
                    if(obj.lvl == 2 || obj.lvl == 3)
                    {
                        obj.Draw(_spriteBatch);
                    }                    
                }
            }
            if(gameState == GameState.CurrentGameState.gameover)
            {
                _spriteBatch.Draw(gameOver, new Vector2(0, 0), Color.White);
            }
            if(gameState == GameState.CurrentGameState.finished)
            {
                _spriteBatch.Draw(finished, new Vector2(0, 0), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}