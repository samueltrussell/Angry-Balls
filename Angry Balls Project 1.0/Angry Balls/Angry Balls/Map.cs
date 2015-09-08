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
        private FixedBrickCreator fixedBrickCreator = new FixedBrickCreator();
        private MineCreator mineCreator = new MineCreator();

        public TBoxItem FindClickedObject(MouseState mouseState, AngryBallsEnvironment.GameState gameState)
        {
            // Return Creators if we're in level builder mode
            if (gameState == AngryBallsEnvironment.GameState.levelBuilder)
            {
                if (fixedBrickCreator.isClicked(mouseState))
                {
                    return fixedBrickCreator;
                }

                if (mineCreator.isClicked(mouseState))
                {
                    return mineCreator;
                }
            }

            foreach (Bomb element in TBIList.PlacedBomb)
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

            return null;
        }
        //Move from env to map?
        public void Draw(SpriteBatch spriteBatch, AngryBallsEnvironment.GameState gameState)
        {

            //Draw Item Creators if we're in LevelBuilder mode
            if (gameState == AngryBallsEnvironment.GameState.levelBuilder)
            {
                fixedBrickCreator.draw(spriteBatch);
                mineCreator.draw(spriteBatch);
            }

            //Draw ToolBox Contents
            foreach (Bomb element in TBIList.PlacedBomb)
            {
                element.draw(spriteBatch);
            }
            foreach (ProxMine element in TBIList.placedMines)
            {
                element.draw(spriteBatch);
            }

            foreach (FixedBrick element in TBIList.FixedBrickList)
            {
                element.draw(spriteBatch);
            }
        }

        public void update()
        {
            //update any active Bombs, remove them if they have exploded
            foreach(Bomb element in TBIList.PlacedBomb.Reverse<Bomb>())
            {
                element.update();
                if (element.IsDestroyed())
                {
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
                }
            }
            //Check to see if any bricks have been destroyed, if so, handle it
            foreach(FixedBrick element in TBIList.FixedBrickList.Reverse<FixedBrick>())
            {
                element.Update();
                if (element.IsDestroyed())
                {
                    TBIList.FixedBrickList.Remove(element);
                }
            }

        }

        }

    }   
