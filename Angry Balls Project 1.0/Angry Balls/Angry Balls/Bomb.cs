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

        public Bomb(Point positionInput)
        {
            position = positionInput;
            image = Game1.bombImage;
            size = new Point { X = 100, Y = 80 };
        }
    }
}
