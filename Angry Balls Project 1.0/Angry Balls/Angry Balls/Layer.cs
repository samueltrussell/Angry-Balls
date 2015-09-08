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
    public class Layer
    {
        public class TileMap
        {
            [XmlElement("Row")]
            public List<string> Row;
        }
        Vector2 tileDimensions;
        List<List<Vector2>> tileMap;
        public TileMap TileLayout;
        public Image image;
        public Layer()
        {
            tileDimensions = new Vector2();
            tileMap = new List<List<Vector2>>();
        }

        // initializing content for the level editing layers
        public void Initialize(ContentManager content, Vector2 tileDimesnions)
        {
            foreach (string row in TileLayout.Row)
            {
                string[] split = row.Split(']');
                List<Vector2> tempTileMap = new List<Vector2>();
                foreach (string s in split)
                {
                    int value2;
                    int value1;
                    if (s != String.Empty && !s.Contains('x'))
                    {
                        string str = s.Replace("[", string.Empty);
                        value1 = int.Parse(str.Substring(0, str.IndexOf(':')));
                        value2 = int.Parse(str.Substring(str.IndexOf(':') + 1));
                    }
                    else
                        value1 = value2 = -1; 

                    tempTileMap.Add(new Vector2(value1, value2));
                }
                tileMap.Add(tempTileMap);
            }
            image.Intialize(content);
        }
        // drawing one layer over another for dragable objects
        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i< tileMap.Count; i++)
            {
                for (int j = 0; j < tileMap[i].Count; j++)
                {
                    if (tileMap[i][j] != -Vector2.One)
                    {
                        image.Position = new Vector2(j * tileDimensions.X, i * tileDimensions.Y);
                        image.SourceRect = new Rectangle((int)(tileMap[i][j].X * tileDimensions.X), (int)(tileMap[i][j].Y * tileDimensions.Y), (int)tileDimensions.X, (int)tileDimensions.Y);
                        image.Draw(spritebatch);
                    }
                }
            }
        }
    }
}
