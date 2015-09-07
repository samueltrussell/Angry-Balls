﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using FarseerPhysics.Dynamics;
using System;

namespace Angry_Balls
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Images
        public static Texture2D playButtonImage;
        public static Texture2D pauseButtonImage;
        public static Texture2D ballImage;
        public static Texture2D bombImage;
        public static Texture2D mineImage;
        public static Texture2D explodeImage;
        public static Texture2D mineExplodeImage;
        public static Texture2D environmentBackground;
        public static Texture2D brickTextureAtlas;
        public static Texture2D toolBoxBackGround;
        public static SpriteFont bombTimerFont;

        //Audio
        private SoundEffect mineExplosion;

        public static SoundEffectInstance mineInstance;

        //Game environment
        Environment environment;
        public static System.Random random;

        //Physics Engine
        public static World world;
        
        //Farseer Experiment 
        
              

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (960);
            graphics.PreferredBackBufferHeight = (1280);
            Content.RootDirectory = "Content";
            random = new System.Random();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //initialize aspects of the physics engine world
            if (world == null)
            {
                world = new World(Vector2.UnitY * 9.8f);
            }
            else
            {
                world.Clear();
            }

            // Load Audio
            mineExplosion = Content.Load<SoundEffect>("Mine");

            mineInstance = mineExplosion.CreateInstance();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playButtonImage = Content.Load<Texture2D>("play_button_temp");
            pauseButtonImage = Content.Load<Texture2D>("pause_button_temp");
            ballImage = Content.Load<Texture2D>("rp_ball");
            bombImage = Content.Load<Texture2D>("rp_bomb_1");
            mineImage = Content.Load<Texture2D>("rp_mine_2");
            explodeImage = Content.Load<Texture2D>("rp_bomb_explode_1");
            mineExplodeImage = Content.Load<Texture2D>("rp_mine_explode_1");
            brickTextureAtlas = Content.Load<Texture2D>("rp_bricks_sprite_1");
            environmentBackground = Content.Load<Texture2D>("rp_background_1");
            toolBoxBackGround = Content.Load<Texture2D>("rp_tool_bar");
            bombTimerFont = Content.Load<SpriteFont>("BombTimer");

            environment = new Environment();
            

            // TODO: use this.Content to load your game content here    
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (environment.gameState == Environment.GameState.initialize)
                environment.initialize();
            else if (environment.gameState == Environment.GameState.run)
            {
                environment.update();
                //Console.WriteLine(Environment.angryBall.ballBody.Position.Y);
                world.Step(Math.Min((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f, (1f / 30f)));
                //Console.WriteLine(Environment.angryBall.ballBody.Position.Y);
            }
            else if (environment.gameState == Environment.GameState.pause)
                environment.update();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //draw the background
            environment.Draw(spriteBatch);

            //Debug Draws
            //spriteBatch.DrawString(bombTimerFont, "Number of Bodies: " + world.BodyList.Count, new Vector2(50, 50), Color.White);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
