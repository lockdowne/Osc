﻿#region Using Statements
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
        #region test const
        int mapWidth = 5;
        int mapHeight = 5;
        int tileWidth = 128;
        int tileHeight = 64;
        #endregion

        #region Fields

        private Camera camera;

        private CharacterCollection characterCollection;
        private CharacterCollection playerCharacterCollection;
        private CharacterCollection enemyCharacterCollection;


        private Character jon, david, andy, nick, osc;
        private Character inPlay;

        private Texture2D textureTest;
        private Texture2D pixel;

        private Tilemap tilemap;

        private Vector2 previousMousePosition;
        private Vector2 currentMousePosition;
        private Vector2 cameraPosition;

        #endregion

        public SampleBS()
            : base()
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

                tilemap = new Tilemap();

                #region Test tilemap / character collections

                pixel = new Texture2D(ScreenFactory.GraphicsDevice, 2, 2, false, SurfaceFormat.Color);
                pixel.SetData<Color>(new Color[] { Color.White, Color.White, Color.White, Color.White });

                tilemap.Initialize("testName", "testDescription", tileWidth, tileHeight, mapWidth, mapHeight);
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

                characterCollection = new CharacterCollection();
                playerCharacterCollection = new CharacterCollection();
                enemyCharacterCollection = new CharacterCollection();

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

                characterCollection.Populate<Character>(jon, david, andy, nick, osc);
                //playerCharacterCollection.Populate<Character>(jon, david, andy, nick);
                //enemyCharacterCollection.Populate<Character>(osc);
                //characterCollection.AddRange(playerCharacterCollection);
                //characterCollection.AddRange(enemyCharacterCollection);

                //List<int> t1 = new List<int>();
                //List<int> t2 = new List<int>();
                //List<int> t3 = new List<int>();

                //t1.Populate<int>(1, 2, 5);
                //t2.Populate<int>(3, 4);
                //t3 = t1;

                //t3.AddRange(t1);
                //t3[1] = 99;

                //foreach (int blah in t3)
                //{
                //    Console.Write(blah);
                //}
                //Console.WriteLine();
                //foreach (int blah in t1)
                //{
                //    Console.Write(blah);
                //}
                //Console.WriteLine();

                #endregion

                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 0.1f, Position = Vector2.Zero };

                inPlay = characterCollection.GetNext();
                Console.WriteLine("Moving: " + inPlay.Name);
            }
            catch (Exception exception)
            {
                
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void HandleInput(oEngine.Inputs.InputState input)
        {
            base.HandleInput(input);

            Vector2 inputPosition = MathExtension.InvertMatrixAtVector(input.Position, camera.CameraTransformation);

            if (input.LeftClick)
            {
                Point inputPoint = MathExtension.IsoPixelsToCoordinate(inputPosition, tilemap.TileWidth, tilemap.TileHeight);

                if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
                {
                    inPlay.Position = MathExtension.IsoSnap(inputPosition, tileWidth, tileHeight) - new Vector2((inPlay.Bounds.Width / 2), inPlay.Bounds.Height);
                    //inPlay.Position -= (Extensions.GetBottomCenter(inPlay.Bounds) - inPlay.Position);
                }
                else
                {
                    Console.WriteLine("Unacceptable Location: " + inputPosition);
                }

                previousMousePosition = inputPosition;
            }

            if (input.RightClick)
            {
                //end turn 
                inPlay = characterCollection.GetNext();
                Console.WriteLine("Moving: " + inPlay.Name);

            }

            if (input.MiddleClick)
            {
#if DEBUG
                Console.WriteLine("Pixels: {0}", input.Position.ToString());
                Console.WriteLine("Rounded: {0}", MathExtension.IsoSnap(input.Position, tileWidth, tileHeight).ToString());
                MathExtension.IsoSelector(input.Position, input.Position + new Vector2(tileWidth, 0), tileWidth, tileHeight).ForEach(t => Console.WriteLine("IsoSelector: {0}", t));
                Console.WriteLine("Coord: {0}", MathExtension.IsoPixelsToCoordinate(inputPosition, tileWidth, tileHeight).ToString());
#endif
            }

            if (input.Move)
            {
                if (input.LeftDown && tilemap != null)
                {
                    currentMousePosition = inputPosition;

                    Vector2 difference = currentMousePosition - previousMousePosition;
                    cameraPosition += -difference;

                    camera.UpdatePosition(cameraPosition,
                        new Vector2(-(mapWidth * tileWidth), -(mapHeight * tileHeight)),
                        new Vector2(mapWidth * tileWidth, mapHeight * tileHeight));

                    // Used to remove pixels beyond bounds
                    cameraPosition = camera.Position;
                }
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterCollection.Update(gameTime);
            //TODO: update charcollection's sprite animations
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenFactory.GraphicsDevice.Clear(Color.Black);

            ScreenFactory.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            tilemap.Draw(ScreenFactory.SpriteBatch);

            characterCollection.Draw(ScreenFactory.SpriteBatch);

            ScreenFactory.SpriteBatch.End();
        }
    }
}
