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
    class UnitConverter
    {
        private static Point resultPoint;
        private static int pixelsPerMeter = 750;
        

        public static Point ToPixelSpace(Point point)
        {
            resultPoint.X = point.X * pixelsPerMeter;
            resultPoint.Y = point.Y * pixelsPerMeter;

            return resultPoint;        
        }

        public static float ToPixelSpace(float number)
        {
            return number * pixelsPerMeter;
        }
    }
}
