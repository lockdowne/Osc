using Microsoft.Xna.Framework.Content;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.Collections;

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

        public static T Deserialize<T>(this ContentManager content, string path)
        {
            DataContractSerializer xml = new DataContractSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(path))
            {
                T obj = (T)xml.ReadObject(reader);

                // Once object is created we pass it through LoadXnaContent to find Textures that need to be loaded by content manager
                // TODO: Load audio and fonts                
                LoadXnaContent(obj, content);

                return obj;
            }
        }

        private static void LoadXnaContent(object obj, ContentManager content)
        {
            if (obj == null) return;

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);

                // Check for dictionary collection
                var dict = propValue as IDictionary;
                if (dict != null)
                {
                    foreach(var item in dict.Values)
                    {
                        LoadXnaContent(item, content);
                    }
                }
                else
                {
                    // Check for the rest of collections
                    var elems = propValue as IEnumerable;
                    if (elems != null)
                    {
                        foreach (var item in elems)
                        {
                            LoadXnaContent(item, content);
                        }
                    }
                    else
                    {
                        // This will not cut-off System.Collections because of the first check
                        if (property.PropertyType.Assembly == objType.Assembly)
                        {
                            LoadXnaContent(propValue, content);

                        }
                    }
                }

                if (property.Name == "TextureName")
                {
                    ((ITexture)obj).Texture = content.Load<Texture2D>("Textures/" + property.GetValue(obj, null));
                }                
            }            
        }
    }
}
