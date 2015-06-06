using Microsoft.Xna.Framework.Graphics;
using Osc.Engine.Common;
using Osc.Engine.Entities;
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
using System.Xml;

namespace Osc.Rotch.Editor.Common
{
    public static class XnaSerializer
    {
        public static T XnaDeserialize<T>(string path)
        {
            DataContractSerializer xml = new DataContractSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(path))
            {
                T obj = (T)xml.ReadObject(reader);

                var collection = obj as IEnumerable;

                if (collection != null)
                {
                    foreach (var i in collection)
                    {
                        CreateTextures(i);
                    }
                }
                else
                {
                    CreateTextures(obj);
                }
                return obj;
            }
        }

        private static void CreateTextures(object obj)
        {
            if (obj == null) return;

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

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

                if (property.Name.ToLower() == "texturename")
                {
                    if (!string.IsNullOrEmpty(property.GetValue(obj, null).ToString()))
                    {
                        string s = Consts.OscPaths.TexturesDirectory + @"\" + property.GetValue(obj, null);

                        //((ITexture)obj).Texture = content.Load<Texture2D>("Textures/" + property.GetValue(obj, null));
                        //Bitmap bitmap = new Bitmap(Consts.OscPaths.TexturesDirectory + @"\" + property.GetValue(obj, null) + ".png"); // png is ok since I only accept pngs to save

                        ((ITexture)obj).Texture = Osc.Rotch.Editor.Controls.XnaHelper.Instance.LoadTexture(s);
                        
                        //Bitmap bitmap = new Bitmap(s); 
                        //// Need a universal graphics device
                        //using (MemoryStream stream = new MemoryStream())
                        //{
                        //    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        //    stream.Seek(0, SeekOrigin.Begin);
                        //    ((ITexture)obj).Texture = Texture2D.FromStream(Osc.Rotch.Editor.Controls.XnaHelper.Instance.GraphicsDevice, stream); // This might enable me to get a universal graphics device, since all the gfx controls share one anyways
                        //}
                    }
                }
            }
        }

    }
}
