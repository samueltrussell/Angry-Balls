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
        protected int brickHeight = 45; //Px
        protected int brickWidth = 85; //Px

        Body brickBody;


        public FixedBrick(Vector2 positionInput)
        {
            position = positionInput;
            image = Game1.brickTextureAtlas;
            size = new Vector2 { X = brickWidth, Y = brickHeight};
            dragable = false;
            brickBody = BodyFactory.CreateRectangle(Game1.world,UnitConverter.toSimSpace(brickWidth), UnitConverter.toSimSpace(brickHeight), 1.0f, UnitConverter.toSimSpace(positionInput));
            brickBody.BodyType = BodyType.Static;
            brickBody.Friction = 0.5f;
        }

        new public void draw(SpriteBatch spriteBatch)
        {

            Vector2 sourceTopLeft = new Vector2 ( 0, 0 );
            Vector2 sourceBottomRight = new Vector2 ( size.X, size.Y );
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft.ToPoint(), sourceBottomRight.ToPoint());

            position.X = UnitConverter.toPixelSpace(brickBody.Position.X) - size.X/2;
            position.Y = UnitConverter.toPixelSpace(brickBody.Position.Y) - size.Y/2;
            spriteBatch.Draw(image, new Rectangle(position.ToPoint(), size.ToPoint()), sourceRectangle, Color.White);
        }
    }
}