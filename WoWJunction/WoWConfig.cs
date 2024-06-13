using System;
using System.Xml.Serialization;

namespace WoWJunction
{
    [XmlRoot("WoWConfig")]
    public class WoWConfig
    {
        public class Folders
        {
            [XmlElement("classic_dir")]
            public string classic_dir { get; set; }

            [XmlElement("cn_classic_dir")]
            public string cn_classic_dir { get; set; }

            [XmlElement("tw_classic_dir")]
            public string tw_classic_dir { get; set; }

            public Folders()
            {
                classic_dir = @"C:\Blizzard\World of Warcraft\_classic_";
                cn_classic_dir = @"C:\Blizzard\World of Warcraft\_classic_cn_";
                tw_classic_dir = @"C:\Blizzard\World of Warcraft\_classic_tw_";
            }
        }

        [XmlElement("folders")]
        public Folders folders { get; set; }

        public WoWConfig()
        {
            folders = new Folders();
        }
    }
}
