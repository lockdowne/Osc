using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using oEngine.Common;
using oEngine.Screens;
using oEngine.Entities;
using oEngine.Managers;

namespace oGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class oGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private ScreenManager screenManager;

        // Get fps
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private int frameRate = 0;
        private int frameCounter = 0;

        public oGame()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
                //graphics.PreferredBackBufferHeight = 0;
                // graphics.PreferredBackBufferWidth = 0;

                Content.RootDirectory = "Content";
                IsMouseVisible = true;
                graphics.PreferredBackBufferWidth = 1024;
                graphics.PreferredBackBufferHeight = 768;

                screenManager = new ScreenManager(this);
                Components.Add(screenManager);
            }
            catch (Exception exception)
            {
                
            }
        }

        protected override void LoadContent()
        {
            try
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);

                screenManager.AddScreen(new SampleScreen());

            }
            catch (Exception exception)
            {
               
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            frameCounter++;

            string fps = string.Format("FPS: {0}", frameRate);

            spriteBatch.Begin();

            spriteBatch.DrawString(screenManager.Font, fps, new Vector2(screenManager.TitleSafeArea.X, screenManager.TitleSafeArea.Y), Color.White);

            spriteBatch.End();
        }


    }
}
