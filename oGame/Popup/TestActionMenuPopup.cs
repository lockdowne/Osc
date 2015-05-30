using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Controls;
using oEngine.Common;
using oEngine.Managers;
using oEngine.Screens;


namespace oGame.Popup
{
    public class TestActionMenuPopup : GameScreen
    {
        Texture2D background;
        Rectangle backgroundRectangle;

        public TestActionMenuPopup()
            :base()
        {
            IsSoftPopup = true;
            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();
                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                background = content.Load<Texture2D>("TestActionMenu");
                backgroundRectangle = new Rectangle((ScreenManager.TitleSafeArea.Right / 4 * 3), (ScreenManager.TitleSafeArea.Bottom / 4), background.Width, background.Height);

            }
            catch (Exception exception)
            {
                //Logger.Log("ztestActionMenu", "LoadContent", exception);
            }
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            if (!IsSoftPopup)
            {
                IsSoftPopup = true;
            }

            
            if (IsSoftPopup && input.LeftClick)
            {
                if (backgroundRectangle.Contains(new Point(Convert.ToInt32(input.Position.X), Convert.ToInt32(input.Position.Y))))
                {
                    IsSoftPopup = false;
                }
            }   ExitScreen();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(background, backgroundRectangle, Color.White);

            ScreenManager.SpriteBatch.End();
        }
    }
}
