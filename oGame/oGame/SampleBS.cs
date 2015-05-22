// need to redo: the position algorightm along with the one in character 

#region Using Statements
using System;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using oEngine.Aggregators;
using oEngine.Controls;
using oEngine.Common;
using oEngine.Entities;
using oEngine.Screens;
using oGame.GameObjects;
using oGame.Events;

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

        private Point SelectedTile;
        private Character SelectedCharacter;
        private Character FocusedCharacter;

        private zTestActionMenu testaction;

        private bool isCharacterSelected;
        private bool isCharacterFocused;
        private bool isTileSelected;

        private bool isCharPlacementPopedUp;
        private bool isFocusMenuPopedUp;
        private bool isSelectedMenuPopedUp;
        private bool isActionMenuPopedUp;

        #endregion 

        #region Properties

        /// <summary>
        /// Gets the current sequence state.
        /// </summary>
        public Enums.BattleScreenSequences ScreenSequence
        {
            get { return screenSequence; }
            protected set { screenSequence = value; }
        }

        Enums.BattleScreenSequences screenSequence = Enums.BattleScreenSequences.PlacementSequence;

        #endregion
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

                testaction = new zTestActionMenu();

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

                //jon.SetCoordinate(new Point(0, 0), tileWidth, tileHeight);
                //david.SetCoordinate(new Point(0, 1), tileWidth, tileHeight);
                //andy.SetCoordinate(new Point(1, 0), tileWidth, tileHeight);
                //nick.SetCoordinate(new Point(1, 1), tileWidth, tileHeight);
                //osc.SetCoordinate(new Point(0, 2), tileWidth, tileHeight);

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

                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 1f, Position = Vector2.Zero };

                inPlay = characterCollection.GetNext();
                Console.WriteLine("Moving: " + inPlay.CharacterName);
            }
            catch (Exception exception)
            {
                Logger.Log("SampleBS", "LoadContent", exception);
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
            Point inputPoint = MathExtension.IsoPixelsToCoordinate(inputPosition, tilemap.TileWidth, tilemap.TileHeight);

            #region Placement Sequence

            if (ScreenSequence == Enums.BattleScreenSequences.PlacementSequence)
            {
                if (input.LeftClick)
                {
                    if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
                    {
                        //TODO IF LOCATION IS AN ACCEPTABLE TILE and else
                        Select(inputPoint);
                    }
                    else
                    {
                        Unselect();
                    }
                }

                //if (input.RightClick)
                //{
                //    //place holder for changing Sequence
                //    isCharacterFocused = false;
                //    isCharacterSelected = false;
                //    SelectedCharacter = null;
                //    FocusedCharacter = null;
                //    ScreenSequence = Enums.BattleScreenSequences.BattleSequence;
                //}
            }

            #endregion 

            #region BattleSequence

            if (ScreenSequence == Enums.BattleScreenSequences.BattleSequence)
            {

                if (input.LeftClick)
                {
                    #region old select
                    //if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
                    //{
                    //    if (somethingFocused) //is something focused?
                    //    {
                    //        //is the one in focus, the one taking turn
                    //        if (focusedCharacter == inPlay)
                    //        {
                    //            ////bring up menu with actions
                    //            //inPlay.Position = MathExtension.IsoSnap(inputPosition, tileWidth, tileHeight);
                    //            //inPlay.Position -= (Extensions.GetBottomCenter(inPlay.Bounds) - inPlay.Position);
                    //            inPlay.SetCoordinate(inputPoint, tileWidth, tileHeight);
                    //        }
                    //        else
                    //        {
                    //            //change focus to point if its not the same
                    //            if (inputPoint != focusedTile)
                    //            {
                    //                focusedTile = inputPoint;
                    //                if (characterCollection.ContainsAtCoordinate(inputPoint))
                    //                {
                    //                    focusedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    //                    Console.WriteLine(focusedCharacter.Name + " is selected");
                    //                }
                    //                else
                    //                {
                    //                    somethingFocused = false;
                    //                    Console.WriteLine("de-selected");
                    //                }
                    //                //display
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //make the point your focus
                    //        focusedTile = inputPoint;
                    //        //is there a character at the coordinate?
                    //        if (characterCollection.ContainsAtCoordinate(inputPoint))
                    //        {
                    //            focusedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    //            somethingFocused = true;
                    //            Console.WriteLine(focusedCharacter.Name + " is selected");
                    //        }
                    //        //display
                    //    }
                    //}
                    //else
                    //{
                    //    if(somethingFocused)
                    //    {
                    //        if (focusedCharacter == inPlay)
                    //        {
                    //            inPlay.SetCoordinate(focusedTile, tileWidth, tileHeight);
                    //        }
                    //        somethingFocused = false;
                    //        Console.WriteLine("Out of Bounds, Deselected");
                    //    }
                    //}

                    #endregion

                    #region old select 2
                    if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
                    {
                        if (isCharacterSelected) //is something Selected?
                        {
                            //is the one in focus, the one taking turn
                            if (SelectedCharacter == inPlay)
                            {
                                //need to wait for action
                                inPlay.SetCoordinateToGrid(inputPoint, tileWidth, tileHeight);
                            }
                            else
                            {
                                //change focus to point if its not the same
                                if (inputPoint != SelectedTile)
                                {
                                    SelectedTile = inputPoint;

                                    if (characterCollection.ContainsAtCoordinate(inputPoint)) // is there a character at this coordinate?
                                    {
                                        SelectedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                                        Console.WriteLine(SelectedCharacter.CharacterName + " is selected");

                                        if (SelectedCharacter == inPlay)
                                        {
                                            ScreenFactory.AddScreen(testaction);
                                            Console.WriteLine("action");
                                        }
                                        ScreenFactory.AddScreen(new zTestFocusMenuBL());
                                        Console.WriteLine("BL");
                                    }
                                    else // no, so deselect 
                                    {
                                        isCharacterSelected = false;
                                        Console.WriteLine("de-selected");
                                    }
                                    //display
                                }
                            }
                        }
                        else // something is not focused yet
                        {
                            ////make the point your focus
                            //SelectedTile = inputPoint;
                            ////is there a character at the coordinate?
                            //if (characterCollection.ContainsAtCoordinate(inputPoint))
                            //{
                            //    SelectedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                            //    isCharacterSelected = true;
                            //    Console.WriteLine(SelectedCharacter.CharacterName + " is selected");

                            //    if (SelectedCharacter == inPlay)
                            //    {
                            //        ScreenFactory.AddScreen(new zTestActionMenu());
                            //        Console.WriteLine("action");
                            //    }
                            //    ScreenFactory.AddScreen(new zTestFocusMenuBL());
                            //    Console.WriteLine("BL");
                            //}
                            ////display tile?

                            //make 
                            Select(inputPoint);
                        }
                    }
                    else //clicked out of bounds
                    {
                        if (isCharacterSelected)
                        {
                            if (SelectedCharacter == inPlay)
                            {
                                inPlay.SetCoordinateToGrid(SelectedTile, tileWidth, tileHeight);
                            }
                            isCharacterSelected = false;
                            Console.WriteLine("Out of Bounds, Deselected");
                        }
                    }

                    #endregion 
                    
                    //Phase one, nothing set yet, selecting random shit, if inplay is selected bring up actionmenu then let it listen
                    if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tileWidth, tileHeight))
                    {   //phase one, selecting
                        Select(inputPoint);
                        if (SelectedCharacter == inPlay)
                        {
                            ScreenFactory.AddScreen(new zTestActionMenu());
                            isActionMenuPopedUp = true;
                        }
                        
                    }
                    else
                    {
                        //if during phase one, unselect
                        Unselect();
                    }

                    //phase two, confirming the action 
                    //depending on action, check if valid, if not keep waiting
                }

                if (input.RightClick)
                {
                    //end turn 
                    inPlay = characterCollection.GetNext();
                    Console.WriteLine(inPlay.CharacterName + "'s turn");

                    isCharacterSelected = false;
                }
            }

            #endregion 

            #region Middle Click

            if (input.MiddleClick)
            {
                
#if DEBUG
                //Console.WriteLine("Pixels: {0}", input.Position.ToString());
                //Console.WriteLine("Rounded: {0}", MathExtension.IsoSnap(input.Position, tileWidth, tileHeight).ToString());
                //MathExtension.IsoSelector(input.Position, input.Position + new Vector2(tileWidth, 0), tileWidth, tileHeight).ForEach(t => Console.WriteLine("IsoSelector: {0}", t));
                //if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
                //{
                //    Console.WriteLine("Coord: {0}", MathExtension.IsoPixelsToCoordinate(inputPosition, tileWidth, tileHeight).ToString());
                //}
#endif
                previousMousePosition = inputPosition;
            }

            if(input.Move)
            {
                if(input.MiddleDown && tilemap != null)
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

            #endregion 

            if (characterCollection.ContainsAtCoordinate(inputPoint))
            {
                
            }
            else
            {
                if (isCharacterFocused)
                {
                    //remove BR
                    Console.WriteLine("removeBR");
                    isCharacterFocused = false;
                }
            }
        }

        public void Unselect()
        {
            isTileSelected = false;
            isCharacterSelected = false;
            SelectedCharacter = null;
            //notify that object has been unselected
            //EVENT HERE
        }

        public void Select(Point inputPoint)
        {
            SelectedTile = inputPoint;
            isTileSelected = true;
            //notify that something selectable has been selected
            //EVENT HERE
            this.Publish(new SomethingSelected() { }.AsTask());

            if (isCharacterSelected) // character is already selected 
            {
                //change if different 
                if (SelectedCharacter.Coordinate != inputPoint)
                {
                    SelectedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    //notify that new selected object has CHANGED with character info characterCollection.GetCharacterAtCoordinate
                    //EVENT HERE

                }
            }
            else
            {
                //check to see if a character is on the selected tile
                if (characterCollection.ContainsAtCoordinate(inputPoint))
                {
                    SelectedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    isCharacterSelected = true;
                    //notify that a character has been selected 
                    //EVENT HERE
                }
            }
        }

        public void Unfocus()
        {
            if(isCharacterFocused)
            {
                isCharacterFocused = false;
                FocusedCharacter = null;
            }
            //notify that character is no longer focused
        }

        public void Focus(Point inputPoint)
        {
            if (isCharacterFocused) //are we already focused on a character?
            {
                if (FocusedCharacter != characterCollection.GetCharacterAtCoordinate(inputPoint)) //did focus shift to different object?
                {
                    FocusedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    //Notify the fact that character focus has been changed 
                    //EVENT HERE
                }
            }
            else // focus a character
            {
                FocusedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
            }

            if(!isCharacterFocused)
            {
                isCharacterFocused = true;
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterCollection.Update(gameTime);

            #region Chararacter Placement Sequence 

            if (ScreenSequence == Enums.BattleScreenSequences.PlacementSequence)
            {
                if (isTileSelected && !isCharPlacementPopedUp)
                {
                    ScreenFactory.AddScreen(new zTestCharSelectionPopup());
                    isCharPlacementPopedUp = true;
                    Console.WriteLine("added CharSelection");
                }

                //TODO: listen if a charSelectionPopup gets closed if so change tileSelected to false (unselect maybe) AND ischarselectionpopuped ; 
                this.Subscribe<CharacterSelected>(async p =>
                    {
                        Console.WriteLine("test");
                    });

                // TODO: need to listen for when placement is over to switch to battle
            }

            #endregion

            #region ActionMenuPopup

            if (screenSequence == Enums.BattleScreenSequences.BattleSequence && !isActionMenuPopedUp)
            {
                ScreenFactory.AddScreen(new zTestActionMenu());
                isActionMenuPopedUp = true;
            }

            //TODO: LISTEN IF actionmenu gets closed, change actionmenupopup to false, as well as change to phase2

            #endregion

            #region FocusMenuPopup

            if (isCharacterFocused && !isFocusMenuPopedUp)
            {
                ScreenFactory.AddScreen(new zTestFocusMenuBR());
                isFocusMenuPopedUp = true;
            }

            //TODO: LISTEN IF FOCUSMENU gets closed to SET FOCUSMENUPOPPEDUP TO FALSE

            #endregion

            #region SelectCharacterMenuPopup

            if (isCharacterSelected && !isSelectedMenuPopedUp)
            {
                ScreenFactory.AddScreen(new zTestFocusMenuBL());
                isSelectedMenuPopedUp = true;
            }

            //TODO: LISTEN IF BL GETS CLOSED TO SET ISSELECTEDMENUPOPED UP TO FALSE AND TO DESELECT SHIT
            #endregion


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
