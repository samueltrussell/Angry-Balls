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
    class FixedBrick : TBoxItem
    {
        int brickHeight = 35;
        int brickWidth = 69;
        
        public FixedBrick(Point positionInput)
        {
            position = positionInput;
            image = Game1.brickTextureAtlas;
            size = new Point { X = brickWidth, Y = brickHeight};
        }

        new public void draw(SpriteBatch spriteBatch)
        {


            Point sourceTopLeft = new Point { X = 0, Y = 110 };
            Point sourceBottomRight = new Point { X = size.X, Y = size.Y };
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft, sourceBottomRight);

            spriteBatch.Draw(image, new Rectangle(position, size), sourceRectangle, Color.White);
        }
    }
}