using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point screenSize = new Point { X = Game1.graphics.PreferredBackBufferWidth, Y = Game1.graphics.PreferredBackBufferHeight };
            Rectangle screen = new Rectangle(Point.Zero, screenSize);
            spriteBatch.Draw(background, screen, Color.White);

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
            }

            //Update objects on the field, if necessary
            map.update();


            //foreach (Bomb element in bombs)
            //{
            //    element.isClicked(mouseState);
            //}

            //foreach (FixedBrick element in fixedBricks)
            //{
            //    element.isClicked(mouseState);
            //}
        }

        public void initialize()
        {
            //map.initialize();
        }



        


    }
}
