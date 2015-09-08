using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Angry_Balls
{
    class Editor
    {
        ContentManager content;
        SpriteBatch spritebatch;
        Level level;
        IServiceProvider Services;
        public Editor()
        {
            //level = new Level();
            content = new ContentManager(Services, "Content");
            //spritebatch = new SpriteBatch(GraphicsDevice);

        }
        // initialise all layers and the level the game is in, storing the edited values as xml file
        public void Initialize()
        {
            
            XmlSerializer xml = new XmlSerializer(level.GetType());
            Stream stream = File.Open("filename.xml", FileMode.Open);
            level = (Level)xml.Deserialize(stream);
            //level.Initialize(content);
        }
        // drawing the level
        public void Draw()
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            spritebatch.Begin();
            //level.Draw(spritebatch);
            spritebatch.End();
        }
    }
}
