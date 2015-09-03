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
            foreach(Bomb element in TBIList.PlacedBomb)
            {
                if (element.isClicked(mouseState))
                {
                    return element;
                }
            }

            foreach (ProxMine element in TBIList.placedMines)
            {
                if (element.isClicked(mouseState))
                {
                    return element;
                }
            }

            foreach (FixedBrick element in TBIList.FixedBrickList)
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

        public void update()
        {
            //update any active Bombs, remove them if they have exploded
            foreach(Bomb element in TBIList.PlacedBomb.Reverse<Bomb>())
            {
                element.update();
                if (element.IsDestroyed())
                {
                    element.RemoveBody();
                    TBIList.PlacedBomb.Remove(element);
                }
            }
            //update any active mines, remove them if they have exploded
            foreach (ProxMine element in TBIList.placedMines.Reverse<ProxMine>())
            {
                element.update();
                if (element.IsDestroyed())
                {
                    TBIList.placedMines.Remove(element);
                    element.RemoveBody();
                }
            }

        }

        }

    }   
