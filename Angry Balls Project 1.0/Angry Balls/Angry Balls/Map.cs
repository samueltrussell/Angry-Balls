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
        public TBIList TBIList = new TBIList();

        public TBoxItem FindClickedObject(MouseState mouseState)
        {
            foreach(Bomb element in TBIList.bombList)
            {
                if (element.isClicked(mouseState))
                {
                    return element;
                }
            }

            return null;
        }

    }         
}
