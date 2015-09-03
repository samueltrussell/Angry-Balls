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
        private static Vector2 resultVector;
        private static float pixelsPerMeter = 100f;
        private static float MetersPerPixel = 1f / pixelsPerMeter;
        

        public static Vector2 toPixelSpace(Vector2 point)
        {
            resultVector.X = point.X * (int)pixelsPerMeter;
            resultVector.Y = point.Y * (int)pixelsPerMeter;

            return resultVector;        
        }

        public static int toPixelSpace(float value)
        {
            float result = value * pixelsPerMeter;
            return (int) result;
        }

        public static Vector2 toSimSpace(Vector2 point)
        {
            resultVector.X = point.X * MetersPerPixel;
            resultVector.Y = point.Y * MetersPerPixel;

            return resultVector;
        }

        public static float toSimSpace(int value)
        {
            float result = value * MetersPerPixel;
            return result;
        }

    }
}
