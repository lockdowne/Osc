using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
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

        
    }
}
