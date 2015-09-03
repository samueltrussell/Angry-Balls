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
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;   


namespace Angry_Balls
{
    class ProxMine : TBoxItem
    {
        double timer;
        Vector2 explodeLocation;
        private bool exploded = false;
        private float explosionForce = 1500f;
        private int radius = 78 / 2;
        private Vector2 mineBodyOrigin;
        public Body mineBody;

        public ProxMine(Vector2 positionInput)
        {
            position = positionInput;
            image = Game1.mineImage;
            size = new Vector2 ( 78, 80 );
            dragable = true;
            timer = 0.0;
            explodeLocation = position;
            
        }

        public void update()
        {
            if (exploded) Explode();
        }

        public new void draw(SpriteBatch spriteBatch)
        {
            //Debug physics: print the body position on screen
            //spriteBatch.DrawString(Game1.bombTimerFont, "x = " + (int)bombBody.Position.X + "", new Vector2(timerLocation.X, timerLocation.Y + 75), Color.White);
            if (placed == true)
            {
                position = UnitConverter.toPixelSpace(mineBody.Position);
                //position.X -= size.X / 2;
                //position.Y -= size.Y / 2;
                spriteBatch.Draw(image, position, null, Color.White, mineBody.Rotation, mineBodyOrigin, 1f, SpriteEffects.None, 0f);
            }
            else if (timer >= -2 && timer < 0)
            {
                spriteBatch.Draw(image, new Rectangle(explodeLocation.ToPoint(), size.ToPoint()), Color.White);
            }
            else
            {
                spriteBatch.Draw(image, position, null, Color.White);
                //new Rectangle(position.ToPoint(), size.ToPoint())
            }
        }

        public override void Placed()
        {
            placed = true;
            dragable = false;
            Vector2 initPosition = UnitConverter.toSimSpace(new Vector2(position.X + size.X/2, position.Y + size.Y/2));

            //initialize body physics parameters
            mineBody = BodyFactory.CreateCircle(Game1.world, UnitConverter.toSimSpace(radius), 1.0f, initPosition);
            mineBody.OnCollision += MineBody_OnCollision;
            mineBody.BodyType = BodyType.Dynamic;
            mineBody.GravityScale = 1.0f;
            mineBody.Restitution = .0f;
            mineBody.Friction = 0.5f;
            mineBody.AngularDamping = 8.5f;
            mineBodyOrigin = new Vector2(image.Width / 2, image.Height / 2);
            
        }

        private bool MineBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            if(fixtureB.Body.BodyType == BodyType.Dynamic)
            {
                Explode();
                Vector2 force = fixtureB.Body.Position - fixtureA.Body.Position;
                force *= explosionForce;
                fixtureB.Body.ApplyForce(force);
                return true;
            }
            else return true;
            //throw new NotImplementedException();
        }

        protected void Explode()
        {
            exploded = true;
            if (timer >= -.75)
            {
                explodeLocation = position;
                image = Game1.mineExplodeImage;
                int xShift = Game1.random.Next(6) - 3;
                int yShift = Game1.random.Next(6) - 3;
                explodeLocation.X += xShift;
                explodeLocation.Y += yShift;
                timer -= .025f;

            }
            else
            {
                destroyed = true;
            }

        }

        public void RemoveBody()
        {
            Game1.world.RemoveBody(mineBody);
        }

    }
}
