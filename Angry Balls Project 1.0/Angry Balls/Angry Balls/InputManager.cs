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
    class InputManager
    {
        protected bool justClicked;

        public InputManager()
        {
            justClicked = true;
        }
        
        public void Update(TBoxItem item)
        {
            // On initial click only, get selected object back from the Map class
            if (justClicked == true)
            {
                justClicked = false;
            }

            MouseState mouseState = Mouse.GetState();

            // once we have a selected object, update the object as appropriate position using the mouse
            if (item.isDragable())
            {
                Vector2 newPosition = new Vector2 (mouseState.X, mouseState.Y );
                item.PostionUpdate(newPosition);
            }
        }

        public bool JustClicked()
        {
            return justClicked;
        }

        public void reset()
        {
            justClicked = true;
        }


    }
}
