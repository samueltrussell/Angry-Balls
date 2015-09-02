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
    class ToolBox
    {
        Texture2D backGround;
        Point size;
        Point position;
        bool showToolBox;

        public ToolBox()
        {
            backGround = Game1.toolBoxBackGround;
            size = new Point { X = 150, Y = 1280 };
            position = new Point { X = 810, Y = 0 };
            showToolBox = true;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, new Rectangle(position, size), Color.White);
        }
        
        public bool Show()
        {
            return showToolBox;
        }

    }
}
