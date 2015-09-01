using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Angry_Balls
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Texture2D bombImage;
        public static Texture2D explodeImage;
        public static Texture2D environmentBackground;
        public static Texture2D brickTextureAtlas;
        public static Texture2D toolBoxBackGround;
        public static SpriteFont bombTimerFont;

        Environment environment;
        public static System.Random random;  
        
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bombImage = Content.Load<Texture2D>("Bomb");
            explodeImage = Content.Load<Texture2D>("Explosion");
            brickTextureAtlas = Content.Load<Texture2D>("rp_small_bricks_sprite_1");
            environmentBackground = Content.Load<Texture2D>("stars");
            toolBoxBackGround = Content.Load<Texture2D>("toolbox");
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
                environment.update();
            else if (environment.gameState == Environment.GameState.pause)



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

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
