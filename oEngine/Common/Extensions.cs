using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
