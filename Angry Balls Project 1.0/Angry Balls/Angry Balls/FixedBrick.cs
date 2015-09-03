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
    class FixedBrick : TBoxItem
    {
        int brickHeight = 45;
        int brickWidth = 85;

        Body brickBody;

        //public Body brickBody = BodyFactory.CreateRectangle(Game1.world, )

        public FixedBrick(Point positionInput)
        {
            position = positionInput;
            image = Game1.brickTextureAtlas;
            size = new Point { X = brickWidth, Y = brickHeight};
            dragable = false;
            brickBody = BodyFactory.CreateBody(Game1.world);
            brickBody.BodyType = BodyType.Static;
            brickBody.IgnoreGravity = true;
            brickBody.Restitution = 2.0f;
        }

        new public void draw(SpriteBatch spriteBatch)
        {

            Point sourceTopLeft = new Point { X = 0, Y = 0 };
            Point sourceBottomRight = new Point { X = size.X, Y = size.Y };
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft, sourceBottomRight);

            spriteBatch.Draw(image, new Rectangle(position, size), sourceRectangle, Color.White);
        }

        new public void PhysicsCollisionActions()
        {
            Vector2 force = new Vector2(Environment.angryBall.ballBody.Position.X * 2.0f, -Environment.angryBall.ballBody.Position.Y);

            if(Environment.angryBall.ballBody.Position.Y >= position.Y)
            {
                Environment.angryBall.ballBody.ApplyForce(force);
            }
        }
    }
}