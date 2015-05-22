using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Controls;
using oEngine.Common;
using oEngine.Factories;
using oEngine.Screens;

namespace oGame
{
    public class zTestFocusMenuBR : GameScreen
    {
        Texture2D background;
        Rectangle backgroundRectangle;
        public zTestFocusMenuBR()
            : base()
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

                ContentManager content = new ContentManager(ScreenFactory.Game.Services, "Content");

                background = content.Load<Texture2D>("TestBR");
                backgroundRectangle = new Rectangle(ScreenFactory.TitleSafeArea.Right - background.Width, ScreenFactory.TitleSafeArea.Bottom - background.Height, background.Width, background.Height);

            }
            catch (Exception exception)
            {
                Logger.Log("zTestFocusMenuBR", "LoadContent", exception);
            }
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            if (backgroundRectangle.Contains(new Point(Convert.ToInt32(input.Position.X), Convert.ToInt32(input.Position.Y))))
            {

                if (IsSoftPopup)
                {
                    IsSoftPopup = false;
                }
                //put controls here
            }
            else
            {
                //release focus
                if (!IsSoftPopup)
                {
                    IsSoftPopup = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenFactory.SpriteBatch.Begin();

            ScreenFactory.SpriteBatch.Draw(background, backgroundRectangle, Color.White);

            ScreenFactory.SpriteBatch.End();

        }
    }
}
