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
    public class TilesetRender : GraphicsDeviceControl
    {
        private SpriteBatch spriteBatch;

        private Color backgroundColor;

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

        private Rectangle SelectionBoxBounds
        {
            get
            {
                if (selectionBoxStart == null || selectionBoxEnd == null)
                    return Rectangle.Empty;

                return new Rectangle((int)Math.Min(MathExtension.IsoSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X,
                    MathExtension.IsoSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X),
                    (int)Math.Min(MathExtension.IsoSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y,
                    MathExtension.IsoSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y),
                    (int)Math.Abs(MathExtension.IsoSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X
                    - MathExtension.IsoSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X),
                    (int)Math.Abs(MathExtension.IsoSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y
                    - MathExtension.IsoSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y));
            }
        }

        public Tileset Tileset { get; set; }

        /// <summary>
        /// Gets or sets the current render controls tilemap data
        /// </summary>      

        public System.Windows.Forms.MouseEventHandler RenderMouseDown;
        public System.Windows.Forms.MouseEventHandler RenderMouseUp;
        public System.Windows.Forms.MouseEventHandler RenderMouseMove;
        public System.Windows.Forms.MouseEventHandler RenderMouseWheel;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundColor = Configuration.Settings.TilesetBackground;

            camera = new Camera()
            {
                LerpAmount = 0.25f,
                Name = "Tileset Camera",
                Zoom = 1.0f,
            };

            cameraZoom = camera.Zoom;

            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData<Color>(new Color[] { Color.White });

      

            MouseDown += (sender, e) =>
            {
                if (RenderMouseDown != null)
                    RenderMouseDown(sender, e);

                switch (e.Button)
                {
                    case MouseButtons.Left:
                                               
                        break;
                    case MouseButtons.Right:
                        isMouseRightDown = true;
                        previousMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);
                        break;
                    case MouseButtons.Middle:
                        break;
                }
            };

            MouseUp += (sender, e) =>
            {
                if (RenderMouseUp != null)
                    RenderMouseUp(sender, e);

                if (isMouseRightDown)
                    isMouseRightDown = false;
            };

            MouseMove += (sender, e) =>
            {
                if (RenderMouseMove != null)
                    RenderMouseMove(sender, e);

                if (isMouseRightDown)
                {
                    currentMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);

                    Vector2 difference = currentMousePosition - previousMousePosition;

                    cameraPosition += -difference;

                    //camera.UpdatePosition(cameraPosition,
                    //    new Vector2(-(Tilemap.Width * Tilemap.TileWidth), -(Tilemap.Height * Tilemap.TileHeight)),
                    //    new Vector2(Tilemap.Width * Tilemap.TileWidth, Tilemap.Height * Tilemap.TileHeight));

                    // Used to remove pixels beyond bounds
                    cameraPosition = camera.Position;
                }


            };

            MouseWheel += (sender, e) =>
            {
                if (RenderMouseWheel != null)
                    RenderMouseWheel(sender, e);
                
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
            GraphicsDevice.Clear(backgroundColor);

            if (Tileset == null)
                return;

            if (Tileset.Texture == null)
                return;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            spriteBatch.Draw(Tileset.Texture, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

            spriteBatch.End();
        }
    }
}
