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
    public class Image
    {
        private Texture2D texture;
        public Rectangle SourceRect;
        public float alpha;
        private ContentManager content;
        public string path;
        public Vector2 Position;

        [XmlIgnore]
        public Texture2D Texture
        {
            get { return texture;  }
        }

        public Image()
        {
            alpha = 1.0f;
            SourceRect = Rectangle.Empty;
        }
        // initialising and drawing images for objects from xml file
        public void Intialize(ContentManager content)
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            if (!string.IsNullOrEmpty(path))
                texture = this.content.Load<Texture2D>(path);

            if (SourceRect == Rectangle.Empty)
                SourceRect = texture.Bounds;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, SourceRect, Color.White * alpha);
        }
    }
}
