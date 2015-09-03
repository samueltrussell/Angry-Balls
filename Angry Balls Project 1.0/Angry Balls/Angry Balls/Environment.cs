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

        public InputManager Input;
        public Map map;
        public TBoxItem selectedObject;
        protected bool justClicked;
        public ToolBox toolBox;
        public static FarseerBall angryBall;    // Made static so I could reference from TBoxItem Class

        //Border Bodies for the Physics Engine
        public Body leftWall;
        public Body rightWall;
        public Body floor;
        public Body ceiling;

        Vector2 leftWallPosition = UnitConverter.toSimSpace(new Vector2(-5, 640));
        Vector2 rightWallPosition = UnitConverter.toSimSpace(new Vector2(815, 640));
        Vector2 ceilingPosition = UnitConverter.toSimSpace(new Vector2(480, -640));
        Vector2 floorPosition = UnitConverter.toSimSpace(new Vector2(480, 1360));

        protected Vector2 ballStartPose = new Vector2(150, 150);

        public enum GameState { run, pause, initialize };
        public GameState gameState;

        //Environment Constructor
        public Environment()
        {
            background = Game1.environmentBackground;
            Input = new InputManager();
            map = new Map();
            justClicked = false;
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

            //Draw the Ball
            angryBall.Draw(spriteBatch);

            //Draw Fixed Bricks (draw Map)
            foreach (FixedBrick element in map.TBIList.FixedBrickList)
            {
                element.draw(spriteBatch);
            }
     
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

            //map.draw();

        }

        public void update()
        {
            //Handle Mouse Input for drag and drop
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (justClicked == false)
                {
                    selectedObject = map.FindClickedObject(mouseState);
                    //selectedObject = map.FindClickedButton(mouseState);
                    justClicked = true;
                }
                
                if (selectedObject != null)
                {
                    Input.Update(selectedObject);
                }
                
            }

            else if(mouseState.LeftButton != ButtonState.Pressed && justClicked == true)
            {
                justClicked = false;
                if(selectedObject != null)
                {
                    selectedObject.Placed();
                }
                
            }

            //Update objects on the field, if necessary
            map.update();
        }

        public void initialize()
        {
            //map.initialize();
        }



        


    }
}
