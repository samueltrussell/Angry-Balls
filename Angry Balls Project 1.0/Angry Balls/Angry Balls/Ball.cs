using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angry_Balls
{
    // Ball class is our simplified physics engine used for this game

    class Ball
    {
        private Vector2 gravity = new Vector2(0.0f, 9.81f); // Positive y-values move down
        private Vector2 position;
        private float mass;
        private float time;
        private GameTime gameTime = new GameTime();
        private Texture2D texture;

        // Setters and Getters for position

        public void setPosition(Vector2 pos)
        {
            position.X = pos.X;
            position.Y = pos.Y;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Ball(Texture2D tex)
        {
            position = new Vector2(7.0f, 0.0f);
            mass = 5.0f;
            texture = tex;
        }

        // Compute the force against the ball

        public Vector2 GetForce()
        {
            Vector2 f = new Vector2();

            // The ball was moving too fast, so I slowed it down with the extra factor

            f.X = mass * gravity.X;
            f.Y = mass * gravity.Y;

            return f;
        }

        // Acceleration and velocity methods

        public Vector2 GetAcceleration()
        {
            Vector2 a = new Vector2();
            a = GetForce() / mass;
            return a;
        }

        public Vector2 GetVeclocity()
        {
            time = (float)gameTime.TotalGameTime.Seconds;
            Vector2 v1 = GetAcceleration() * time / 2.0f;

            Vector2 v2 = v1 + GetAcceleration() * time;

            return v2;
        }

        // Finally, update and draw methods

        public void Update()
        {
            position += ((position + GetVeclocity() * time) + GetForce()) * 0.0025f;
        }

        public void Draw(Texture2D texture, SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
