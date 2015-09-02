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
    class Bomb : TBoxItem
    {
        double timer;
        Point timerLocation;
        Point explodeLocation;

        //public Body bombBody = BodyFactory.CreateCircle(Game1.world, 5, 5);

        public Bomb(Point positionInput)
        {
            position = positionInput;
            image = Game1.bombImage;
            size = new Point { X = 78, Y = 80 };
            dragable = true;
            timer = 5.0;
            timerLocation = new Point { X = position.X + size.X / 2 + 10, Y = position.Y - 10 };
            explodeLocation = position;

            //initialize body physics parameters

            //bombBody.Position = new Vector2(100f, 100f);// position.Y;
            //bombBody.BodyType = BodyType.Dynamic;
            //bombBody.GravityScale = 1.0f;
            //bombBody.Restitution = 0.2f;
            //bombBody.Friction = 0.0f;
        }

        public void update()
        {
            //position = bombBody.Position.ToPoint();

            if (placed)
            {
                timer -= 0.025;
                timerLocation.X = position.X + size.X / 2 + 10;
                timerLocation.Y = position.Y - 10;
            }

            if (timer <= 0) Explode();

        }
    
        public new void draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(Game1.bombTimerFont, (int)timer + "", new Vector2(timerLocation.X, timerLocation.Y), Color.Teal);

            //Debug physics: print the body position on screen
            //spriteBatch.DrawString(Game1.bombTimerFont, "x = " + (int)bombBody.Position.X + "", new Vector2(timerLocation.X, timerLocation.Y + 75), Color.White);

            if (placed && timer > 0)
            {
                spriteBatch.DrawString(Game1.bombTimerFont, (int)timer + "!", new Vector2(timerLocation.X, timerLocation.Y), Color.Red);
            }
            if(timer >= -2 && timer <= 0)
            {
                spriteBatch.Draw(image, new Rectangle(explodeLocation, size), Color.White);
            }
            else
            {
                spriteBatch.Draw(image, new Rectangle(position, size), Color.White);
            }
        }

        protected new void Placed()
        {
            placed = true;
            //bombBody.BodyType = BodyType.Dynamic;
        }

        protected void Explode()
        {
            if(timer >= -.75)
            {
                explodeLocation = position;
                image = Game1.explodeImage;
                int xShift = Game1.random.Next(6) - 3;
                int yShift = Game1.random.Next(6) - 3;
                explodeLocation.X += xShift;
                explodeLocation.Y += yShift;

            }
            else
            {
                destroyed = true;
            }

        }

    }
}
