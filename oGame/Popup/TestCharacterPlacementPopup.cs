using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Screens;
using oGame.Events;
using oGame.GameObjects;
using oGame.Aggregators;

namespace oGame.Popup
{
    class TestCharacterPlacementPopup : GameScreen, ISubscriber<BattleScreenDeselectedAll>
    {
        Texture2D background;
        Rectangle backgroundRectangle;

        private Character jon, david, andy, nick, osc;
        private CharacterCollection characterCollection;
        private Texture2D textureTest;
        private Character temp;

        private readonly IEventAggregator eventAggregator;

        #region test const
        int mapWidth = 5;
        int mapHeight = 5;
        int tileWidth = 128;
        int tileHeight = 64;
        #endregion

        public TestCharacterPlacementPopup(IEventAggregator eventAggregator)
            : base()
        {
            IsSoftPopup = true;

            TransitionOnTime = TimeSpan.FromSeconds(0);
            TransitionOffTime = TimeSpan.FromSeconds(0);
           
            //CharacterPlacementSubscriptions();
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();

                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                background = content.Load<Texture2D>("TestSelectionBG");
                backgroundRectangle = new Rectangle(ScreenManager.TitleSafeArea.Right - background.Width, ScreenManager.TitleSafeArea.Top, background.Width, background.Height);

                #region character load
                textureTest = content.Load<Texture2D>("test-animation");

                //this later needs to assigned to a character, then update/draw
                Animation walkingDown = new Animation();
                walkingDown.Initialize("test-animation", textureTest, 0, 0, 32, 32, 3, 5);
                Animation walkingLeft = new Animation();
                walkingLeft.Initialize("test-animation", textureTest, 0, 32, 32, 32, 3, 5);
                Animation walkingRight = new Animation();
                walkingRight.Initialize("test-animation", textureTest, 0, 2 * 32, 32, 32, 3, 5);
                Animation walkingUp = new Animation();
                walkingUp.Initialize("test-animation", textureTest, 0, 3 * 32, 32, 32, 3, 5);
                Animation fireball = new Animation();
                fireball.Initialize("test-animation", textureTest, 6 * 32, 7 * 32, 32, 32, 3, 5);

                characterCollection = new CharacterCollection();

                jon = new Character(20, "John20");
                david = new Character(30, "David30");
                andy = new Character(40, "Andy40");
                nick = new Character(35, "Nick35");
                osc = new Character(40, "OSC40");

                jon.AnimationInitialize(walkingDown);
                david.AnimationInitialize(walkingLeft);
                andy.AnimationInitialize(walkingRight);
                nick.AnimationInitialize(walkingUp);
                osc.AnimationInitialize(fireball);

                jon.Position = new Vector2(backgroundRectangle.Left, backgroundRectangle.Top);
                david.Position = new Vector2(backgroundRectangle.Left + david.CurrentAnimation.FrameBounds.Width * 2, backgroundRectangle.Top);
                andy.Position = new Vector2(backgroundRectangle.Left + david.CurrentAnimation.FrameBounds.Width * 4, backgroundRectangle.Top);
                nick.Position = new Vector2(backgroundRectangle.Left + david.CurrentAnimation.FrameBounds.Width * 6, backgroundRectangle.Top);
                osc.Position = new Vector2(backgroundRectangle.Left + david.CurrentAnimation.FrameBounds.Width * 8, backgroundRectangle.Top);

                characterCollection.Populate<Character>(jon, david, andy, nick, osc);
                characterCollection.SetAllActiveAndVisible();

                #endregion
            }
            catch (Exception exception)
            {
                //Logger.Log("zTestCharSelectionPopup", "LoadContent", exception);
            }
        }

        public override void UnloadContent()
        {
            //this.Publish(new CharacterPlacementIsExiting() { }.AsTask());
            eventAggregator.Publish(new CharacterPlacementIsExiting() { });
            //CharacterPlacementUnsubscribe();

            base.UnloadContent();
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            if(!IsSoftPopup)
            {
                IsSoftPopup = true;
            }

            
            if (IsSoftPopup && input.LeftClick)
            {
                if (backgroundRectangle.Contains(new Point(Convert.ToInt32(input.Position.X), Convert.ToInt32(input.Position.Y))))
                {
                    IsSoftPopup = false;
                    //handle left click stuff
                    if(characterCollection.GetCharacterContainingPosition(input.Position) != null)
                    {
                        //Console.WriteLine("clicked on " + characterCollection.GetCharacterContainingPosition(input.Position).CharacterName);
                        temp = characterCollection.GetCharacterContainingPosition(input.Position);
                        //this.Publish(new CharacterPlacementCharacterIsSelected() { character = temp }.AsTask());
                        eventAggregator.Publish(new CharacterPlacementCharacterIsSelected() { character = temp });
                        ExitScreen();
                    }
                }
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterCollection.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(background, backgroundRectangle, Color.White);
            characterCollection.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.End();

        }

        private void CharacterPlacementSubscriptions()
        {
            this.Subscribe<BattleScreenDeselectedAll>(async obj =>
            {
                var item = await obj;

                ExitScreen();
            });
        }

        private void CharacterPlacementUnsubscribe()
        {
            this.Unsubscribe<BattleScreenDeselectedAll>();
        }

        public void OnEvent(BattleScreenDeselectedAll e)
        {
            ExitScreen();
        }
    }
}
