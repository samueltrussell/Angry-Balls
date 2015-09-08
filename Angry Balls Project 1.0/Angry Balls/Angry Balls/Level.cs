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
        [XmlElement("Layer")]
        public List<Layer> Layer;
        public Vector2 TileDimensions;

        // initialising content for the level
        public void Initialize(ContentManager content)
        {
            foreach (Layer l in Layer)
            {
                l.Initialize(content, TileDimensions);
            }
        }
        // drawing initialised content
        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Layer l in Layer)
            {
                l.Draw(spritebatch);
            }
        }
    }
}
