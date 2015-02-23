using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace oEngine.Common
{
    /// <summary>
    /// Serializes and Deserializes game entities in xml
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes object and writes xml to path
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">The object object</param>
        /// <param name="path">The location of xml file</param>
        public static void Serialize<T>(T obj, string path)
        {
            DataContractSerializer xml = new DataContractSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                xml.WriteObject(writer, obj);
            }
        }

        /// <summary>
        /// Deserialize xml file at path into object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="path">The location of xml file</param>
        /// <returns>Object</returns>
        public static T Deserialize<T>(string path)
        {
            DataContractSerializer xml = new DataContractSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(path))
            {
                return (T)xml.ReadObject(reader);
            }
        }
    }
}
