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

        //Environment Constructor
        public Environment()
        {
            background = Game1.environmentBackground;
            Input = new InputManager();
            map = new Map();
            justClicked = false;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point screenSize = new Point { X = Game1.graphics.PreferredBackBufferWidth, Y = Game1.graphics.PreferredBackBufferHeight };
            Rectangle screen = new Rectangle(Point.Zero, screenSize);
            spriteBatch.Draw(background, screen, Color.White);

            foreach (Bomb element in map.TBIList.bombList)
            {
                element.draw(spriteBatch);
            }
            
        }

        public void update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (justClicked == false)
                {
                    selectedObject = map.FindClickedObject(mouseState);
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


            //foreach (Bomb element in bombs)
            //{
            //    element.isClicked(mouseState);
            //}

            //foreach (FixedBrick element in fixedBricks)
            //{
            //    element.isClicked(mouseState);
            //}
        }



        


    }
}
