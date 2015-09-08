using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Angry_Balls
{
    public class Level
    {
        public int[,] Values { get; set; }

        public Level(int[,] values)
        {
            Values = values;
        }

        public int GetValue(int row, int column)
        {
            return Values[row, column];
        }

        public int Rows
        {
            get
            {
                return Values.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return Values.GetLength(1);
            }
        }
    }
}
