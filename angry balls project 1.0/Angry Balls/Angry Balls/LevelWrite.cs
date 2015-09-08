﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Resolvers;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace Angry_Balls
{
    class LevelWrite
    {
        //WriteXML() to be called in save button class 


        public class Book
        {
            public String title;
        }


        public static void WriteXML()
        {
            Book overview = new Book();
            overview.title = "Serialization Overview";
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }
    }
}

