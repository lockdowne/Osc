using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oGame.Components
{
    public class FpsCounter : DrawableGameComponent
    {
        #region Fields

        private SpriteBatch spriteBatch;

        private SpriteFont font;

        private TimeSpan elapsedTime;


        private Rectangle titleSafeArea;

        private int frameRate;
        private int frameCounter;

        #endregion
        public FpsCounter(Game game)
            :base(game)
        {
          
        }

        protected override void LoadContent()
        {   
            try
            {
                spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

                font = Game.Content.Load<SpriteFont>("Fonts/arial12");

                titleSafeArea = new Rectangle(
             (int)Math.Floor(GraphicsDevice.Viewport.X +
                GraphicsDevice.Viewport.Width * 0.05f),
             (int)Math.Floor(GraphicsDevice.Viewport.Y +
                GraphicsDevice.Viewport.Height * 0.05f),
             (int)Math.Floor(GraphicsDevice.Viewport.Width * 0.9f),
             (int)Math.Floor(GraphicsDevice.Viewport.Height * 0.9f));
            }
            catch(Exception e)
            {
               
            }

            base.LoadContent();         
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            frameCounter++;

            string fps = string.Format("FPS: {0}", frameRate);

            spriteBatch.Begin();

            spriteBatch.DrawString(font, fps, new Vector2(titleSafeArea.X, titleSafeArea.Y), Color.White);

            spriteBatch.End();

            
        }


    }
}
