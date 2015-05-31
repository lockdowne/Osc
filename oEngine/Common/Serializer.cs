using Microsoft.Xna.Framework.Graphics;
using oEngine.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace oEngine.Common
{
    public static class Serializer
    {
        /// <summary>
        /// Deserialize xml file at path into object
        /// Non extension edition brought to you by a johnson and johnson company
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

        /// <summary>
        /// Deserialize xml file at path into object
        /// Non extension edition brought to you by a johnson and johnson company
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="path">The location of xml file</param>
        /// <returns>Object</returns>
        public static Task<T> DeserializeAsync<T>(string path)
        {
            return Task.Run(() =>
                {
                    DataContractSerializer xml = new DataContractSerializer(typeof(T));

                    using (XmlReader reader = XmlReader.Create(path))
                    {
                        return (T)xml.ReadObject(reader);
                    }
                });
        }

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
        /// Serializes object and writes xml to path
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">The object object</param>
        /// <param name="path">The location of xml file</param>
        public static Task SerializeAsync<T>(T obj, string path)
        {
            return Task.Run(() =>
                {
                    DataContractSerializer xml = new DataContractSerializer(typeof(T));

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    using (XmlWriter writer = XmlWriter.Create(path, settings))
                    {
                        xml.WriteObject(writer, obj);
                    }
                });
        }
    }
}
