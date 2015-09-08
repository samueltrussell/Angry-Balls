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
    class PlayPauseButton : TBoxItem
    {
        private bool play = true; //Initialize to run state: Currently Playing, display pause icon
        private bool pause = false; //If currently Paused, display play icon

        private Texture2D pauseImage;

        public PlayPauseButton(AngryBallsEnvironment.GameState gameState)
        {
            image = Game1.playButtonImage;
            pauseImage = Game1.pauseButtonImage;

            //initialize from gameState
            if(gameState == AngryBallsEnvironment.GameState.pause)
            {
                play = false;
                pause = true;
            }
            
            position = new Vector2(75, 75);
            size = new Vector2(75, 75);

            dragable = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeft = new Vector2(position.X - size.X / 2, position.Y - size.Y / 2);

            if(play)
            spriteBatch.Draw(pauseImage, new Rectangle(topLeft.ToPoint(), size.ToPoint()), Color.White);

            else if(pause)
            spriteBatch.Draw(image, new Rectangle(topLeft.ToPoint(), size.ToPoint()), Color.White);

        }

        public void Toggle(ref AngryBallsEnvironment.GameState gameState)
        {

            if (play)
            {
                play = false;
                pause = true;
                gameState = AngryBallsEnvironment.GameState.pause;
            }
            else if (pause)
            {
                play = true;
                pause = false;
                gameState = AngryBallsEnvironment.GameState.run;
            }

        }

    }
}
