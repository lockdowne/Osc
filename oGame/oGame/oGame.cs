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

        public oGame()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;

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
    }
}
