using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Farseer
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace Angry_Balls
{
    class Environment
    {
        Texture2D background;
        public static bool objectClicked = false;

        private InputManager Input;
        private Map map;
        private ToolBox toolBox;
        private FarseerBall angryBall;    // Made static so I could reference from TBoxItem Class

        //Border Bodies for the Physics Engine
        private Body leftWall;
        private Body rightWall;
        private Body floor;
        private Body ceiling;

        private Vector2 leftWallPosition = UnitConverter.toSimSpace(new Vector2(-5, 640));
        private Vector2 rightWallPosition = UnitConverter.toSimSpace(new Vector2(815, 640));
        private Vector2 ceilingPosition = UnitConverter.toSimSpace(new Vector2(480, -640));
        private Vector2 floorPosition = UnitConverter.toSimSpace(new Vector2(480, 1360));

        //Play Controls
        private PlayPauseButton playPauseButton;

        protected Vector2 ballStartPose = new Vector2(150, 150);

        public enum GameState { run, pause, initialize };
        public GameState gameState;

        //Environment Constructor
        public Environment()
        {
            //Initialize the Buttons
            playPauseButton = new PlayPauseButton(gameState);

            background = Game1.environmentBackground;
            Input = new InputManager();
            map = new Map();
            //justClicked = false;
            toolBox = new ToolBox();
            gameState = GameState.run;
            angryBall = new FarseerBall(ballStartPose);

            //Physics Bodies for Walls
            leftWall = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(10), UnitConverter.toSimSpace(2560), 1.0f, leftWallPosition);
            leftWall.BodyType = BodyType.Static;
            rightWall = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(10), UnitConverter.toSimSpace(2560), 1.0f, rightWallPosition);
            rightWall.BodyType = BodyType.Static;
            ceiling = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(960), UnitConverter.toSimSpace(10), 1.0f, ceilingPosition);
            ceiling.BodyType = BodyType.Static;
            floor = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(960), UnitConverter.toSimSpace(10), 1.0f, floorPosition);
            floor.BodyType = BodyType.Static;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point screenSize = new Point { X = Game1.graphics.PreferredBackBufferWidth, Y = Game1.graphics.PreferredBackBufferHeight };
            Rectangle screen = new Rectangle(Point.Zero, screenSize);
            spriteBatch.Draw(background, screen, Color.White);

            //Draw the control Buttons
            playPauseButton.Draw(spriteBatch);

            //Draw the Ball
            angryBall.Draw(spriteBatch);
     
            //Draw ToolBox
            if (toolBox.Show()) toolBox.draw(spriteBatch);
           
            //Draw ToolBox Contents
            foreach (Bomb element in map.TBIList.PlacedBomb)
            {
                element.draw(spriteBatch);
            }

            foreach (ProxMine element in map.TBIList.placedMines)
            {
                element.draw(spriteBatch);
            }

            //Draw Fixed Bricks (draw Map)
            foreach (FixedBrick element in map.TBIList.FixedBrickList)
            {
                element.draw(spriteBatch);
            }

            //map.draw();

        }

        public void update()
        {
            //Handle Inputs
            MouseState mouseState = Mouse.GetState();
            Input.HandleButtons(playPauseButton, mouseState, ref gameState);
            Input.HandleDragAndDrop(map, mouseState);


            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Enter) && angryBall.ballBody.BodyType == BodyType.Static)
            {
                angryBall.ballBody.BodyType = BodyType.Dynamic;
            }
            if (keyState.IsKeyDown(Keys.P) && angryBall.ballBody.BodyType == BodyType.Dynamic)
            {
                angryBall.ballBody.BodyType = BodyType.Static;
            }
            if(keyState.IsKeyDown(Keys.Space))
            {
                angryBall.ballBody.ApplyForce(new Vector2(10.0f, -50.0f));
            }
            if(keyState.IsKeyDown(Keys.Q))
            {
                System.Environment.Exit(0);
            }

            //Update objects in the environment
            map.update();
        }

        public void initialize()
        {
            //map.initialize();
        }
    }
}
