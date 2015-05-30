using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;
using System.Runtime.Serialization;

namespace oEngine.Entities
{
    [DataContract]
    public class Layer<T> : IEntity where T : ITile
    {
        [DataContract]
        public class Column
        {
            [DataMember]
            public List<T> Rows = new List<T>();
        }

        [DataMember]
        private int width;

        [DataMember]
        private int height;

        /// <summary>
        /// Gets the unique ID of entity
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of entity
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of Entity
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tiles inside layer
        /// </summary>
        [DataMember]
        public List<Column> Columns = new List<Column>();

        /// <summary>
        /// Gets or sets the width of the layer
        /// </summary>
        [IgnoreDataMember]
        public int Width { get { return width; } }

        /// <summary>
        /// Gets or sets the height of the layer
        /// </summary>
        [IgnoreDataMember]
        public int Height { get { return height; } }

        /// <summary>
        /// Gets or sets the opacity of layer
        /// </summary>
        [DataMember]
        public float Alpha { get; set; }

        /// <summary>
        /// Gets or sets the visibilty state of the layer
        /// </summary>
        [DataMember]
        public bool IsVisble { get; set; }

        /// <summary>
        /// Sets the dimensions of the layer
        /// </summary>
        /// <param name="width">width in tiles</param>
        /// <param name="height">height in tiles</param>
        public void Initialize(int width, int height)
        {
            // Prevent this call if has already been initialized
            if (Columns.Count > 0)
                throw new Exception("Layer has already been initialized");

            this.width = width;
            this.height = height;

            ID = Guid.NewGuid();

            // Populate layer with tile instances
            for (int x = 0; x < width; x++)
            {
                Column column = new Column();

                for (int y = 0; y < height; y++)
                {
                    column.Rows.Add((T)Activator.CreateInstance(typeof(T)));
                }

                Columns.Add(column);
            }
        }

        public T GetTile(int x, int y)
        {
            if (x < 0 || y < 0)
                return default(T);

            if (x >= width || y >= height)
                return default(T);

            return Columns[x].Rows[y];
        }

        public IEnumerable<T> FindTiles(Func<T, bool> predicate)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (predicate((Columns[x].Rows[y])))
                    {
                        yield return Columns[x].Rows[y];
                    }
                }
            }
        }

        public T[,] FindSection(int startX, int startY, int width, int height)
        {
            T[,] section = new T[width, height];

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    section[x, y] = GetTile(x + startX, y + startY);
                }
            }

            return section;
        }

        public void Resize(int width, int height)
        {
            // TODO: Resize layer
        }
    }
}

//T[,] ResizeArray<T>(T[,] original, int rows, int cols)
//{
//    var newArray = new T[rows,cols];
//    int minRows = Math.Min(rows, original.GetLength(0));
//    int minCols = Math.Min(cols, original.GetLength(1));
//    for(int i = 0; i < minRows; i++)
//        for(int j = 0; j < minCols; j++)
//           newArray[i, j] = original[i, j];
//    return newArray;
//}
