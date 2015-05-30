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
using oEngine.Entities;
using oEngine.Managers;
using oEngine.Screens;
using oGame.Events;
using oGame.Aggregators;

namespace oGame.Popup
{
    public class TestBottomRight : GameScreen,
        ISubscriber<BattleScreenCharacterIsHovered>, ISubscriber<BattleScreenCharacterNotHovered>
    {
        Character character;
        Character characterToDisplay;
        Texture2D background;
        Rectangle backgroundRectangle;

        private readonly IEventAggregator eventAggregator;

        public TestBottomRight(Character character, IEventAggregator eventAggregator)
            : base()
        {
            IsSoftPopup = true;

            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);

            this.character = character;
            this.eventAggregator = eventAggregator;

            //BottomRightSubscriptions();
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();

                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                characterToDisplay = character;

                background = content.Load<Texture2D>("TestBR");
                backgroundRectangle = new Rectangle(ScreenManager.TitleSafeArea.Right - background.Width, ScreenManager.TitleSafeArea.Bottom - background.Height, background.Width, background.Height);

            }
            catch (Exception exception)
            {
                //Logger.Log("zTestFocusMenuBR", "LoadContent", exception);
            }
        }

        public override void UnloadContent()
        {
            //this.Publish(new BottomRightIsExiting() { }.AsTask());
            eventAggregator.Publish(new BottomRightIsExiting() { });

            //BottomRightUnsubscribe();

            base.UnloadContent();

            
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterToDisplay = character;
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
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(background, backgroundRectangle, Color.White);
            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, characterToDisplay.CharacterName, new Vector2(backgroundRectangle.Left, backgroundRectangle.Top), Color.White);
            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "HP: " + characterToDisplay.Health.ToString() + " / " + characterToDisplay.HealthPool.ToString(), new Vector2(backgroundRectangle.Left, backgroundRectangle.Top + 30), Color.White);
            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "CT: " + characterToDisplay.TurnCounter.ToString() + " / " + Consts.TurnReady.ToString(), new Vector2(backgroundRectangle.Left, backgroundRectangle.Top + 60), Color.White);
            
            ScreenManager.SpriteBatch.End();
        }

        public void BottomRightSubscriptions()
        {
            this.Subscribe<BattleScreenCharacterIsHovered>(async obj =>
            {
                var item = await obj;

                character = item.character;
            });

            this.Subscribe<BattleScreenCharacterNotHovered>(async obj =>
            {
                var item = await obj;

                BottomRightUnsubscribe();
                ExitScreen();
            });
        }

        public void BottomRightUnsubscribe()
        {
            this.Unsubscribe<BattleScreenCharacterIsHovered>();
            this.Unsubscribe<BattleScreenCharacterNotHovered>();
        }

        public void OnEvent(BattleScreenCharacterIsHovered e)
        {
            character = e.character;
        }

        public void OnEvent(BattleScreenCharacterNotHovered e)
        {
            ExitScreen();
        }
    }
}
