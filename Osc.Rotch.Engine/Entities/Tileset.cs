using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Osc.Engine.Entities
{
    [DataContract(Namespace = "")]
    public class Tileset : IEntity, ITexture
    {
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

        [DataMember]
        public string TextureName { get; set; }

        /// <summary>
        /// Gets or sets the image of the tileset
        /// </summary>
        [IgnoreDataMember]
        public Texture2D Texture { get; set; }


        public void Initialize(string textureName, Texture2D texture)
        {
            if (Texture != null)
                throw new Exception("Tileset has already been initialized");

            if (texture == null)
                throw new ArgumentNullException("Tileset texture cannot be null");

            TextureName = textureName;

            Texture = texture;
        }

        /// <summary>
        /// Return a rectangle with the size of the tile dimensions
        /// Represents the location on the texture to draw
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <returns></returns>
        public Rectangle GetSourceRectangle(int tileIndex, int tileWidth, int tileHeight)
        {
            if (Texture == null)
                throw new ArgumentNullException("Must set texture to a value");

            int tileY = tileIndex / (Texture.Width / tileWidth);
            int tileX = tileIndex % (Texture.Width / tileWidth);

            return new Rectangle(tileX * tileWidth, tileY * tileHeight, tileWidth, tileHeight);
        }

        /// <summary>
        /// Get the color of the pixel in the center of selected tile
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <returns>Center color of current image</returns>
        public Color GetCenterPixelColor(int tileIndex, int tileWidth, int tileHeight)
        {
            if (Texture == null)
                throw new ArgumentNullException("Must set texture to a value");

            if (tileIndex < 0)
                return Color.Transparent;

            Rectangle sourceRectangle = GetSourceRectangle(tileIndex, tileWidth, tileHeight);

            Color[] tileColors = new Color[sourceRectangle.Width * sourceRectangle.Height];

            Texture.GetData(0, sourceRectangle, tileColors, 0, tileColors.Length);

            return tileColors[(sourceRectangle.Width * sourceRectangle.Height) / 2];
        }
    }
}
