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
    }
}
