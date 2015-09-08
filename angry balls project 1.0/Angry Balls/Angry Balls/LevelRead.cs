using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angry_Balls
{
    class LevelRead
    {
        public String title;
        public void ReadXML()
        {
            // First write something so that there is something to read ... 
            var b = new LevelRead { title = "Serialization Overview" };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(LevelRead));
            var wfile = new System.IO.StreamWriter(@"c:\temp\SerializationOverview.xml");
            writer.Serialize(wfile, b);
            wfile.Close();

            // Now we can read the serialized level ...
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(LevelRead));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"c:\temp\SerializationOverview.xml");
            LevelRead overview = (LevelRead)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.title);

        }
    }
}
