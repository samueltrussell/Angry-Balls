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
    class Bomb : TBoxItem
    {
        double timer;
        Point timerLocation;
        Point explodeLocation;


        public Bomb(Point positionInput)
        {
            position = positionInput;
            image = Game1.bombImage;
            size = new Point { X = 100, Y = 80 };
            dragable = true;
            timer = 5.0;
            timerLocation = new Point { X = position.X + size.X / 2 - 10, Y = position.Y - size.Y / 2 };
            explodeLocation = position;
        }

        public void update()
        {
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
            
            if(placed && timer > 0)
            {
                spriteBatch.DrawString(Game1.bombTimerFont, (int)timer + "!", new Vector2(timerLocation.X, timerLocation.Y), Color.White);
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

        private void Explode()
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
