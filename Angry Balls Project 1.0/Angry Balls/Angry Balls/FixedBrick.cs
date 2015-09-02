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

        //public Body brickBody = BodyFactory.CreateRectangle(Game1.world, )

        public FixedBrick(Point positionInput)
        {
            position = positionInput;
            image = Game1.brickTextureAtlas;
            size = new Point { X = brickWidth, Y = brickHeight};
            dragable = false;
        }

        new public void draw(SpriteBatch spriteBatch)
        {


            Point sourceTopLeft = new Point { X = 0, Y = 0 };
            Point sourceBottomRight = new Point { X = size.X, Y = size.Y };
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft, sourceBottomRight);

            spriteBatch.Draw(image, new Rectangle(position, size), sourceRectangle, Color.White);
        }
    }
}