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
    class DestructableBrick : FixedBrick
    {
        private bool exploded = false;
        private double explosionTimer = 1.5;
        private BrickExplosion brickExplosion;
        private int strength;

        public DestructableBrick(Vector2 positionInput, bool initPlaced) : base(positionInput, initPlaced)
        {

            image = Game1.DestructableBrickTextureAtlas;
            type = Game1.random.Next(0,4);
        }

        protected override bool BrickBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {

            if (fixtureB.Body.IsBullet)
            {
                TakeDamage();
            }
            else
            {
                int damage = (int)(fixtureB.Body.LinearVelocity.Length() / 3f);
                TakeDamage(damage);
            }

            return true;
        }

        private void TakeDamage()
        {
            brickStrength--;
            if (!destroyed && brickStrength <= 0)
            {
                
                Explode();
            }
        }

        private void TakeDamage(int damage)
        {
            brickStrength -= damage;
            if (!destroyed && brickStrength <= 0)
            {
                Explode();
            }
        }

        public override void Update()
        {
            if (exploded)
            {
                explosionTimer -= .025f;
                Explode();
            }

        }

        private void Explode()
        {

            if (!exploded)
            {
                exploded = true;
                Game1.world.RemoveBody(this.brickBody);
                brickExplosion = new BrickExplosion(Game1.world, 30f, UnitConverter.toSimSpace(position));
                
            }

            if(explosionTimer <= 0)
            {
                brickExplosion.cleanExplosion();
                destroyed = true;
            }

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            strength = 6 - brickStrength;
            Vector2 sourceTopLeft = new Vector2(strength * brickWidth + strength, type * brickHeight + type);
            Vector2 sourceBottomRight = new Vector2(size.X, size.Y);
            Rectangle sourceRectangle = new Rectangle(sourceTopLeft.ToPoint(), sourceBottomRight.ToPoint());

            if (placed && !exploded)
            {
                position.X = UnitConverter.toPixelSpace(brickBody.Position.X) - size.X / 2;
                position.Y = UnitConverter.toPixelSpace(brickBody.Position.Y) - size.Y / 2;

                spriteBatch.Draw(image, new Rectangle(position.ToPoint(), size.ToPoint()), sourceRectangle, color);
            }
            else if(!exploded)
            {
                spriteBatch.Draw(image, new Rectangle(new Point((int)(position.X - size.X / 2), (int)(position.Y - size.Y / 2)), size.ToPoint()), sourceRectangle, color);
            }

            if (exploded)
            {
                brickExplosion.Draw(spriteBatch);
            }
        }



    }
}
