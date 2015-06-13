using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Osc.Rotch.Engine.Managers;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Engine.Entities;
using System.Linq;
using System.Collections.Generic;

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

            var tilemap = Content.XnaDeserialize<List<Tilemap>>(@"C:\SourceCode\Rotch\Osc.Rotch.Game\Content\Tilemaps.xml").FirstOrDefault();

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
