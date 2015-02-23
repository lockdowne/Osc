using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Entities;
using oEngine.Common;
using oEditor.Common;

namespace oEditor.Controls
{
    public class TilemapRender : GraphicsDeviceControl
    {
        private SpriteBatch spriteBatch;

        private Color backgroundColor; 

        private Camera camera;

        private Vector2 cameraPosition;
        private Vector2 currentMousePosition;
        private Vector2 previousMousePosition;

        private Texture2D pixel;

        private float cameraZoom;

        private bool isMouseLeftDown;
        private bool isMouseRightDown;

        /// <summary>
        /// Gets or sets the current render controls tilemap data
        /// </summary>
        public Tilemap Tilemap { get; set; }

        public System.Windows.Forms.MouseEventHandler OnMouseDown;
        public System.Windows.Forms.MouseEventHandler OnMouseUp;
        public System.Windows.Forms.MouseEventHandler OnMouseMove;
        public System.Windows.Forms.MouseEventHandler OnMouseWheel;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundColor = Configuration.Settings.TilemapBackground;

            camera = new Camera()
            {
                LerpAmount = 0.1f,
                Name = "Tilemap Camera",
                Zoom = 1.0f,
            };

            cameraZoom = camera.Zoom;

            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData<Color>(new Color[] { Color.White });

            MouseDown += (sender, e) =>
            {
                if (OnMouseDown != null)
                    OnMouseDown(sender, e);

                if(e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    isMouseRightDown = true;

                    previousMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                }
            };

            MouseUp += (sender, e) =>
            {
                if (OnMouseUp != null)
                    OnMouseUp(sender, e);

                if (isMouseRightDown)
                    isMouseRightDown = false;
            };

            MouseMove += (sender, e) =>
            {
                if (OnMouseMove != null)
                    OnMouseMove(sender, e);

                if(isMouseRightDown && Tilemap != null)
                {                    
                    currentMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);

                    Vector2 difference = currentMousePosition - previousMousePosition;

                    cameraPosition += -difference;

                    camera.UpdatePosition(cameraPosition,
                        new Vector2(-(Tilemap.Width * Tilemap.TileWidth), -(Tilemap.Height * Tilemap.TileHeight)),
                        new Vector2(Tilemap.Width * Tilemap.TileWidth, Tilemap.Height * Tilemap.TileHeight));

                    // Used to remove pixels beyond bounds
                    cameraPosition = camera.Position;
                }


            };

            MouseWheel += (sender, e) =>
            {
                if (OnMouseWheel != null)
                    OnMouseWheel(sender, e);

                if (e.Delta > 0)
                {
                    cameraZoom += Configuration.Settings.ZoomIncrement;
                }                    
                else if (e.Delta < 0)
                {
                    cameraZoom -= Configuration.Settings.ZoomIncrement;
                }

                camera.UpdateZoom(cameraZoom, Configuration.Settings.MinCameraZoom, Configuration.Settings.MaxCameraZoom);

                // Used to reset scale beyond bounds
                cameraZoom = camera.Zoom;
            };
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(backgroundColor);

            if (Tilemap == null)
                return;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            Tilemap.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
