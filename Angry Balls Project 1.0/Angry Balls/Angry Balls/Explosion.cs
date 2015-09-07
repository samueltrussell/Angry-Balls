using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Angry_Balls
{
    class Explosion
    {
        private int numParticles = 30;
        private double angularSpacing; //degrees between particles
        private static int radius = 5; //particle body radius in pixel space
        private double xVel, yVel;
        private List<Body> particleList;
        private World destructorWorld; //for use in the destructor

        //draw info
        private Texture2D particleImage;
        private Vector2 size = new Vector2((float)radius, (float)radius);

        public Explosion(World world, float intensity, Vector2 position) //position denotes location IN SIM SPACE
        {
            particleList = new List<Body>();
            destructorWorld = world;
            particleImage = Game1.bombImage;

            for (int i = 0; i < numParticles; i++)
            {
                //Convert to Radians for Math's sake:
                angularSpacing = 2 * Math.PI / numParticles;

                //initialize the particle
                Body particle = BodyFactory.CreateCircle(world, UnitConverter.toSimSpace(radius), 20.0f, position);
                particle.BodyType = BodyType.Dynamic;
                particle.FixedRotation = true;
                particle.IsBullet = true;
                particle.LinearDamping = 15f;
                particle.GravityScale = 0f;
                particle.Friction = 0;
                particle.Restitution = .99f;
                particle.CollisionGroup = -1;
                
                //compute the impulse and send the particle on its merry way
                xVel = UnitConverter.toSimSpace((int)(10*intensity * Math.Cos(i * angularSpacing)));
                yVel = UnitConverter.toSimSpace((int)(10*intensity * Math.Sin(i * angularSpacing)));
                particle.LinearVelocity = new Vector2((float)xVel, (float)yVel);

                //Add each particle to a List for summary destruction after explosion
                particleList.Add(particle);
            }
            
        }//End Constructor

        public void cleanExplosion()
        {
            foreach (Body element in particleList)
            {
                destructorWorld.RemoveBody(element);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (particleList.Count != 0)
            {
                foreach (Body element in particleList)
                {
                    Vector2 topLeft = new Vector2(UnitConverter.toPixelSpace(element.Position.X), UnitConverter.toPixelSpace(element.Position.Y));
                    spriteBatch.Draw(particleImage, new Rectangle(topLeft.ToPoint(), size.ToPoint()), Color.White);
                    
                }
            }

        }

    }
}
