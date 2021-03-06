﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

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
        private Body mineBody;
        private Explosion mineExplosion;
        private SoundEffectInstance mineSFXInstance;

        public ProxMine(Vector2 positionInput)
        {
            position = positionInput;
            image = Game1.mineImage;
            size = new Vector2 ( 78, 80 );
            dragable = true;
            timer = 0.0;
            explodeLocation = position;
            dragColor = Color.Red;
            mineSFXInstance = Game1.mineExplosion.CreateInstance();
        }

        public void update()
        {
            if (exploded)
            {
                mineSFXInstance.Play();
                Explode();
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (placed && !exploded)//On Map
            {
                position = UnitConverter.toPixelSpace(mineBody.Position);
                spriteBatch.Draw(image, position, null, color, mineBody.Rotation, mineBodyOrigin, 1f, SpriteEffects.None, 0f);
            }
            else if (placed && exploded)//exploding
            {
                mineExplosion.Draw(spriteBatch);
                spriteBatch.Draw(image, new Rectangle(explodeLocation.ToPoint(), size.ToPoint()), color);
            }
            else //Toolbox
            {
                DefaultDraw(spriteBatch);
            }
        }

        public override void Placed()
        {
            placed = true;
            dragable = false;
            Vector2 initPosition = UnitConverter.toSimSpace(position);
            
            //reset color
            color = Color.White;

            //initialize body physics parameters
            mineBody = BodyFactory.CreateCircle(Game1.world, UnitConverter.toSimSpace(radius), 1.0f, initPosition);
            mineBody.OnCollision += MineBody_OnCollision;
            mineBody.BodyType = BodyType.Dynamic;
            mineBody.GravityScale = 1.0f;
            mineBody.Restitution = 0.0f;
            mineBody.Friction = 0.5f;
            mineBody.AngularDamping = 8.5f;
            mineBodyOrigin = new Vector2(image.Width / 2, image.Height / 2);
            
        }

        private bool MineBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            if(fixtureB.Body.BodyType == BodyType.Dynamic)
            {
                if (!destroyed)
                {
                    Explode();
                }
                Vector2 force = fixtureB.Body.Position - fixtureA.Body.Position;
                force *= explosionForce;

                return true;
            }
            else return true;
        }

        protected void Explode()
        {
            //exploded = true;
            if (timer >= -.75)
            {
                explodeLocation = position;
                image = Game1.mineExplodeImage;
                int xShift = Game1.random.Next(6) - 3;
                int yShift = Game1.random.Next(6) - 3;
                explodeLocation.X += xShift;
                explodeLocation.Y += yShift;
                timer -= .025f;

                if (!exploded)
                {
                    Game1.world.RemoveBody(mineBody);
                    mineExplosion = new Explosion(Game1.world, 500f, mineBody.Position);
                    exploded = true;
                }
            }
            else if(!destroyed)
            {
                mineSFXInstance.Stop();
                mineExplosion.cleanExplosion();
                destroyed = true;
            }

        }

    }
}
