using System;
using System.Xml.Serialization;

namespace WoWJunction
{
    [XmlRoot("WoWConfig")]
    public class WoWConfig
    {
        public class Folders
        {
            [XmlElement("wow_root_path")]
            public string wow_root_path { get; set; }

            [XmlElement("wow_classic_path")]
            public string wow_classic_path { get; set; }

            [XmlElement("wow_classic_path_cn")]
            public string wow_classic_path_cn { get; set; }

            [XmlElement("wow_classic_path_tw")]
            public string wow_classic_path_tw { get; set; }

            public Folders()
            {
                wow_root_path = @"C:\Blizzard\World of Warcraft";
                wow_classic_path = "_classic_";
                wow_classic_path_cn = "_classic_cn";
                wow_classic_path_tw = "_classic_tw";
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
