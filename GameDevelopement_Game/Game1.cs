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
using System.Drawing.Text;
using Color = Microsoft.Xna.Framework.Color;

namespace GameDevelopement_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Texture2D startScherm;
        private Texture2D gameOver;
        private Texture2D finished;
        private GameState.CurrentGameState gameState = GameState.CurrentGameState.main_menu;
        //hero
        Hero Hero;
        //andere gameobjects
        public List<IGameObject> GameObjectsList = new List<IGameObject>();
        public List<Floor> floorListlvl1 = new List<Floor>();
        public List<Floor> floorListlvl2 = new List<Floor>();

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
            base.Initialize();            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObjects();
            background = Content.Load<Texture2D>("background");
            startScherm = Content.Load<Texture2D>("startscherm");
            gameOver = Content.Load<Texture2D>("game_over");
            finished = Content.Load<Texture2D>("success");
        }

        private void InitializeGameObjects()
        {
            #region all levels
            //bottom of screen floor
            Floor bottomFloor = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 1040), 1920, 10, 3);
            GameObjectsList.Add(bottomFloor);
            floorListlvl1.Add(bottomFloor);
            floorListlvl2.Add(bottomFloor);
            #endregion
            #region hero
            Hero = new Hero(Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x"),Content.Load<Texture2D>("Fox_Sprite_Sheet_Running_4x_reversed"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Standing_Still_4x"), Content.Load<Texture2D>("Fox_Sprite_Sheet_Stinding_Still_4x_Reversed"), Content.Load<Texture2D>("Red_full"), Content.Load<Texture2D>("Yellow_full") ,new Vector2(0, 0), new KeyboardReader(1, true, false), GameObjectsList,gameState, 3); //lvl 3 ==> in beide lvls
            #endregion
            #region lvl1
            //floors
            Floor floor1 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 1680, 100, 1);
            Floor floor2 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1680, 100, 1);
            Floor floor3 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 1680, 100, 1);
            GameObjectsList.Add(floor1);
            GameObjectsList.Add(floor2);
            GameObjectsList.Add(floor3);
            floorListlvl1.Add(floor1);
            floorListlvl1.Add(floor2);
            floorListlvl1.Add(floor3);
            floorListlvl1.Add(floor3);
            //enemies
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), Content.Load<Texture2D>("enemy_1_reversed"), new Vector2(900, 187), 1));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(400, 430), 1));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(1500, 430), 1));
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), Content.Load<Texture2D>("enemy_1_reversed"), new Vector2(200, 687), 1));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(1300, 680), 1));
            GameObjectsList.Add(new Enemy2(Content.Load<Texture2D>("enemy_2"), Content.Load<Texture2D>("enemy_2_reversed"), new Vector2(800, 900), 1, floorListlvl1));
            GameObjectsList.Add(new Enemy2(Content.Load<Texture2D>("enemy_2"), Content.Load<Texture2D>("enemy_2_reversed"), new Vector2(1600, 900), 1, floorListlvl1));
            //endgate
            GameObjectsList.Add(new Gate(Content.Load<Texture2D>("gate"), new Vector2(0, 956), 1));
            //coins
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(200, 220), 1));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(1800, 220), 1));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(800, 470), 1));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(300, 470), 1));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(1000, 720), 1));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(1500, 1010), 1));
            #endregion
            #region lvl2
            //floors
            Floor floor4 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 250), 840, 100, 2);
            Floor floor5 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(1080, 250), 840, 100, 2);
            Floor floor6 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(240, 500), 1440, 100, 2);
            Floor floor7 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(0, 750), 840, 100, 2);
            Floor floor8 = new Floor(Content.Load<Texture2D>("Floor_Texture"), new Vector2(1080, 750), 840, 100, 2);
            GameObjectsList.Add(floor4);
            GameObjectsList.Add(floor5);
            GameObjectsList.Add(floor6);
            GameObjectsList.Add(floor7);
            GameObjectsList.Add(floor8);
            floorListlvl2.Add(floor4);
            floorListlvl2.Add(floor5);
            floorListlvl2.Add(floor6);
            floorListlvl2.Add(floor7);
            floorListlvl2.Add(floor8);
            //enemies
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), Content.Load<Texture2D>("enemy_1_reversed"), new Vector2(400, 187), 2));
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), Content.Load<Texture2D>("enemy_1_reversed"), new Vector2(1200, 187), 2));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(600, 430), 2));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(1300, 430), 2));
            GameObjectsList.Add(new Enemy1(Content.Load<Texture2D>("enemy_1"), Content.Load<Texture2D>("enemy_1_reversed"), new Vector2(200, 687), 2));
            GameObjectsList.Add(new Enemy3(Content.Load<Texture2D>("enemy_3"), Content.Load<Texture2D>("enemy_3_reversed"), new Vector2(1350, 680), 2));
            GameObjectsList.Add(new Enemy2(Content.Load<Texture2D>("enemy_2"), Content.Load<Texture2D>("enemy_2_reversed"), new Vector2(200, 900), 2, floorListlvl2));
            GameObjectsList.Add(new Enemy2(Content.Load<Texture2D>("enemy_2"), Content.Load<Texture2D>("enemy_2_reversed"), new Vector2(800, 900), 2, floorListlvl2));
            GameObjectsList.Add(new Enemy2(Content.Load<Texture2D>("enemy_2"), Content.Load<Texture2D>("enemy_2_reversed"), new Vector2(1600, 900), 2, floorListlvl2));
            //endgate
            GameObjectsList.Add(new Gate(Content.Load<Texture2D>("gate"), new Vector2(1920-52, 956), 2));
            //coins
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(200, 220), 2));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(1800, 220), 2));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(800, 470), 2));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(300, 470), 2));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(1700, 720), 2));
            GameObjectsList.Add(new Coin(Content.Load<Texture2D>("coin"), new Vector2(100, 1010), 2));
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            //to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            //in main menu
            if (gameState == GameState.CurrentGameState.main_menu && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                gameState = GameState.CurrentGameState.level_1;
                Hero._GameState = GameState.CurrentGameState.level_1;
            }
            //in lvl 1
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
            //exiting lvl 1
            if(Hero.coinCount >= 6 && gameState == GameState.CurrentGameState.level_1)
            {
                Hero.levelCompleted = true;
            }
            if(Hero.levelCompleted == true && gameState == GameState.CurrentGameState.level_1)
            {
                Hero.isdDead = false;
                Hero.levelCompleted = false;
                Hero.coinCount = 0;
                Hero.Health = 10;
                Hero.Positie = new Vector2(0, 0);
                Hero._GameState = GameState.CurrentGameState.level_2;
                gameState = GameState.CurrentGameState.level_2;
            }
            //in lvl 2
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
            //exiting lvl 2
            if (Hero.coinCount >= 6 && gameState == GameState.CurrentGameState.level_2)
            {
                Hero.levelCompleted = true;
            }
            if (Hero.levelCompleted == true && gameState == GameState.CurrentGameState.level_2)
            {
                Hero.isdDead = false;
                Hero.levelCompleted = false;
                Hero.Positie = new Vector2(500, 0);
                Hero._GameState = GameState.CurrentGameState.finished;
                gameState = GameState.CurrentGameState.finished;
            }
            //death
            if (Hero.isdDead == true && gameState == GameState.CurrentGameState.level_1 || Hero.isdDead && gameState == GameState.CurrentGameState.level_2)
            {
                gameState = GameState.CurrentGameState.gameover;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if(gameState == GameState.CurrentGameState.main_menu)
            {
                _spriteBatch.Draw(startScherm, new Vector2(0, 0), Color.White);
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