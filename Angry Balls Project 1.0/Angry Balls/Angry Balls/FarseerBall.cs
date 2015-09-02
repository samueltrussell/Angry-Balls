using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace Angry_Balls
{
    class FarseerBall
    {
        protected Point position;
        protected Texture2D image;
        protected Point size = new Point { X = 75, Y = 75 };
        
        //Ball body: .1 m in diameter
        public Body ballBody = BodyFactory.CreateCircle(Game1.world, 0.1f, 5);

        //Draw references
        Point drawUpperLeft;
        Point drawLowerRight;

        public FarseerBall(Point inputPosition)
        {
            position = inputPosition;
            image = Game1.ballImage;

            //initialize body physics parameters
            ballBody.Position = new Vector2(.75f, .75f);
            ballBody.BodyType = BodyType.Dynamic;
            ballBody.GravityScale = .10f;
            ballBody.Restitution = 0.2f;
            ballBody.Friction = 0.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position = UnitConverter.ToPixelSpace(ballBody.Position.ToPoint());

            //Debug physics: print the body position on screen
            //spriteBatch.DrawString(Game1.bombTimerFont, "y = " + (int)ballBody.Position.Y, new Vector2(position.X, position.Y + size.Y/2), Color.White);

            drawUpperLeft.X = position.X - (size.X / 2);
            drawUpperLeft.Y = position.Y - (size.Y / 2);
            drawLowerRight.X = position.X + size.X / 2;
            drawLowerRight.Y = position.Y + size.Y / 2;

            spriteBatch.Draw(image, new Rectangle(drawUpperLeft, size), Color.White);
        }

    }
}
