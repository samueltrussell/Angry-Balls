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
        protected int brickStrength = 6;
        protected int type;
        protected Body brickBody;

        public FixedBrick(Vector2 positionInput, bool initPlaced)
        {
            position = positionInput;
            image = Game1.FixedBrickTextureAtlas;
            size = new Vector2 { X = brickWidth, Y = brickHeight};
            dragable = true;
            placed = initPlaced;
            if (placed) { Placed(); }
            dragColor = Color.White;
            type = Game1.random.Next(0, 10);
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            Vector2 sourceTopLeft = new Vector2 ( 0, type * brickHeight + type);
            Vector2 sourceBottomRight = new Vector2 ( size.X, size.Y );
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft.ToPoint(), sourceBottomRight.ToPoint());

            if(placed)
            {
                position.X = UnitConverter.toPixelSpace(brickBody.Position.X) - size.X / 2;
                position.Y = UnitConverter.toPixelSpace(brickBody.Position.Y) - size.Y / 2;

                spriteBatch.Draw(image, new Rectangle(position.ToPoint(), size.ToPoint()), sourceRectangle, color);
            }
            else
            {
                spriteBatch.Draw(image, new Rectangle(new Point((int)(position.X - size.X / 2), (int)(position.Y - size.Y / 2)), size.ToPoint()), sourceRectangle, color);
            }
        }

        public override void Placed()
        {
            placed = true;
            dragable = false;
            
            //reset color
            color = Color.White;

            //initialize body physics parameters
            brickBody = BodyFactory.CreateRectangle(Game1.world, UnitConverter.toSimSpace(brickWidth), UnitConverter.toSimSpace(brickHeight), 1.0f, UnitConverter.toSimSpace(position));
            brickBody.BodyType = BodyType.Static;
            brickBody.OnCollision += BrickBody_OnCollision;
            brickBody.Restitution = 0.1f;
            brickBody.AngularDamping = 20;
            brickBody.Friction = 0.5f;
        }

        public virtual void Update()
        {

        }

        protected virtual bool BrickBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {

            return true;
        }

    }
}