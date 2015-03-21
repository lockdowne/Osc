﻿using oEngine.Controls;
using oEngine.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;
using oEngine.Entities;

namespace oGame
{
    public class SampleScreen : GameScreen
    {
        private Button helloButton;

        private Camera camera;

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
                
                helloButton.Clicked += () =>
                {                    
                    // Do something when the button is clicked
                    // NOTE: These button controls are more useful for UI interaction                
                };

                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 0.1f };
                
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
                // When its a left click see if button has been clicked
                helloButton.HandleClick(input.Position);
                ExitScreen();
            }
            
            if(input.LeftDown)
            {
                // While mouse left is held down move camera to that position
                camera.UpdatePosition(input.Position, new Vector2(-1000, -1000), new Vector2(1000, 1000));
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);

            // Clears screen
            ScreenFactory.GraphicsDevice.Clear(Color.Red);

            // We use screen factories spritebatch as it shared among screens
            ScreenFactory.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            helloButton.Draw(ScreenFactory.SpriteBatch);

            ScreenFactory.SpriteBatch.End();

            // This will tell the screen to fade in/out
            if (TransitionPosition > 0)
                ScreenFactory.FadeBackBufferToBlack(255 - TransitionAlpha);
        }
    }
}
