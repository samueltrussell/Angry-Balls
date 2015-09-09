using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Angry_Balls
{
    class BuilderButton : TBoxItem
    {
        private bool build = false;

        public void SetBuild(bool builder)
        {
            build = builder;
        }

        public bool GetState()
        {
            return build;
        }

        public BuilderButton(AngryBallsEnvironment.GameState gameState)
        {
            image = Game1.builderImage;

            if (gameState == AngryBallsEnvironment.GameState.pause || gameState == AngryBallsEnvironment.GameState.levelBuilder)
            {
                build = true;
            }
            position = new Vector2(175, 75);
            size = new Vector2(80, 75);

            dragable = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeft = new Vector2(position.X - size.X / 2, position.Y - size.Y / 2);

            if (build)
                spriteBatch.Draw(image, new Rectangle(topLeft.ToPoint(), size.ToPoint()), Color.White);
        }

        public void Toggle(ref AngryBallsEnvironment.GameState gameState)
        {
            MouseState mouseState = Mouse.GetState();
            if (isClicked(mouseState) && !build)
            {
                gameState = AngryBallsEnvironment.GameState.pause;
            }
            else
            {
                gameState = AngryBallsEnvironment.GameState.levelBuilder;
            }
        }
    }
}
