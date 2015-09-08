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
        protected TBoxItem selectedObject;

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

        public void HandleButtons(PlayPauseButton playPauseButton, MouseState mouseState, ref AngryBallsEnvironment.GameState gameState)
        {
            if (justClicked)
            {
                if (playPauseButton.isClicked(mouseState))
                {
                    playPauseButton.Toggle(ref gameState);
                    justClicked = false;
                }
            }

            if (mouseState.LeftButton != ButtonState.Pressed && justClicked == false)
            {
                justClicked = true;
                if (selectedObject != null)
                {
                    selectedObject.Placed();
                }
            }
        }

        public void HandleDragAndDrop(Map map, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (justClicked == true)
                {
                    selectedObject = map.FindClickedObject(mouseState);
                    justClicked = false;
                }

                if (selectedObject != null)
                {
                    Update(selectedObject);
                }
            }

            else if (mouseState.LeftButton != ButtonState.Pressed && justClicked == false)
            {
                justClicked = true;
                if (selectedObject != null)
                {
                    selectedObject.Placed();
                }

            }
        }

        public void HandleKeyboard(FarseerBall angryBall)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Space))
            {
                angryBall.ballBody.ApplyForce(new Vector2(10.0f, -50.0f));
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                System.Environment.Exit(0);
            }
        }
    }
}
