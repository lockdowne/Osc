#region Using Statements
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
#endregion 

namespace oGame
{
    public class SampleBS : GameScreen
    {
        private Camera camera;

        private CharacterCollection charCollection;
        private Character jon, david, andy, nick, osc;
        private Character currentlySelected;

        private Texture2D textureTest;
        private Texture2D pixel;

        private Tilemap tilemap;

        public SampleBS()
            :base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);
        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();
                ContentManager content = new ContentManager(ScreenFactory.Game.Services, "Content");


                pixel = new Texture2D(ScreenFactory.GraphicsDevice, 2, 2, false, SurfaceFormat.Color);
                pixel.SetData<Color>(new Color[] { Color.White, Color.White, Color.White, Color.White });

                tilemap = new Tilemap();
                tilemap.Initialize("blah", "blah", 128, 64, 20, 20);
                tilemap.IsGridVisible = true;
                tilemap.Pixel = pixel;

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

                charCollection = new CharacterCollection();

                jon = new Character(20, "John20", new Vector2(0, 0));
                david = new Character(30, "David30", new Vector2(0, 0));
                andy = new Character(40, "Andy40", new Vector2(0, 0));
                nick = new Character(35, "Nick35", new Vector2(0, 0));
                osc = new Character(40, "OSC40", new Vector2(0, 0));

                jon.AnimationInitialize(walkingDown);
                david.AnimationInitialize(walkingLeft);
                andy.AnimationInitialize(walkingRight);
                nick.AnimationInitialize(walkingUp);
                osc.AnimationInitialize(fireball);

                charCollection.Populate<Character>(jon, david, andy, nick, osc);
                

                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 0.1f, Position = Vector2.Zero };

                currentlySelected = charCollection.GetNext();
                Console.WriteLine("Moving: " + currentlySelected.Name);
            }
            catch (Exception exception)
            {
                Logger.Log("SampleScreen", "LoadContent", exception);
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            if(input.LeftClick)
            {
                currentlySelected.Position = input.Position;
            }

            if(input.RightClick)
            {
                //end turn 
                currentlySelected = charCollection.GetNext();
                Console.WriteLine("Moving: " + currentlySelected.Name);
                
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            charCollection.Update(gameTime);
            //TODO: update charcollection's sprite animations
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenFactory.GraphicsDevice.Clear(Color.Black);

            ScreenFactory.SpriteBatch.Begin();

            //spriteTest.Draw(ScreenFactory.SpriteBatch);
            tilemap.Draw(ScreenFactory.SpriteBatch);
            charCollection.Draw(ScreenFactory.SpriteBatch);
            //TODO: draw charCollection's sprite animations

            ScreenFactory.SpriteBatch.End();
        }
    }
}
