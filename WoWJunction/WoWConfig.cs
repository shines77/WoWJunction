using System;
using System.Xml.Serialization;

namespace WoWJunction
{
    [XmlRoot("WoWConfig")]
    public class WoWConfig
    {
        public const string DefaultWoWClassicPath = @"\_classic_";
        public const string DefaultWoWClassicPathCN = @"\_classic_cn";
        public const string DefaultWoWClassicPathTW = @"\_classic_tw";

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
                wow_root_path = "";
                wow_classic_path = DefaultWoWClassicPath;
                wow_classic_path_cn = DefaultWoWClassicPathCN;
                wow_classic_path_tw = DefaultWoWClassicPathTW;
            }
        }

        [XmlElement("folders")]
        public Folders folders { get; set; }

        public WoWConfig()
        {
            folders = new Folders();
        }

        public WoWConfig TrimConfig()
        {
            folders.wow_root_path.Trim();
            folders.wow_classic_path.Trim();
            folders.wow_classic_path_cn.Trim();
            folders.wow_classic_path_tw.Trim();

            return this;
        }
    }
}
