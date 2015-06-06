using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Osc.Engine.Common;
using Osc.Engine.Entities;
using Osc.Engine.Screens;
using oGame.Events;
using oGame.Aggregators;

namespace oGame.Popup
{
    public class TestBottomLeftPopup : GameScreen,
        ISubscriber<BattleScreenDeselectedCharacter>, ISubscriber<BattleScreenCharacterIsSelected>
    {
        Character character = null;
        Character characterToDisplay;

        Texture2D background;
        Rectangle backgroundRectangle; 

        private readonly IEventAggregator eventAggregator;
        public TestBottomLeftPopup(Character character, IEventAggregator eventAggregator)
            :base()
        {
            IsSoftPopup = true;

            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);

            this.character = character;
            characterToDisplay = character;

            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            //BottomLeftSubscriptions();
        }

        public override void UnloadContent()
        {
            //this.Publish(new BottomLeftIsExiting() { }.AsTask());
            eventAggregator.Publish(new BottomLeftIsExiting() { });

            //BottomLeftUnsubscribe();

            base.UnloadContent();
        }

        public override void LoadContent()
        {
             try
             {
                 base.LoadContent();

                 ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                 background = content.Load<Texture2D>("TestBL");
                 backgroundRectangle = new Rectangle(ScreenManager.TitleSafeArea.Left, ScreenManager.TitleSafeArea.Bottom - background.Height, background.Width, background.Height);

             }
            catch (Exception exception)
             {
                //Logger.Log("zTestFocusMenuBL", "LoadContent", exception);
             }
        }

        public override void HandleInput(Osc.Engine.Inputs.InputState input)
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

                    Console.WriteLine("CLICKED");
                }
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterToDisplay = character;
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
        private void BottomLeftSubscriptions()
        {
            this.Subscribe<BattleScreenCharacterIsSelected>(async obj =>
            {
                var item = await obj;

                character = item.character;
            });

            this.Subscribe<BattleScreenDeselectedCharacter>(async obj =>
            {
                var item = await obj;

                ExitScreen();
            });
        }

        private void BottomLeftUnsubscribe()
        {
            this.Unsubscribe<BattleScreenCharacterIsSelected>();
            this.Unsubscribe<BattleScreenDeselectedCharacter>();
        }

        public void OnEvent(BattleScreenCharacterIsSelected e)
        {
            character = e.character;
        }

        public void OnEvent(BattleScreenDeselectedCharacter e)
        {
            ExitScreen();
        }
    }
}
