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
        protected bool TBIJustClicked = true;
        protected bool buttonJustClicked = true;
        protected TBoxItem selectedObject;

        public InputManager()
        {
        }

        public void Update(TBoxItem item)
        {
            // On initial click only, get selected object back from the Map class
            //if (justClicked == true)
            //{
            //    justClicked = false;
            //}

            MouseState mouseState = Mouse.GetState();

            // once we have a selected object, update the object as appropriate position using the mouse

            Vector2 newPosition = new Vector2(mouseState.X, mouseState.Y);
            item.PositionUpdate(newPosition);
        }

        public bool JustClicked()
        {
            return TBIJustClicked;
        }

        public void reset()
        {
            TBIJustClicked = true;
        }

        public void HandleButtons(Map map, PlayPauseButton playPauseButton, MouseState mouseState, ref AngryBallsEnvironment.GameState gameState)
        {
            if (buttonJustClicked)
            {
                if (playPauseButton.isClicked(mouseState))
                {
                    playPauseButton.Toggle(ref gameState);
                    buttonJustClicked = false;
                }
            }

            if (mouseState.LeftButton != ButtonState.Pressed && buttonJustClicked == false)
            {
                buttonJustClicked = true;
            }
        }

        public void HandleDragAndDrop(Map map, MouseState mouseState, AngryBallsEnvironment.GameState gameState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (TBIJustClicked == true)
                {
                    selectedObject = map.FindClickedObject(mouseState, gameState);
                    TBIJustClicked = false;
                }

                if (selectedObject != null)
                {
                    Update(selectedObject);
                }
            }

            else if (mouseState.LeftButton != ButtonState.Pressed && TBIJustClicked == false)
            {
                TBIJustClicked = true;
                if (selectedObject != null)
                {
                    if (gameState == AngryBallsEnvironment.GameState.levelBuilder)
                    {
                        selectedObject.Create(map);
                    }
                    else
                    {
                        selectedObject.Placed();
                    }

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
