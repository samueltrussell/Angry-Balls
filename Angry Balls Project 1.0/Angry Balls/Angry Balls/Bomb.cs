using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace Angry_Balls
{
    class Bomb : TBoxItem
    {
        private double timer;
        private Texture2D explodeImage;
        private Vector2 timerLocation;
        private Vector2 explodeLocation;
        private Vector2 bombBodyOrigin;
        private Vector2 explosionForce = new Vector2(500, 500);
        private Body bombBody;
        private bool exploded = false;
        private int radius = 78 / 2;

        public Bomb(Vector2 positionInput)
        {
            position = positionInput;
            image = Game1.bombImage;
            imageOrigin = new Vector2 (position.X - image.Width / 2, position.Y - image.Height / 2);
            size = new Vector2 ( 78, 80 );
            dragable = true;
            timer = 6.0;
            timerLocation = new Vector2 ( position.X + size.X / 2 + 10,  position.Y - 10 );
            explodeLocation = position;
            explodeImage = Game1.explodeImage;
            color = Color.White;
        }

        public void update()
        {
            if (placed)
            {
                Game1.bombInstance.Play();
                timer -= 0.025;
            }

            if(timer <= -0.55)
            {
                Game1.bombInstance.Stop();
            }

            if (timer <= 1)
            {
                Explode();
            }
        }
    
        public void draw(SpriteBatch spriteBatch)
        {
            timerLocation.X = position.X + size.X / 2 + 10;
            timerLocation.Y = position.Y - 10;

            imageOrigin.X = position.X - image.Width / 2;
            imageOrigin.Y = position.Y - image.Height / 2;

            if (placed && timer > 1)//during countdown
            {
                color = Color.White;
                spriteBatch.DrawString(Game1.bombTimerFont, (int)timer + "!", new Vector2(timerLocation.X, timerLocation.Y), Color.Red);
                position = UnitConverter.toPixelSpace(bombBody.Position);
                spriteBatch.Draw(image, position, null, color, bombBody.Rotation, bombBodyOrigin, 1f, SpriteEffects.None, 0f);
            }
            else if(placed && timer >= -2 && timer <= 1)//while exploding
            {
                spriteBatch.Draw(explodeImage, explodeLocation, null, color, bombBody.Rotation, bombBodyOrigin, 1f, SpriteEffects.None, 0f);
            }
            else //Toolbox & While Dragging
            {
                DefaultDraw(spriteBatch);
            }
        }

        private bool BombBody_OnCollision(Fixture fixtureA, Fixture fixtureB, FarseerPhysics.Dynamics.Contacts.Contact contact)
        {
            if (fixtureB.Body.BodyType == BodyType.Dynamic)
            {
                Explode();
                Vector2 force = fixtureA.Body.Position - fixtureB.Body.Position;
                force *= explosionForce;
                fixtureA.Body.ApplyForce(force);
                return true;
            }
            else return true;
            //throw new NotImplementedException();
        }


        public override void Placed()
        {
            placed = true;
            dragable = false;
            Vector2 initPosition = UnitConverter.toSimSpace(position);

            //initialize body physics parameters
            bombBody = BodyFactory.CreateCircle(Game1.world, UnitConverter.toSimSpace(radius), 1.0f, initPosition);

            bombBody.BodyType = BodyType.Dynamic;
            bombBody.GravityScale = 1.0f;
            bombBody.Restitution = 0.05f;
            bombBody.AngularDamping = 20;
            bombBody.Friction = 0.5f;
            bombBodyOrigin = new Vector2(image.Width / 2, image.Height / 2);
        }

        protected void Explode()
        {
            if(timer >= -.75)
            {
                explodeLocation = position;
                int xShift = Game1.random.Next(6) - 3;
                int yShift = Game1.random.Next(6) - 3;
                explodeLocation.X += xShift;
                explodeLocation.Y += yShift;

                Environment.angryBall.ballBody.ApplyForce(UnitConverter.toSimSpace(-explosionForce));

                bombBody.ApplyAngularImpulse(.20f);

                if (!exploded)
                {
                    Game1.world.RemoveBody(bombBody);
                    exploded = true;
                }
            }
            else
            {
                destroyed = true;
            }

        }




    }
}
