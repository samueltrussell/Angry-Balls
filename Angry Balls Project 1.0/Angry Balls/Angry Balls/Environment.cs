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
    class AngryBallsEnvironment
    {
        Texture2D background;
        Texture2D border;
        Texture2D bigCog;
        Texture2D clawOpen;
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

        private Vector2 bigCogPosition = UnitConverter.toSimSpace(new Vector2(1200, 760));
        private Vector2 clawopenPosition = UnitConverter.toSimSpace(new Vector2(480, 100));

        //Play Controls
        private PlayPauseButton playPauseButton;

        protected Vector2 ballStartPose = new Vector2(150, 150);

        public enum GameState { run, pause, initialize, levelBuilder };
        public GameState gameState;

        //Environment Constructor
        public AngryBallsEnvironment()
        {
            //Initialize the Buttons
            playPauseButton = new PlayPauseButton(gameState);

            background = Game1.environmentBackground;
            border = Game1.borderImage;
            bigCog = Game1.bigCog;
            clawOpen = Game1.clawOpen;
            Input = new InputManager();
            map = new Map();
            //justClicked = false;
            toolBox = new ToolBox();
            gameState = GameState.run;
            angryBall = new FarseerBall(ballStartPose);

            //Physics Bodies for Walls
            leftWall = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(10), UnitConverter.toSimSpace(2450), 1.0f, leftWallPosition);
            leftWall.BodyType = BodyType.Static;
            rightWall = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(10), UnitConverter.toSimSpace(2550), 1.0f, rightWallPosition);
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
            spriteBatch.Draw(border, screen, Color.White);
            //positions are not being specified?
            spriteBatch.Draw(clawOpen, clawopenPosition, Color.White);
            spriteBatch.Draw(bigCog, bigCogPosition, Color.White);

            //Draw the control Buttons
            playPauseButton.Draw(spriteBatch);

            //Draw the Ball
            angryBall.Draw(spriteBatch);

            //Draw ToolBox
            if (toolBox.Show()) toolBox.draw(spriteBatch);

            //Draw Items from the map
            map.Draw(spriteBatch, gameState);

        }

        public void update()
        {
            //Handle Inputs
            MouseState mouseState = Mouse.GetState();
            Input.HandleButtons(map, playPauseButton, mouseState, ref gameState);

            Input.HandleDragAndDrop(map, mouseState, gameState); //handle the drag and drop
            
            Input.HandleKeyboard(angryBall);//Handle Keyboard inputs

            //Update the map objects
            map.update();

        }

        public void initialize()
        {
            //map.initialize();
        }
    }
}
