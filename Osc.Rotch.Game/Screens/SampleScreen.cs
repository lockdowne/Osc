using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Screens;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Osc.Rotch.Game.Screens
{
    public class SampleScreen : GameScreen
    {
        #region Fields

        private Camera camera;

        private Character testCharacter;
        private Texture2D testStickFigure;

        private Tilemap tilemap;

        private Vector2 previousMousePosition;
        private Vector2 currentMousePosition;
        private Vector2 cameraPosition;

        #endregion

        public SampleScreen()
            : base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();

                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                tilemap = ScreenManager.Content.XnaDeserialize<List<Tilemap>>(@"C:\SourceCode\Rotch\Osc.Rotch.Game\Content\Tilemaps.xml").FirstOrDefault();

                testStickFigure = content.Load<Texture2D>(@"Textures/testchar");

                Animation testAnimation = new Animation();
                testAnimation.Initialize("test", testStickFigure, 0, 0, 128, 200, 1, 5);

                testCharacter = new Character() { IsActive = true, IsVisible = true, Position = Vector2.Zero, Scale = 1.0f, Tint = Color.White };
                testCharacter.AddAnimation("test", testAnimation);
                testCharacter.PlayAnimation("test");

                camera = new Camera() { Zoom = 1.0f, LerpAmount = 1f, Position = Vector2.Zero };
            }
            catch (Exception exception)
            {

            }
        }

        public override void HandleInput(Engine.Inputs.InputState input)
        {
            base.HandleInput(input);

            Vector2 inputPosition = MathExtension.InvertMatrixAtVector(input.Position, camera.CameraTransformation);
            Point inputPoint = MathExtension.IsoPixelsToCoordinate(inputPosition, tilemap.TileWidth, tilemap.TileHeight);

            if (input.LeftClick)
            {
                Console.WriteLine(inputPoint);

                testCharacter.Position = MathExtension.IsoCoordinateToPixels(inputPoint.X, inputPoint.Y, tilemap.TileWidth, tilemap.TileHeight) - (new Vector2(testCharacter.Bounds.Width /2, testCharacter.Bounds.Height));

                testCharacter.DepthValue = ((float)((1.0f / (tilemap.Width + tilemap.Height - 1)) * ((inputPoint.X - 1) + inputPoint.Y)));

                Console.WriteLine(((inputPoint.X - 1) + inputPoint.Y));
             
            }

            if (input.MiddleClick)
            {
                previousMousePosition = inputPosition;
            }

            if (input.MiddleDown && tilemap != null)
            {
                currentMousePosition = inputPosition;

                Vector2 difference  = currentMousePosition - previousMousePosition;
                cameraPosition -= difference;

                camera.UpdatePosition(cameraPosition, 
                    new Vector2(-(tilemap.Width * tilemap.TileWidth), -(tilemap.Height * tilemap.TileHeight)),
                    new Vector2(tilemap.Width * tilemap.TileWidth, tilemap.Height * tilemap.TileHeight));

                // Used to remove pixels beyond bounds
                cameraPosition = camera.Position;
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            testCharacter.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.GraphicsDevice.Clear(Color.Black);

            ScreenManager.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);
            
            tilemap.Draw(ScreenManager.SpriteBatch);

            testCharacter.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.End();
        }
    }
}
