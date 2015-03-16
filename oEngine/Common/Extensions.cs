using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace oEngine.Common
{
    public static class Extensions
    {
        public static Vector2 InvertMatrixAtVector(this Matrix matrix, int x, int y)
        {
            return Vector2.Transform(new Vector2(x, y), Matrix.Invert(matrix));
        }

        public static Vector2 InvertMatrixAtVector(this Matrix matrix, Vector2 vector)
        {
            return Vector2.Transform(new Vector2(vector.X, vector.Y), Matrix.Invert(matrix));
        }

        /// <summary>
        /// Converts Vector2 to Rectangle with dimensions of a single pixel
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Rectangle ToRectangle(this Vector2 vector)
        {
            return new Rectangle((int)vector.X, (int)vector.Y, 1, 1);
        }

        /// <summary>
        /// Converts Vector2 to Rectangle given dimensions
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Rectangle ToRectangle(this Vector2 vector, int width, int height)
        {
            return new Rectangle((int)vector.X, (int)vector.Y, width, height);
        }

        /// <summary>
        /// Calculates the signed depth of intersection between two rectangles.
        /// </summary>
        /// <returns>
        /// The amount of overlap between two intersecting rectangles. These
        /// depth values can be negative depending on which wides the rectangles
        /// intersect. This allows callers to determine the correct direction
        /// to push objects in order to resolve collisions.
        /// If the rectangles are not intersecting, Vector2.Zero is returned.
        /// </returns>
        public static Vector2 GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            // Calculate half sizes.
            float halfWidthA = rectA.Width / 2.0f;
            float halfHeightA = rectA.Height / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            // Calculate centers.
            Vector2 centerA = new Vector2(rectA.Left + halfWidthA, rectA.Top + halfHeightA);
            Vector2 centerB = new Vector2(rectB.Left + halfWidthB, rectB.Top + halfHeightB);

            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = centerA.X - centerB.X;
            float distanceY = centerA.Y - centerB.Y;
            float minDistanceX = halfWidthA + halfWidthB;
            float minDistanceY = halfHeightA + halfHeightB;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return Vector2.Zero;

            // Calculate and return intersection depths.
            float depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            float depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return new Vector2(depthX, depthY);
        }

        /// <summary>
        /// Gets the position of the center of the bottom edge of the rectangle.
        /// </summary>
        public static Vector2 GetBottomCenter(this Rectangle rect)
        {
            return new Vector2(rect.X + rect.Width / 2.0f, rect.Bottom);
        }

        /// <summary>
        /// Load entire content folder into dictionary with file name as keys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="contentFolder"></param>
        /// <returns></returns>
        public static Dictionary<string, T> LoadDirectory<T>(this ContentManager content, string contentFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(content.RootDirectory + "/" + contentFolder);

            if (!directory.Exists)
                throw new DirectoryNotFoundException();

            Dictionary<string, T> result = new Dictionary<string, T>();

            FileInfo[] files = directory.GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                string name = file.Name.Split('.')[0];

                result.Add(name, content.Load<T>(contentFolder + "/" + name));
            }

            return result;
        }
              
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {            
            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Serializes object into an xelement node used to append to a xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static XElement ToXElement<T>(this T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamReader(memoryStream))
                {
                    DataContractSerializer xml = new DataContractSerializer(typeof(T));

                    xml.WriteObject(memoryStream, obj);

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    return XElement.Parse(streamWriter.ReadToEnd());
                }
            }
        }

        /// <summary>
        /// Deserializes an xelement node into object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static T FromXElement<T>(this XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                DataContractSerializer xml = new DataContractSerializer(typeof(T));
                return (T)xml.ReadObject(memoryStream);
            }
        }

        /// <summary>
        /// Serializes object and writes xml to path
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">The object object</param>
        /// <param name="path">The location of xml file</param>
        public static void Serialize<T>(this T obj, string path)
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
        public static T Deserialize<T>(this T obj, string path)
        {
            DataContractSerializer xml = new DataContractSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(path))
            {

                return (T)xml.ReadObject(reader);
            }
        }
        

        /// <summary>
        /// Deserialize objects with Texture2D and other xna pipeline contents
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <returns></returns>
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
                    foreach (var item in dict.Values)
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
