using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Controls;
using oEngine.Entities;
using oEngine.Managers;
using oEngine.Screens;
using oGame.Aggregators;
using oGame.Events;



namespace oGame.Popup
{
    public class TestActionMenuPopup : GameScreen, ISubscriber<BattleScreenDeselectedCharacter>
    {
        private Button moveButton;
        private Button actionButton;
        private Button waitButton;

        private Texture2D background;
        private Rectangle backgroundRectangle;

        private Character character;

        private readonly IEventAggregator eventAggregator;

        public TestActionMenuPopup(Character character, IEventAggregator eventAggregator)
            :base()
        {
            IsSoftPopup = true;

            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);

            this.character = character;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();
                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                background = content.Load<Texture2D>("TestActionMenu");
                backgroundRectangle = new Rectangle((ScreenManager.TitleSafeArea.Left), (ScreenManager.TitleSafeArea.Bottom / 4), background.Width, background.Height);

                moveButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Move", TextColor = Color.Black, Tint = Color.White };
                actionButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y + 40), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Action", TextColor = Color.Black, Tint = Color.White };
                waitButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y + 80), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Wait", TextColor = Color.Black, Tint = Color.White };

                waitButton.IsActive = true;

                if (character.ActionToken >= 1)
                {
                    actionButton.IsActive = true;
                }

                if (character.MoveToken >= 1)
                {
                    moveButton.IsActive = true;
                }

                moveButton.Clicked += () =>
                {
                    eventAggregator.Publish(new ActionMenuMoveClicked() { });
                    ExitScreen();
                };
                actionButton.Clicked += () =>
                {
                    eventAggregator.Publish(new ActionMenuActionClicked() { });
                    ExitScreen();
                };
                waitButton.Clicked += () =>
                {
                    eventAggregator.Publish(new ActionMenuWaitClicked() { });
                    ExitScreen();
                };
            }
            catch (Exception exception)
            {
                //Logger.Log("ztestActionMenu", "LoadContent", exception);
            }
        }

        public override void UnloadContent()
        {
            eventAggregator.Publish(new ActionMenuIsExiting() { });

            base.UnloadContent();
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
                moveButton.HandleClick(input.Position);

                actionButton.HandleClick(input.Position);

                waitButton.HandleClick(input.Position);

                if (backgroundRectangle.Contains(new Point(Convert.ToInt32(input.Position.X), Convert.ToInt32(input.Position.Y))))
                {
                    IsSoftPopup = false;
                }
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.SpriteBatch.Begin();

            if (moveButton.IsActive || actionButton.IsActive || waitButton.IsActive)
                ScreenManager.SpriteBatch.Draw(background, backgroundRectangle, Color.White);

            moveButton.Draw(ScreenManager.SpriteBatch);
            actionButton.Draw(ScreenManager.SpriteBatch);
            waitButton.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.End();
        }

        public void OnEvent(BattleScreenDeselectedCharacter e)
        {
            ExitScreen();
        }
    }
}
