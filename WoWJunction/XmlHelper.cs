using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WoWJunction
{
    /// <summary>
    /// XML序列化工具类
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Xml序列化
        /// </summary>
        /// <typeparam name="T">序列化的对象类型</typeparam>
        /// <param name="obj">被序列化的对象</param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            using (StringWriter textWriter = new StringWriter()) {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Xml字符串反序列化
        /// </summary>
        /// <typeparam name="T">反序列化的对象类型</typeparam>
        /// <param name="xmlStr">被反序列化的字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlStr)
        {
            using (StringReader textReader = new StringReader(xmlStr)) {
                XmlSerializer serializer = new XmlSerializer(typeof(int));
                return (T)serializer.Deserialize(textReader);
            }
        }

        /// <summary>
        /// 对象序列化成XML文件
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">XML文件完整路径及名称</param>
        /// <param name="obj">对象</param>
        /// <param name="root">根元素名称</param>
        public static void SaveToXML<T>(T obj, string xmlFile, string root = "")
        {
            Type type = typeof(T);
            using (StreamWriter textWriter = new StreamWriter(xmlFile)) {
                XmlSerializer xmlSerializer = (root.Trim().Length == 0)
                    ? new XmlSerializer(type)
                    : new XmlSerializer(type, new XmlRootAttribute(root));
                xmlSerializer.Serialize(textWriter, obj);
            }
        }

        /// <summary>
        /// XML文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">XML文件完整路径及名称</param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string xmlFile)
        {
            if (!File.Exists(xmlFile)) {
                return default(T);
            }
            using (StreamReader textReader = new StreamReader(xmlFile)) {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        /// <summary>
        /// XML文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">XML文件完整路径及名称</param>
        /// <param name="root">根元素名称</param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string xmlFile, string root)
        {
            if (!File.Exists(xmlFile)) {
                return default(T);
            }
            using (StreamReader textReader = new StreamReader(xmlFile)) {
                XmlSerializer xmlSerializer = (root.Trim().Length == 0)
                    ? new XmlSerializer(typeof(T))
                    : new XmlSerializer(typeof(T), new XmlRootAttribute(root));
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
