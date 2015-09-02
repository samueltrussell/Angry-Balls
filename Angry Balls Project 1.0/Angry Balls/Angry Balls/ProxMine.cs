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
    class ProxMine : TBoxItem
    {
        double timer;
        Point timerLocation;
        Point explodeLocation;

        //public Body mineBody = BodyFactory.CreateCircle(Game1.world, 5, 5);

        public ProxMine(Point positionInput)
        {
            position = positionInput;
            image = Game1.mineImage;
            size = new Point { X = 78, Y = 80 };
            dragable = true;
            timer = 5.0;
            timerLocation = new Point { X = position.X + size.X / 2 - 10, Y = position.Y - size.Y / 4 - 5 };
            explodeLocation = position;

            //initialize body physics parameters
            //mineBody.Position = new Vector2(100f, 100f);// position.Y;
            //mineBody.BodyType = BodyType.Dynamic;
            //mineBody.GravityScale = 1.0f;
            //mineBody.Restitution = 0.2f;
            //mineBody.Friction = 0.0f;
        }

        public void update()
        {
            //position = bombBody.Position.ToPoint();

            if (placed)
            {
                timer -= 0.025;
                timerLocation.X = position.X + size.X / 2 - 10;
                timerLocation.Y = position.Y - size.Y / 4 - 5;
            }

            if (timer <= 0) Explode();

        }

        public new void draw(SpriteBatch spriteBatch)
        {
            //Debug physics: print the body position on screen
            //spriteBatch.DrawString(Game1.bombTimerFont, "x = " + (int)bombBody.Position.X + "", new Vector2(timerLocation.X, timerLocation.Y + 75), Color.White);

            if (timer >= -2 && timer <= 0)
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
            if (timer >= -.75)
            {
                explodeLocation = position;
                image = Game1.mineExplodeImage;
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
