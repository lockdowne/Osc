using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Controls;
using oEngine.Managers;
using oEngine.Screens;
using oGame.Aggregators;
using oGame.Events;

namespace oGame.Popup
{
    public  class TestButtonPopup : GameScreen,
        ISubscriber<BattleScreenCharacterCollectionNowEmpty>, ISubscriber<BattleScreenIsExiting>, ISubscriber<BattleScreenCharacterCollectionNotEmpty>, 
        ISubscriber<BattleScreenConfirming>, ISubscriber<BattleScreenStartingBattleSequence>, ISubscriber<BattleScreenNotConfirming>
    {
        private Button startBattleButton;
        private Button executeButton;
        private Button cancelButton;

        private Texture2D background;
        private Rectangle backgroundRectangle;

        private readonly IEventAggregator eventAggregator;

        public TestButtonPopup(IEventAggregator eventAggregator)
            :base()
        {
            IsSoftPopup = true;

            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);

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
                backgroundRectangle = new Rectangle(ScreenManager.TitleSafeArea.Right - background.Width, ScreenManager.TitleSafeArea.Bottom / 3, background.Width, background.Height);

                startBattleButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Start Battle", TextColor = Color.Black, Tint = Color.White };
                executeButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Execute", TextColor = Color.Black, Tint = Color.White };
                cancelButton = new Button() { Position = new Vector2(backgroundRectangle.X, backgroundRectangle.Y + 40), Width = background.Width, Height = 24, Font = ScreenManager.Font, Text = "Cancel", TextColor = Color.Black, Tint = Color.White };
                startBattleButton.IsActive = true;

                startBattleButton.Clicked += () =>
                    {
                        eventAggregator.Publish(new ButtonPopupStartBattleClicked() { });
                    };
                executeButton.Clicked += () =>
                    {
                        eventAggregator.Publish(new ButtonPopupExecuteClicked() { });
                    };
                cancelButton.Clicked += () =>
                    {
                        eventAggregator.Publish(new ButtonPopupCancelClicked() { });
                    };
            }
            catch (Exception exception)
            {

            }
        }

        public override void UnloadContent()
        {
            eventAggregator.Publish(new ButtonPopupIsExiting() { });

            base.UnloadContent();
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            if (!IsSoftPopup)
            {
                IsSoftPopup = true;
            }

            if(input.LeftClick)
            {
                startBattleButton.HandleClick(input.Position);

                executeButton.HandleClick(input.Position);

                cancelButton.HandleClick(input.Position);

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
            if(startBattleButton.IsActive || executeButton.IsActive || cancelButton.IsActive )
                ScreenManager.SpriteBatch.Draw(background, backgroundRectangle, Color.White);

            startBattleButton.Draw(ScreenManager.SpriteBatch);
            executeButton.Draw(ScreenManager.SpriteBatch);
            cancelButton.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.End();
        }

        public void OnEvent(BattleScreenCharacterCollectionNowEmpty e)
        {
            //startBattleButton.IsActive = false;
        }

        public void OnEvent(BattleScreenCharacterCollectionNotEmpty e)
        {
            //startBattleButton.IsActive = true;
        }

        public void OnEvent(BattleScreenStartingBattleSequence e)
        {
            startBattleButton.IsActive = false;
        }

        public void OnEvent(BattleScreenConfirming e)
        {
            executeButton.IsActive = true;
            cancelButton.IsActive = true;
        }

        public void OnEvent(BattleScreenNotConfirming e)
        {
            executeButton.IsActive = false;
            cancelButton.IsActive = false;
        }

        public void OnEvent(BattleScreenIsExiting e)
        {
            ExitScreen();
        }
    }
}
