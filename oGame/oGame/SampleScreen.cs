using oEngine.Controls;
using oEngine.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;
using oEngine.Entities;
using Microsoft.Xna.Framework.Content;
using oGame.GameObjects;

namespace oGame
{
    public class SampleScreen : GameScreen
    {
        private Camera camera;

        private CharacterCollection charCollection;
        private Character char1;
        private Character char2;
        private Character char3;
        //private Character char4;
        //private Character char5;

        private Texture2D testTexture;
        private Sprite testSprite;

        // Constructor must have base
        public SampleScreen()
            :base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            // Only do exception handling on methods that DO NOT update constantly (like draw, handle input, and update) we are going to need to be very attentitive to making sure crashes wont occur in those methods
            try
            {
                base.LoadContent();

                // Create a local copy of content when we have large amounts of data to load
                // Use the shared ScreenFactory.Content when content is shared between screens
                // Most of the time we will want local copies 
                ContentManager content = new ContentManager(ScreenFactory.Game.Services, "Content");

                //charList = new List<TestCharacterClass>();
                //charCollection = new CharacterCollection();

                charCollection = new CharacterCollection();
                char1 = new Character(30, "David20");
                char2 = new Character(30, "John30");
                char3 = new Character(40, "Andy40");

                charCollection.Add(char1);
                charCollection.Add(char2);
                charCollection.Add(char3);

                testTexture = content.Load<Texture2D>("test-animation");
                Animation animation = new Animation();
                animation.Initialize("test-animation", content.Load<Texture2D>("test-animation"), 0, 0, 32, 32, 3, 10); 

                Animation animation2 = new Animation();
                animation2.Initialize("test-animation", content.Load<Texture2D>("test-animation"), 0, 5*32, 32, 32, 9, 1, 1.0f);

                Animation animation3 = new Animation();
                animation3.Initialize("test-animation", content.Load<Texture2D>("test-animation"), 9 * 32, 5 * 32, 32, 32, 3, 10);
                


                testSprite = new Sprite();
                testSprite.AddAnimation("Animation01", new List<Animation>().Populate(animation, animation2));
                testSprite.AddAnimation("Animation02", animation3);

                //testSprite.PlayAnimation("Animation02"); // Plays immediatly since there is no current animation
                testSprite.PlayAnimation("Animation01"); // Gets queued up to play after previous animation is done (This gets repeated until you call play animation again)
                
                testSprite.Position = new Vector2(100, 100);

                // The sprite will not update unless this is set to true
                testSprite.IsActive = true;

                // A sprite will not be seen if you dont set the below values as you can probably guess, but Im pointing it out so you can remember about them
                testSprite.IsVisible = true;
                testSprite.Scale = 1.0f;
                testSprite.Tint = Color.White; // I believe the default value of Color has an alpha of 0 so nothing will be visible

                // Due to my awesome clever method of loading textures and other unserializable objects we dont need a manager for textures

                // Load factories here
                //FontFactory.AddFont("arial12"); // all fonts go in Fonts/ folder
                //AudioFactory.AddSong("sampleSong"); // all songs go in the Audio/Songs folder
                //AudioFactory.AddSoundEffect("sampleSoundEffect"); // all sound effects go in the Audio/SoundEffects folder
                //TextureFactory.AddTexture("sampleTexture"); // all textures go in the Textures/ folder
                

                // NOTE: Factories should be populated with all content for this screen which should be read from xml when we are loading saved data, for instance a field/battle/world map
                // Screens like a menu can be hardcoded as they have no reason to be saved in xml
                // TODO: Content names will be in xml per object, but see if we can find an easy want to load factories automatically when objects are deserialized

                // Instantiate objects here
                //helloButton = new Button() { Position = new Vector2(400, 300), Width = 100, Height = 25, 
                //    Font = FontFactory.GetFont("arial12"), Text = "Hello", Tint = Color.Black, TextColor = new Color(255, 255, 255) };
                
                //helloButton.Clicked += () =>
                //{                    
                    // Do something when the button is clicked
                    // NOTE: These button controls are more useful for UI interaction                
                //};

                Console.WriteLine("here");
                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 0.1f, Position = Vector2.Zero };
            }
            catch (Exception exception)
            {
                Logger.Log("SampleScreen", "LoadContent", exception);
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            // Dont need to unload factories, that is handled in gamescreen
        }

        
        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            // Check for left click
            if(input.LeftClick)
            {
                //ExitScreen();
                //Console.WriteLine(charCollection.GetNext().Name);
                //Console.WriteLine("hello world");
            }
            
            if(input.LeftDown)
            {
                // While mouse left is held down move camera to that position
                camera.UpdatePosition(input.Position, new Vector2(-1000, -1000), new Vector2(1000, 1000));
            }

            if(input.RightClick)
            {
                ExitScreen();
                ScreenFactory.AddScreen(new SampleBS());
                //ScreenFactory.AddScreen(new MenuTest());
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            testSprite.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);

            // Clears screen
            ScreenFactory.GraphicsDevice.Clear(Color.CornflowerBlue);
                        
            // We use screen factories spritebatch as it shared among screens
            ScreenFactory.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);
            //ScreenFactory.SpriteBatch.Begin();

            testSprite.Draw(ScreenFactory.SpriteBatch);

            //ScreenFactory.SpriteBatch.Draw(testTexture, Vector2.Zero, Color.White);
            //helloButton.Draw(ScreenFactory.SpriteBatch);

            ScreenFactory.SpriteBatch.End();

            // This will tell the screen to fade in/out
            if (TransitionPosition > 0)
                ScreenFactory.FadeBackBufferToBlack(255 - TransitionAlpha);
        }

        //public TestCharacterClass whoNext(List<TestCharacterClass> charList)
        //{

        //}
    }
}
