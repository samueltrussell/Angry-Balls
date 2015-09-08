using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace Angry_Balls
{
    class FixedBrickCreator : FixedBrick
    {
        private static Vector2 toolBoxPosition = new Vector2(885, 300);

        public FixedBrickCreator() : base(toolBoxPosition, false)
        {

        }

        public override void Create(Map map)
        {
            FixedBrick newBrick = new FixedBrick(position, false);
            position = toolBoxPosition;
            map.TBIList.FixedBrickList.Add(newBrick);

        }


    }
}
