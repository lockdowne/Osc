using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace oEngine.Entities
{
    public class Camera : IEntity
    {
        /// <summary>
        /// Gets or sets the unique ID of entity
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of Entity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets vector position
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets zoom
        /// </summary>
        public float Zoom { get; set; }

        /// <summary>
        /// Gets or sets rotation
        /// NOTE: Currently unused
        /// </summary>
        private float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the cameras linear interpoliation amount
        /// </summary>
        public float LerpAmount { get; set; }

        /// <summary>
        /// Gets the matrix transformation
        /// </summary>
        public Matrix CameraTransformation
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            }
        }

        public void UpdatePosition(Vector2 position, Vector2 min, Vector2 max)
        {
            Position = Vector2.Clamp(new Vector2((int)Vector2.Lerp(Position, position, LerpAmount).X, (int)Vector2.Lerp(Position, position, LerpAmount).Y), min, max);

        }

        public void UpdateZoom(float zoom, float min, float max)
        {
            Zoom = MathHelper.Clamp(MathHelper.Lerp(Zoom, zoom, LerpAmount), min, max);
        }

    }
}
