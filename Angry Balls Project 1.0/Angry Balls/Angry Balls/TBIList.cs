using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//New Lists need to be added for new ToolBox Items
namespace Angry_Balls
{
    class TBIList
    {
        public List<FixedBrick> FixedBrickList = new List<FixedBrick>();
        public List<BombPlaced> PlacedBomb = new List<BombPlaced>();
        public BombPlaced added;
        //Positions will change according to levels
        Point startPose4 = new Point { X = 150, Y = 200 };
        Point startPose5 = new Point { X = 175, Y = 225 };
        Point startPose6 = new Point { X = 250, Y = 250 };


        //Initialisation for new lists must also be done here in the constructor
        public TBIList()
        {
            //Took dynamic items into another class
            FixedBrickList.Add(new FixedBrick(startPose4));
            FixedBrickList.Add(new FixedBrick(startPose5));
            FixedBrickList.Add(new FixedBrick(startPose6));
        }
        //Need help with this
        //public void AddRange(BombPlaced.added)
        //{
          //  PlacedBomb.Add("added");
        //}

        public class BombPlaced
        {
            public List<BombPlaced> PlacedBomb = new List<BombPlaced>();
        }

    }
}
