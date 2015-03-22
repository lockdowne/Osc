using Microsoft.Xna.Framework.Graphics;
using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oEditor.Common
{
    public static class Extensions
    {
        public static Microsoft.Xna.Framework.Vector2 ToVector2(this System.Drawing.Point point)
        {
            return new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
        }

        /// <summary>
        /// Deserializes an xelement node into object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static T DeserializeXElement<T>(this XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                DataContractSerializer xml = new DataContractSerializer(typeof(T));
                T obj = (T)xml.ReadObject(memoryStream);
                CreateTextures(obj);

                return obj;
            }
        }

        private static void CreateTextures(object obj)
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
                        CreateTextures(item);
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
                            CreateTextures(item);
                        }
                    }
                    else
                    {
                        // This will not cut-off System.Collections because of the first check
                        if (property.PropertyType.Assembly == objType.Assembly)
                        {
                            CreateTextures(propValue);

                        }
                    }
                }

                if (property.Name == "TextureName")
                {
                    if (!string.IsNullOrEmpty(property.GetValue(obj, null).ToString()))
                    {
                        //((ITexture)obj).Texture = content.Load<Texture2D>("Textures/" + property.GetValue(obj, null));
                        Bitmap bitmap = new Bitmap(Consts.OscPaths.TexturesDirectory + property.GetValue(obj, null));
                        // Need a universal graphics device
                        using (MemoryStream stream = new MemoryStream())
                        {
                            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            stream.Seek(0, SeekOrigin.Begin);
                            ((ITexture)obj).Texture = Texture2D.FromStream(oEditor.Controls.GraphicsDeviceService.singletonInstance.GraphicsDevice, stream); // This might enable me to get a universal graphics device, since all the gfx controls share one anyways
                        }
                    }
                }
            }
        }
    }
}
