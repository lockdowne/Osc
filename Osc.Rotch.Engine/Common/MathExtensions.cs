using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Osc.Engine.Common
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
            return IsoCoordinateToPixels(x, y, tileWidth, tileHeight, 0, 0);
        }

        public static Vector2 IsoCoordinateToPixels(int x, int y, int tileWidth, int tileHeight, int offsetX, int offsetY)
        {
            return new Vector2((x - y) * (tileWidth / 2) - (offsetX), (x + y) * (tileHeight / 2) - (offsetY));
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
               (int)Math.Round(((vector.Y / (tileHeight / 2)) - (vector.X / (tileWidth / 2))) / 2));
        }

        public static Point OrthogonalToIsoCoordinate(int x, int y, int tileWidth, int tileHeight)
        {
            Vector2 isoPixels = IsoCoordinateToPixels(x, y, tileWidth, tileHeight);
            return IsoPixelsToCoordinate(isoPixels, tileWidth, tileHeight);
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
            Vector2 toPixels = IsoCoordinateToPixels(toCoordinate.X, toCoordinate.Y, tileWidth, tileHeight); // Check if I need that - 1

            return new Vector2(toPixels.X, toPixels.Y);
        }

        /// <summary>
        /// Rounds vector to align with orthogonal grid
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns></returns>
        public static Vector2 OrthogonalSnap(Vector2 vector, int tileWidth, int tileHeight)
        {
            Point toCoordinate = new Point((int)vector.X / tileWidth, (int)vector.Y / tileHeight);

            return new Vector2(toCoordinate.X * tileWidth, toCoordinate.Y * tileHeight);
        }

        /// <summary>
        /// Selects all tile locations in pixels between two vectors
        /// </summary>
        /// <param name="startVector"></param>
        /// <param name="endVector"></param>
        /// <param name="tileWidth"></param>
        /// <param name="tileHeight"></param>
        /// <returns>Collection of all pixel locations represented as the center</returns>
        public static IEnumerable<Vector2> IsoSelector(Vector2 startVector, Vector2 endVector, int tileWidth, int tileHeight)
        {
            // Prevent division by zero instead of throwing exception
            if (tileWidth <= 0 || tileHeight <= 0)
                yield break;

            int startX = Math.Min(IsoPixelsToCoordinate(startVector, tileWidth, tileHeight).X, IsoPixelsToCoordinate(endVector, tileWidth, tileHeight).X);
            int startY = Math.Min(IsoPixelsToCoordinate(startVector, tileWidth, tileHeight).Y, IsoPixelsToCoordinate(endVector, tileWidth, tileHeight).Y);
            int width = Math.Abs(IsoPixelsToCoordinate(startVector, tileWidth, tileHeight).X - IsoPixelsToCoordinate(endVector, tileWidth, tileHeight).X);
            int height = Math.Abs(IsoPixelsToCoordinate(startVector, tileWidth, tileHeight).Y - IsoPixelsToCoordinate(endVector, tileWidth, tileHeight).Y);

            for (int x = startX - 1; x < startX + width; x++)
            {
                for (int y = startY; y <= startY + height; y++)
                {
                    yield return IsoCoordinateToPixels(x, y, tileWidth, tileHeight);
                }
            }
        }

        public static Vector2 IsoSelector(Vector2 vector, int tileWidth, int tileHeight)
        {
            return IsoSelector(vector, vector, tileWidth, tileHeight).FirstOrDefault();
        }

       

        public static bool CoordinateWithinBounds(int x, int y, int width, int height)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }
    }
}
