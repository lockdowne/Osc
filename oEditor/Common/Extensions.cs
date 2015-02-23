using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Common
{
    public static class Extensions
    {
        public static Microsoft.Xna.Framework.Vector2 ToVector2(this System.Drawing.Point point)
        {
            return new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
        }
    }
}
