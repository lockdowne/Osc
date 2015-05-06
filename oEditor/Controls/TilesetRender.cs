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

        private IList<Vector2> SelectionIsometricBox { get; set; }

        public Tileset Tileset { get; set; }

        public Enums.SelectionModes SelectionMode { get; set; }

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

            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData<Color>(new Color[] { Color.White });

            tileOverlay = XnaHelper.Instance.LoadTexture(global::oEditor.Properties.Resources.tile_overlay);

            SelectionIsometricBox = new List<Vector2>();

            SelectionMode = Enums.SelectionModes.Orthogonal;
            

            MouseDown += (sender, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        // Clear box
                        selectionBoxStart = null;
                        selectionBoxEnd = null;

                        SelectionIsometricBox.Clear();

                        selectionBoxStart = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X, 0, Tileset.Texture.Width),
                            MathHelper.Clamp(e.Location.Y, 0, Tileset.Texture.Height)), camera.CameraTransformation);

                        selectionBoxEnd = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X + Configuration.Settings.TileWidth, 0, Tileset.Texture.Width),
                           MathHelper.Clamp(e.Location.Y + Configuration.Settings.TileHeight, 0, Tileset.Texture.Height)), camera.CameraTransformation);

                        SelectionIsometricBox = MathExtension.IsoSelector(selectionBoxStart.Value, selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ToList();

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
                    isMouseLeftDown = false;
            };

            MouseMove += (sender, e) =>
            {
                if(isMouseLeftDown)
                {
                    selectionBoxEnd = MathExtension.InvertMatrixAtVector(new Vector2(MathHelper.Clamp(e.Location.X, 0, Tileset.Texture.Width),
                           MathHelper.Clamp(e.Location.Y, 0, Tileset.Texture.Height)), camera.CameraTransformation);

                    SelectionIsometricBox = MathExtension.IsoSelector(selectionBoxStart.Value, selectionBoxEnd.Value, Configuration.Settings.TileWidth, Configuration.Settings.TileHeight).ToList();
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

            switch (SelectionMode)
            {
                case Enums.SelectionModes.Orthogonal:
                    spriteBatch.Draw(pixel, SelectionOrthogonalBox, Configuration.Settings.SelectionBoxColor * Configuration.Settings.SelectionBoxOpacity);
                    break;
                case Enums.SelectionModes.Isometric:
                    SelectionIsometricBox.ForEach(position => spriteBatch.Draw(tileOverlay, position, null, Configuration.Settings.SelectionBoxColor * Configuration.Settings.SelectionBoxOpacity));
                    break;
            }

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

       
    }
}
