using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using oEngine.Factories;
using oEngine.Common;
using oEngine.Screens;
using oEngine.Entities;

namespace oGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class oGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private ScreenFactory screenFactory;

        // Get fps
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private int frameRate = 0;
        private int frameCounter = 0;

        public oGame()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
                graphics.PreferredBackBufferWidth = 1024;
                graphics.PreferredBackBufferHeight = 768;

                screenFactory = new ScreenFactory(this);
                Components.Add(screenFactory);
            }
            catch(Exception exception)
            {
                Logger.Log("oGame", "Main", exception);
            }
        }

        protected override void LoadContent()
        {
            try
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);

                screenFactory.AddScreen(new SampleScreen());
                
            }
            catch(Exception exception)
            {
                Logger.Log("oGame", "LoadContent", exception);
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

            spriteBatch.DrawString(screenFactory.Font, fps, new Vector2(screenFactory.TitleSafeArea.X, screenFactory.TitleSafeArea.Y), Color.White);

            spriteBatch.End();
        }

        
    }
}
