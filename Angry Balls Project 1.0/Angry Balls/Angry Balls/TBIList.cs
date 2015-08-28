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
    class TBIList
    {
        public List<Bomb> bombList = new List<Bomb>();
        public List<FixedBrick> FixedBrickList = new List<FixedBrick>();

        Point startPose1 = new Point { X = 150, Y = 150 };
        Point startPose2 = new Point { X = 175, Y = 175 };
        Point startPose3 = new Point { X = 250, Y = 150 };
        Point startPose4 = new Point { X = 150, Y = 200 };
        Point startPose5 = new Point { X = 175, Y = 225 };
        Point startPose6 = new Point { X = 250, Y = 250 };

        public TBIList()
        {
            bombList.Add(new Bomb(startPose1));
            bombList.Add(new Bomb(startPose2));
            bombList.Add(new Bomb(startPose3));

            FixedBrickList.Add(new FixedBrick(startPose4));
            FixedBrickList.Add(new FixedBrick(startPose5));
            FixedBrickList.Add(new FixedBrick(startPose6));

        }

    }
}
