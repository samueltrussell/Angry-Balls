using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;

namespace Angry_Balls
{
    class MineCreator : ProxMine
    {
        private static Vector2 toolBoxPosition = new Vector2(885, 200);

        public MineCreator() : base(toolBoxPosition)
        {

        }

        public override void Create(Map map)
        {
            ProxMine newMine = new ProxMine(position);
            position = toolBoxPosition;
            map.TBIList.placedMines.Add(newMine);

        }

    }
}
