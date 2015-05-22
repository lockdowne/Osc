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
using System.Windows.Forms;

namespace oEditor.Controls
{
    public class TilemapRender : GraphicsDeviceControl
    {
        private SpriteBatch spriteBatch;

        private Camera camera;

        private Vector2 cameraPosition;
        private Vector2 currentMousePosition;
        private Vector2 previousMousePosition;
        private Vector2? selectionBoxStart;
        private Vector2? selectionBoxEnd;

        private float cameraZoom;

        private bool isMouseLeftDown;
        private bool isMouseRightDown;

        private Texture2D pixel;
        private Texture2D tileOverlay;

        /// <summary>
        /// Gets or sets the current render controls tilemap data
        /// </summary>
        public Tilemap Tilemap { get; set; }

      

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Camera()
            {
                LerpAmount = 0.25f,
                Name = "Tilemap Camera",
                Zoom = 1.0f,
            };

            cameraZoom = camera.Zoom;

            pixel = new Texture2D(GraphicsDevice, 2, 2, false, SurfaceFormat.Color);
            pixel.SetData<Color>(new Color[] { Color.White, Color.White, Color.White, Color.White });

            tileOverlay = XnaHelper.Instance.LoadTexture(global::oEditor.Properties.Resources.tile_overlay);

            Tilemap.Pixel = pixel;
            Tilemap.IsGridVisible = true;

            MouseDown += (sender, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        isMouseLeftDown = true;
                        selectionBoxStart = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                        selectionBoxEnd = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                        break;
                    case MouseButtons.Right:
                        isMouseRightDown = true;
                        previousMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                        break;
                    case MouseButtons.Middle:
#if DEBUG
                        Console.WriteLine("Pixels: {0}", e.Location.ToString());
                        Console.WriteLine("Rounded: {0}", MathExtension.IsoSnap(e.Location.ToVector2(), Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ToString());
                        MathExtension.IsoSelector(e.Location.ToVector2(), e.Location.ToVector2() + new Vector2(Configuration.Settings.TileWidth, 0), Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ForEach(t =>  Console.WriteLine("IsoSelector: {0}", t));
                        Console.WriteLine("Coord: {0}", MathExtension.IsoPixelsToCoordinate(MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation), Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ToString());
#endif
                        break;
                }
            };

            MouseUp += (sender, e) =>
            {
                if (isMouseLeftDown)
                    isMouseLeftDown = false;

                if (isMouseRightDown)
                    isMouseRightDown = false;
            };

            MouseMove += (sender, e) =>
            {
             
                if(isMouseLeftDown)
                {
                    selectionBoxEnd = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                }

                if (isMouseRightDown && Tilemap != null)
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

            Application.Idle += (sender, e) => { Invalidate(); };
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Configuration.Settings.TilemapBackground);

            if (Tilemap == null)
                return;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            Tilemap.Draw(spriteBatch);

            DrawTileOverlay(spriteBatch);
            
            spriteBatch.End();
        }

        private void DrawTileOverlay(SpriteBatch spriteBatch)
        {
            if (selectionBoxEnd == null || selectionBoxStart == null)
                return;

            MathExtension.IsoSelector(selectionBoxStart.Value, selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ForEach(position =>
            {
                spriteBatch.Draw(tileOverlay, position, Configuration.Settings.SelectionBoxColor * Configuration.Settings.SelectionBoxOpacity);
            });

        }
    }
}
