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
    class Map
    {
        //We can move background from Enviornment to map, but we don't need to
        //Texture2D backGround;
        //background = Game1.environmentBackground;
        public TBIList TBIList = new TBIList();
        public TBIListDynamic TBIListDynamic = new TBIListDynamic();

        public TBoxItem FindClickedObject(MouseState mouseState)
        {
            foreach(Bomb element in TBIListDynamic.bombList)
            {
                if (element.isClicked(mouseState))
                {
                    return element;
                }
            }
            //to move placed objects in TBIList
            //foreach(Bomb element in TBIListDynamic.bombList)
            //{
              //  if (element.isClicked(mouseState))
                //{
                  //  TBIList.AddRange();
                //}
            //}
            return null;
        }
        //Move from env to map?
        //public void Draw(SpriteBatch spriteBatch)
        //{
          //  Point screenSize = new Point { X = Game1.graphics.PreferredBackBufferWidth, Y = Game1.graphics.PreferredBackBufferHeight };
            //Rectangle screen = new Rectangle(Point.Zero, screenSize);
            //spriteBatch.Draw(background, screen, Color.White);
            //
            //foreach (Bomb element in map.TBIListDynamic.bombList)
            //{
              //  element.draw(spriteBatch);
            //}

        }

    }   
