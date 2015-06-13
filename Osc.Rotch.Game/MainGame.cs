using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Osc.Rotch.Engine.Managers;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using System.Collections.Generic;
using System.Linq;

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
    }
}
