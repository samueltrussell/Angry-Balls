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
        public const float METER_TO_PIXEL = 100.0f;
        public const float PIXEL_TO_METER = 1.0f / METER_TO_PIXEL;

        public const float RADIUS = .75f;

        protected Point position;
        protected Texture2D image;
        protected Point size = new Point { X = 75, Y = 75 };

        //Ball body: .1 m in diameter
        public Body ballBody = BodyFactory.CreateCircle(Game1.world, RADIUS, 5);

        //Draw references
        Point drawUpperLeft;
        Point drawLowerRight;

        public Vector2 metricPosition
        {
            get { return ballBody.Position * METER_TO_PIXEL; }
            set { ballBody.Position = ballBody.Position * PIXEL_TO_METER; }
        }

        public FarseerBall(Point inputPosition)
        {
            position = inputPosition;
            image = Game1.ballImage;

            //initialize body physics parameters
            ballBody.Position = inputPosition.ToVector2();
            ballBody.BodyType = BodyType.Dynamic;
            ballBody.GravityScale = 1.0f;
            ballBody.Restitution = 0.2f;
            ballBody.Friction = 0.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //position = UnitConverter.ToPixelSpace(ballBody.Position.ToPoint());

            position = ballBody.Position.ToPoint();

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
