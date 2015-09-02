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
        public List<Bomb> PlacedBomb = new List<Bomb>();
        public List<ProxMine> placedMines = new List<ProxMine>();
        public BombPlaced added;

        //ToolBox Start Poses
        Point bombStart = new Point { X = 845, Y = 65 };
        Point mineStart = new Point { X = 845, Y = 175 };

        //Positions will change according to levels
        Point startPose4 = new Point { X = 0, Y = 400 };
        Point startPose5 = new Point { X = 85, Y = 400 };
        Point startPose6 = new Point { X = 170, Y = 400 };

        Point startPose7 = new Point { X = 255, Y = 400 };
        Point startPose8 = new Point { X = 340, Y = 400 };
        Point startPose9 = new Point { X = 425, Y = 400 };

        Point startPose10 = new Point { X = 510, Y = 400 };
        Point startPose11 = new Point { X = 595, Y = 400 };
        Point startPose12 = new Point { X = 680, Y = 400 };

        Point startPose13 = new Point { X = 765, Y = 400 };
        Point startPose14 = new Point { X = 750, Y = 400 };
        Point startPose15 = new Point { X = 825, Y = 400 };


        //Initialisation for new lists must also be done here in the constructor
        public TBIList()
        {
            //Took dynamic items into another class
            FixedBrickList.Add(new FixedBrick(startPose4));
            FixedBrickList.Add(new FixedBrick(startPose5));
            FixedBrickList.Add(new FixedBrick(startPose6));

            FixedBrickList.Add(new FixedBrick(startPose7));
            FixedBrickList.Add(new FixedBrick(startPose8));
            FixedBrickList.Add(new FixedBrick(startPose9));

            FixedBrickList.Add(new FixedBrick(startPose10));
            FixedBrickList.Add(new FixedBrick(startPose11));
            FixedBrickList.Add(new FixedBrick(startPose12));

            FixedBrickList.Add(new FixedBrick(startPose13));
            //FixedBrickList.Add(new FixedBrick(startPose14));
            //FixedBrickList.Add(new FixedBrick(startPose15));

            //Add Bombs
            for(int i = 0; i < 3; i ++)
                PlacedBomb.Add(new Bomb(bombStart));
            //Add Mines
            for(int i = 0; i < 3; i++)
                placedMines.Add(new ProxMine(mineStart));


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
