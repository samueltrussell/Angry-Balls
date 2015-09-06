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

    class TBoxItem
    {
        public Texture2D image;
        public Vector2 position; //[x,y] position in pixel space for tracking, physics, and rendering
        public Vector2 size; // [width, height] Size of the representatvie image in pixel space 
        protected Vector2 imageOrigin;
        protected bool dragable = false;
        public bool placed = false;
        protected bool destroyed = false;

        public Color color;

        //Base class constructor, SHOULD be overloaded by each derived TBI
        public TBoxItem()
        {

        }

        //default draw function draws the base image, centered at the current position
        //call default Draw from a Draw function in each derived class
        public void DefaultDraw(SpriteBatch spriteBatch) 
        {
            Vector2 topLeft = new Vector2 (position.X - image.Width / 2, position.Y - image.Height / 2);
            size = new Vector2 (image.Width, image.Height);
            spriteBatch.Draw(image, new Rectangle(topLeft.ToPoint(),size.ToPoint()), color);
        }

        //passed a new position vector, updates position
        public void PositionUpdate(Vector2 newPosition) 
        {
            position = newPosition;
        }

        //function to handle drag and drop position updates, send it a MouseState... it'll handle the rest
        //refactor this for mobile platforms
        public bool isClicked(MouseState mouseState) 
        {
            if (mouseState.LeftButton == ButtonState.Pressed &&
                mouseState.X > position.X - image.Width / 2 && mouseState.X < position.X + image.Width / 2 &&
                mouseState.Y > position.Y - image.Height / 2 && mouseState.Y < position.Y + image.Height / 2 &&
                isDragable())
            {
                return true;
            }
            else
            {
                return false;
            }
                       
        }

        public bool isDragable()
        {
            return dragable;
        }

        public virtual void Placed()
        {

        }

        public bool IsDestroyed()
        {
            return destroyed;
        }
    }
}
