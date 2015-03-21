using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace oEngine.Common
{
    public static class MathExtension
    {
        /// <summary>
        /// Applies correction to screen pixels to a matrix transformation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Vector2 InvertMatrixAtVector(int x, int y, Matrix matrix)
        {
            return InvertMatrixAtVector(new Vector2(x, y), matrix);
        }
        
        /// <summary>
        /// Applies correction to screen pixels to a matrix transformation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Vector2 InvertMatrixAtVector(Vector2 vector, Matrix matrix)
        {
            return Vector2.Transform(new Vector2(vector.X, vector.Y), Matrix.Invert(matrix));
        }

        /// <summary>
        /// Converts matrix coordinate into pixels 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns></returns>
        public static Vector2 IsoCoordinateToPixels(int x, int y, int tileWidth, int tileHeight)
        {
            return new Vector2((x - y) * tileWidth / 2, (x + y) * tileHeight / 2);
        }        

        /// <summary>
        /// Converts pixels into matrix coordinate
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns></returns>
        public static Point IsoPixelsToCoordinate(Vector2 vector, int tileWidth, int tileHeight)
        {
            return new Point((int)Math.Round(((vector.X / (tileWidth / 2)) + (vector.Y / (tileHeight / 2))) / 2),
               (int)Math.Round(((vector.Y / (tileHeight / 2)) - ((vector.X / (tileWidth / 2)))) / 2));
        }

        /// <summary>
        /// Rounds vector to align with isometric grid
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns></returns>
        public static Vector2 IsoSnap(Vector2 vector, int tileWidth, int tileHeight)
        {
            Point toCoordinate = IsoPixelsToCoordinate(vector, tileWidth, tileHeight);
            Vector2 toPixels = IsoCoordinateToPixels(toCoordinate.X - 1, toCoordinate.Y, tileWidth, tileHeight); // Check if I need that - 1

            return new Vector2(toPixels.X, toPixels.Y);
        }

        /// <summary>
        /// Selects all tile locations in pixels between two vectors
        /// </summary>
        /// <param name="startVector"></param>
        /// <param name="endVector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns>Collection of all pixel locations</returns>
        public static IEnumerable<Vector2> IsoSelector(Vector2 startVector, Vector2 endVector, int tileWidth, int tileHeight, int tilemapWidth, int tilemapHeight) // TODO: Measure performance
        {
            // Prevent division by zero instead of throwing exception
            if (tileWidth <= 0 || tileHeight <= 0 || tilemapWidth <= 0 || tilemapHeight <= 0)
                yield break;

            Vector2 startRounded = IsoSnap(startVector, tileWidth, tileHeight);
            Vector2 endRounded = IsoSnap(endVector, tileWidth, tileHeight);

            if (startRounded.Equals(endRounded))
                yield return IsoSnap(startVector, tileWidth, tileHeight);


            // Slight modifications of the normal iso math due to wanting the ability to have the selection start and end in any direction
            float m0 = (startRounded.Y / tileHeight) - (startRounded.X / tileWidth);
            float n0 = (startRounded.Y / tileHeight) + (startRounded.X / tileWidth);
            float m1 = (endRounded.Y / tileHeight) - (endRounded.X / tileWidth);
            float n1 = (endRounded.Y / tileHeight) + (endRounded.X / tileWidth);

            Vector2 p1 = new Vector2((n0 - m0) / 2 * tileWidth, (n0 + m0) / 2 * tileHeight);
            Vector2 p2 = new Vector2((n1 - m0) / 2 * tileWidth, (n1 + m0) / 2 * tileHeight);
            Vector2 p3 = new Vector2((n1 - m1) / 2 * tileWidth, (n1 + m1) / 2 * tileHeight);
            Vector2 p4 = new Vector2((n0 - m1) / 2 * tileWidth, (n0 + m1) / 2 * tileHeight);

            int startX = Math.Min(IsoPixelsToCoordinate(p1, tileWidth, tileHeight).X, IsoPixelsToCoordinate(p3, tileWidth, tileHeight).X);
            int startY = Math.Min(IsoPixelsToCoordinate(p1, tileWidth, tileHeight).Y, IsoPixelsToCoordinate(p3, tileWidth, tileHeight).Y);
            int width = Math.Abs(IsoPixelsToCoordinate(p2, tileWidth, tileHeight).X - IsoPixelsToCoordinate(p1, tileWidth, tileHeight).X) + 1;
            int height = Math.Abs(IsoPixelsToCoordinate(p3, tileWidth, tileHeight).Y - IsoPixelsToCoordinate(p2, tileWidth, tileHeight).Y) + 1;

            for (int x = startX; x < startX + width; x++)
            {
                for(int y = startY; y < startY + height; y++)
                {
                    yield return IsoCoordinateToPixels((int)MathHelper.Clamp(x, 0, tilemapWidth - 1), (int)MathHelper.Clamp(y, 0, tilemapHeight - 1), tileWidth, tileHeight);
                }
            }
        }

        /// <summary>
        /// Selects the single selected tile location in pixels
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns>Pixel location</returns>
        public static Vector2 IsoSelector(Vector2 vector, int tileWidth, int tileHeight)
        {
            return IsoSnap(vector, tileWidth, tileHeight);
        }

        /// <summary>
        /// Randomizes the elements within the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
