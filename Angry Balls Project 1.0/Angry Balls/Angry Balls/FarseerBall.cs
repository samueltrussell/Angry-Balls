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
        public const float METER_TO_PIXEL = 750.0f;
        public const float PIXEL_TO_METER = 1.0f / METER_TO_PIXEL;

        public const int RADIUS = 75/2; //input Radius in pixel Space 50px

        protected Vector2 position;//Position is maintained in sim space
        protected Texture2D image;
        protected Point size = new Point { X = 75, Y = 75 };

        //Ball body: .1 m in diameter
        public Body ballBody;

        //Draw references
        Point drawUpperLeft;
        Point drawLowerRight;

        public Vector2 metricPosition
        {
            get { return ballBody.Position * METER_TO_PIXEL; }
            set { ballBody.Position = ballBody.Position * PIXEL_TO_METER; }
        }

        public FarseerBall(Vector2 inputPosition)
        {
            position = inputPosition;
            image = Game1.ballImage;

            //initialize body physics parameters
            UnitConverter.toSimSpace(inputPosition);
            ballBody = BodyFactory.CreateCircle(Game1.world, UnitConverter.toSimSpace(RADIUS), 1.0f, UnitConverter.toSimSpace(inputPosition), 5);
            
            //don't move ball
            ballBody.BodyType = BodyType.Dynamic;
            //move ball
            //ballBody.BodyType = BodyType.Dynamic;

            ballBody.GravityScale = 1.0f;
            ballBody.Restitution = 0.95f;
            ballBody.Friction = 0.0f;
            ballBody.GravityScale = .15f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //position = UnitConverter.ToPixelSpace(ballBody.Position.ToPoint());

            position = ballBody.Position;

            //Debug physics: print the body position on screen
            //spriteBatch.DrawString(Game1.bombTimerFont, "y = " + (int)ballBody.Position.Y, new Vector2(position.X, position.Y + size.Y/2), Color.White);

            drawUpperLeft.X = UnitConverter.toPixelSpace(position.X) - (size.X / 2);
            drawUpperLeft.Y = UnitConverter.toPixelSpace(position.Y) - (size.Y / 2);
            drawLowerRight.X = UnitConverter.toPixelSpace(position.X) + size.X / 2;
            drawLowerRight.Y = UnitConverter.toPixelSpace(position.Y) + size.Y / 2;

            spriteBatch.Draw(image, new Rectangle(drawUpperLeft, size), Color.White);
           
        }
    }
}
