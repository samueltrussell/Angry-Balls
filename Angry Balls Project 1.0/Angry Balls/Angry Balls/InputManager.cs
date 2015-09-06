using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;

namespace Angry_Balls
{
    class InputManager
    {
        protected bool justClicked;

        public InputManager()
        {
            justClicked = false;
        }

        public void Update(TBoxItem item)
        {
            // On initial click only, get selected object back from the Map class
            if (justClicked == true)
            {
                item.color = Color.Red;
                justClicked = false;
            }

            MouseState mouseState = Mouse.GetState();

            // once we have a selected object, update the object as appropriate position using the mouse

            Vector2 newPosition = new Vector2(mouseState.X, mouseState.Y);
            item.PositionUpdate(newPosition);
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
