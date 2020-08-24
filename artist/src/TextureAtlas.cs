using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

using UnityEngine;
using UnityEditor;

namespace u3devtools.artist
{
    [XmlRoot("TextureAtlas")]
    public class TextureAtlas
    {
        public static TextureAtlas Read(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(TextureAtlas));
            FileStream fs = new FileStream(path, FileMode.Open);
            TextureAtlas ta = xs.Deserialize(fs) as TextureAtlas;
            fs.Close();
            return ta;
        }

        [XmlRoot("sprite")]
        public class Sprite
        {
            [XmlAttribute("n")]
            public string name;
            [XmlAttribute("x")]
            public int x;
            [XmlAttribute("y")]
            public int y;
            [XmlAttribute("w")]
            public int w;
            [XmlAttribute("h")]
            public int h;
        }

        [XmlAttribute("imagePath")]
        public string imagePath;

        [XmlAttribute("width")]
        public int width;

        [XmlAttribute("height")]
        public int height;

        [XmlElement("sprite")]
        public List<Sprite> sprites;
    }
}