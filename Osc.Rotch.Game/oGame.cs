using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Osc.Engine.Common;
using Osc.Engine.Screens;
using Osc.Engine.Entities;
using Osc.Engine.Managers;
using oGame.Components;

namespace oGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class oGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        public oGame()
        {
             graphics = new GraphicsDeviceManager(this);

             Content.RootDirectory = "Content";

             
        }

        protected override void Initialize()
        {
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);

            Services.AddService(typeof(SpriteBatch), spriteBatch);

            // Screen manager instantiation
            ScreenManager screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            // Fps counter
            Components.Add(new FpsCounter(this));

            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            base.Initialize();
        }

    }
}
