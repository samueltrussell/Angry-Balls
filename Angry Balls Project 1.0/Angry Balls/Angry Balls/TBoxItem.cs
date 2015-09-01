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
        protected Point position; //[x,y] position in pixel space for tracking, physics, and rendering
        protected Point size; // [width, height] Size of the representatvie image in pixel space 
        protected Texture2D image;
        protected bool dragable;
        protected bool placed = false;
        protected bool destroyed = false;


        //Base class constructor, SHOULD be overloaded by each derived TBI
        public TBoxItem()
        {

        }

        //draw function adds the object to the parameter spritebatch
        public void draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(image, new Rectangle(position,size), Color.White);
        }

        public void MapCollisionActions()
        {

        }

        public void PhysicsCollisionActions()
        {

        }

        //passed a new position vector, updates position
        public void PostionUpdate(Point newPosition) 
        {
            newPosition.X -= size.X / 2;
            newPosition.Y -= size.Y / 2;
            position = newPosition;

        }

        //function to handle drag and drop position updates, send it a MouseState... it'll handle the rest
        //refactor this for mobile platforms
        public bool isClicked(MouseState mouseState) 
        {
            if (mouseState.LeftButton == ButtonState.Pressed &&
                mouseState.X > position.X && mouseState.X < position.X + size.X &&
                mouseState.Y > position.Y && mouseState.Y < position.Y + size.Y)
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

        public void Placed()
        {
            placed = true;
        }

        public bool IsDestroyed()
        {
            return destroyed;
        }
    }
}
