using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//These would include toolbox items
namespace Angry_Balls
{
    class TBIListDynamic
    {
        //Only Bombs for now, new ones must be added as we go
        public List<Bomb> bombList = new List<Bomb>();

        Point startPose1 = new Point { X = 150, Y = 150 };
        Point startPose2 = new Point { X = 175, Y = 175 };
        Point startPose3 = new Point { X = 250, Y = 150 };

        //Constructor for initialisation
        public TBIListDynamic()
        {
            bombList.Add(new Bomb(startPose1));
            bombList.Add(new Bomb(startPose2));
            bombList.Add(new Bomb(startPose3));
        }
    }
}
