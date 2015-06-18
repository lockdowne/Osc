using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Osc.Rotch.Engine.Managers;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Game.Screens;

namespace Osc.Rotch.Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        private ScreenManager screenManager;

        private Tilemap tilemap;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Services.AddService(typeof(SpriteBatch), spriteBatch);

            // Add components
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            try
            {
                screenManager.AddScreen(new SampleScreen()); 
            }
            catch (Exception exception)
            {

            }
        }
    }
}
