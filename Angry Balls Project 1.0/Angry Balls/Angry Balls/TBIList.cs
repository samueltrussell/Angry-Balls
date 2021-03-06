﻿using System;
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

        //ToolBox Start Poses
        Vector2 bombStart = new Vector2 ( 885, 100 );
        Vector2 mineStart = new Vector2 ( 885, 200 );
        Vector2 brickStart = new Vector2( 885, 300 );

        //Positions will change according to levels
        Vector2 startPose4 = new Vector2(0, 400);
        Vector2 startPose5 = new Vector2(85, 450);
        Vector2 startPose6 = new Vector2(170, 500);

        Vector2 startPose7 = new Vector2(255, 550);
        Vector2 startPose8 = new Vector2(340, 600);
        Vector2 startPose9 = new Vector2(425, 650);

        Vector2 startPose10 = new Vector2(510, 700);
        Vector2 startPose11 = new Vector2(595, 700);
        Vector2 startPose12 = new Vector2(680, 700);

        Vector2 startPose13 = new Vector2(765, 850);
        Vector2 startPose14 = new Vector2(765, 900);
        Vector2 startPose15 = new Vector2(765, 950);


        //Initialisation for new lists must also be done here in the constructor
        public TBIList()
        {
            //Took dynamic items into another class
            FixedBrickList.Add(new DestructableBrick(startPose4, true));
            FixedBrickList.Add(new DestructableBrick(startPose5, true));
            FixedBrickList.Add(new DestructableBrick(startPose6, true));

            FixedBrickList.Add(new DestructableBrick(startPose7, true));
            FixedBrickList.Add(new FixedBrick(startPose8, true));
            FixedBrickList.Add(new DestructableBrick(startPose9, true));

            FixedBrickList.Add(new FixedBrick(startPose10, true));
            FixedBrickList.Add(new DestructableBrick(startPose11, true));
            FixedBrickList.Add(new DestructableBrick(startPose12, true));

            FixedBrickList.Add(new FixedBrick(startPose13, true));
            FixedBrickList.Add(new DestructableBrick(startPose14, true));
            FixedBrickList.Add(new FixedBrick(startPose15, true));

            //Add Bombs
            for (int i = 0; i < 10; i ++)
                PlacedBomb.Add(new Bomb(bombStart));
            ////Add Mines
            for (int i = 0; i < 10; i++)
                placedMines.Add(new ProxMine(mineStart));
            //Add Bricks
            for (int i = 0; i < 10; i++)
            {
                FixedBrickList.Add(new FixedBrick(brickStart, false));
            }


        }


    }
}
