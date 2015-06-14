using Microsoft.Xna.Framework.Graphics;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
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
using System.Xml.Linq;

namespace Osc.Rotch.Editor.Common
{
    public static class Extensions
    {
        public static Microsoft.Xna.Framework.Vector2 ToVector2(this System.Drawing.Point point)
        {
            return new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
        }

        public static void RemoveList<T>(this IList<T> lst, IList<T> list)
        {
            foreach (T obj in list)
                lst.Remove(obj);
        }

    
        public static string ClassName(this object obj)
        {
            return obj == null ? string.Empty : obj.GetType().Name;
        }

        public static System.Drawing.Color ToGdiColor(this Microsoft.Xna.Framework.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static Microsoft.Xna.Framework.Color ToXnaColor(this System.Drawing.Color color)
        {
            return new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }

    }
}
