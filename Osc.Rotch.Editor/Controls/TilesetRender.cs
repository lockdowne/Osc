using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Editor.Common;
using System.Windows.Forms;
using Osc.Rotch.Engine.Patterns;

namespace Osc.Rotch.Editor.Controls
{
    public class TilesetRender : GraphicsDeviceControl
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

        // Will need this for orthogonal
        private Rectangle SelectionOrthogonalBox
        {
            get
            {
                if (selectionBoxStart == null || selectionBoxEnd == null)
                    return Rectangle.Empty;

                return new Rectangle((int)Math.Min(MathExtension.OrthogonalSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X,
                    MathExtension.OrthogonalSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X),
                    (int)Math.Min(MathExtension.OrthogonalSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y,
                    MathExtension.OrthogonalSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y),
                    (int)Math.Abs(MathExtension.OrthogonalSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X
                    - MathExtension.OrthogonalSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).X),
                    (int)Math.Abs(MathExtension.OrthogonalSnap(selectionBoxStart.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y
                    - MathExtension.OrthogonalSnap(selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).Y));
            }
        }

        public Tileset Tileset { get; set; }

        public event Action<TilePattern> OnTilePatternGenerated;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Camera()
            {
                LerpAmount = 0.25f,
                Name = "Tileset Camera",
                Zoom = 1.0f,
            };

            cameraZoom = camera.Zoom;

            pixel = new Texture2D(GraphicsDevice, 2, 2, false, SurfaceFormat.Color);
            pixel.SetData<Color>(new Color[] { Color.White, Color.White, Color.White, Color.White });

            tileOverlay = XnaHelper.Instance.LoadTexture(global::Osc.Rotch.Editor.Properties.Resources.tile_overlay);

            MouseDown += (sender, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        // Clear box
                        selectionBoxStart = null;
                        selectionBoxEnd = null;

                        selectionBoxStart = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X, 0, Tileset.Texture.Width),
                            MathHelper.Clamp(e.Location.Y, 0, Tileset.Texture.Height)), camera.CameraTransformation);

                        selectionBoxEnd = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X + Configuration.Settings.TileWidth, 0, Tileset.Texture.Width),
                           MathHelper.Clamp(e.Location.Y + Configuration.Settings.TileHeight, 0, Tileset.Texture.Height)), camera.CameraTransformation);

                        isMouseLeftDown = true;

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
                if (isMouseRightDown)
                    isMouseRightDown = false;

                if (isMouseLeftDown)
                {
                    isMouseLeftDown = false;
                                        
                    if (OnTilePatternGenerated != null)
                        OnTilePatternGenerated(GetTilePattern());
                }
            };

            MouseMove += (sender, e) =>
            {
                if (isMouseLeftDown)
                {
                    selectionBoxEnd = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X, 0, Tileset.Texture.Width),
                           MathHelper.Clamp(e.Location.Y, 0, Tileset.Texture.Height)), camera.CameraTransformation);
                }
                else if (isMouseRightDown)
                {
                    currentMousePosition = MathExtension.InvertMatrixAtVector(e.Location.ToVector2(), camera.CameraTransformation);

                    Vector2 difference = currentMousePosition - previousMousePosition;

                    if (Tileset == null)
                        return;

                    cameraPosition += -difference;

                    camera.UpdatePosition(cameraPosition, Vector2.Zero, new Vector2(Tileset.Texture.Width, Tileset.Texture.Height));

                    //camera.UpdatePosition(cameraPosition,
                    //    new Vector2(-(Tilemap.Width * Tilemap.TileWidth), -(Tilemap.Height * Tilemap.TileHeight)),
                    //    new Vector2(Tilemap.Width * Tilemap.TileWidth, Tilemap.Height * Tilemap.TileHeight));

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
            GraphicsDevice.Clear(Configuration.Settings.TilesetBackground);

            if (Tileset == null)
                return;

            if (Tileset.Texture == null)
                return;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            spriteBatch.Draw(Tileset.Texture, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);          
            spriteBatch.Draw(pixel, SelectionOrthogonalBox, Configuration.Settings.SelectionBoxColor * Configuration.Settings.SelectionBoxOpacity);

            spriteBatch.End();
        }

        public int[,] SelectionBoxValues()
        {
            if (Tileset == null)
                return null;

            if (Tileset.Texture == null)
                return null;

            int textureWidth = Tileset.Texture.Width;
            int textureHeight = Tileset.Texture.Height;


            return null;
        }

        public TilePattern GetTilePattern()
        {
            if (Tileset == null)
                return null;

            if (Tileset.Texture == null)
                return null;

            if (SelectionOrthogonalBox.IsEmpty)
                return null;

            int tileWidth = Configuration.Settings.TileWidth;
            int tileHeight = Configuration.Settings.TileHeight;

            int width = SelectionOrthogonalBox.Width / tileWidth;
            int height = SelectionOrthogonalBox.Height / tileHeight;
            int x = SelectionOrthogonalBox.Location.X / tileWidth;
            int y = SelectionOrthogonalBox.Location.Y / tileHeight;

            int index = (y * (Tileset.Texture.Width / tileWidth)) + x;

            if (width == 0 || height == 0)
                return null;

            int[,] box = new int[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    box[j, i] = index + j;
                }

                index += (Tileset.Texture.Width / tileWidth);
            }

            return new TilePattern()
            {
                Tint = Color.White,
                Alpha = Configuration.Settings.TilePatternOpacity,
                Origin = Vector2.Zero,
                Pattern = box,
                Position = Vector2.Zero,
                TileHeight = tileHeight,
                TileWidth = tileWidth,
                Tileset = Tileset
            };

        }
    }
}
