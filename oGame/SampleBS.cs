// need to redo: the position algorightm along with the one in character 

#region Using Statements

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
using oEngine.Screens;
using oGame.GameObjects;
using oGame.Events;
using oGame.Popup;

using oGame.Aggregators;

#endregion

namespace oGame
{
    public class SampleBS : GameScreen, 
        ISubscriber<ButtonPopupStartBattleClicked>, ISubscriber<ButtonPopupExecuteClicked>, ISubscriber<ButtonPopupCancelClicked>,
        ISubscriber<CharacterPlacementIsExiting>, ISubscriber<CharacterPlacementCharacterIsSelected>,
        ISubscriber<ActionMenuIsExiting>, ISubscriber<ActionMenuActionClicked>, ISubscriber<ActionMenuMoveClicked>, ISubscriber<ActionMenuWaitClicked>,
        ISubscriber<BottomLeftIsExiting>, 
        ISubscriber<BottomRightIsExiting>

    {
        #region test const

        int mapWidth = 8;
        int mapHeight = 8;
        int tileWidth = 128;
        int tileHeight = 64;

        #endregion

        #region Fields

        private Camera camera;

        private CharacterCollection characterCollection;
        private CharacterCollection playerCharacterCollection;
        private CharacterCollection tempCollection;
        //private CharacterCollection enemyCharacterCollection;

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
        private Character TargettedCharacter;

        private bool isCharacterSelected;
        private bool isCharacterHovered;
        private bool isTileSelected;
        private bool IsTargeted;

        private bool isCharPlacementPoppedUp;
        private bool isBottomRightPoppedUp;
        private bool isBottomLeftPoppedUp;
        private bool isActionMenuPoppedUp;
        private bool isButtonPoppedUp;

        private readonly IEventAggregator eventAggregator;

        private Enums.BattleScreenSequences screenSequence;
        private Enums.BattlePhases battlePhase;
        private Enums.CurrentOperation currentOperation;

        #endregion

        public SampleBS()
            : base()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1);
            TransitionOffTime = TimeSpan.FromSeconds(1);

            //BattleScreenSubscriptions();

            eventAggregator = new EventAggregator();
            eventAggregator.Subscribe(this);

        }

        public override void LoadContent()
        {
            try
            {
                base.LoadContent();
                ContentManager content = new ContentManager(ScreenManager.Game.Services, "Content");

                tilemap = new Tilemap();
                #region Test tilemap / character collections

                pixel = new Texture2D(ScreenManager.GraphicsDevice, 2, 2, false, SurfaceFormat.Color);
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
                Animation youDead = new Animation();
                youDead.Initialize("test-animation", textureTest, 3 * 32, 7 * 32, 32, 32, 3, 5);

                characterCollection = new CharacterCollection(); // most likely already carry the enemies or add enemies after char placement
                playerCharacterCollection = new CharacterCollection();

                jon = new Character(20, "John20") { deadAnimation = youDead };
                david = new Character(30, "David30") { deadAnimation = youDead };
                andy = new Character(40, "Andy40") { deadAnimation = youDead };
                nick = new Character(35, "Nick35") { deadAnimation = youDead };
                osc = new Character(40, "OSC40") { deadAnimation = youDead };

                jon.AnimationInitialize(walkingDown);
                david.AnimationInitialize(walkingLeft);
                andy.AnimationInitialize(walkingRight);
                nick.AnimationInitialize(walkingUp);
                osc.AnimationInitialize(fireball);

                playerCharacterCollection.Populate<Character>(jon, david, andy, nick, osc);
                playerCharacterCollection.SetTempValues();

                //characterCollection.Populate<Character>(jon, david, andy, nick, osc);

                #endregion

                screenSequence = Enums.BattleScreenSequences.Placement;
                battlePhase = Enums.BattlePhases.Selecting;

                camera = new Camera() { Name = "MainCamera", Zoom = 1.0f, LerpAmount = 1f, Position = Vector2.Zero };

            }
            catch (Exception exception)
            {
                //Logger.Log("SampleBS", "LoadContent", exception);
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

            if (screenSequence == Enums.BattleScreenSequences.Placement)
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
                        UnselectAll();
                    }
                }

                if (input.RightClick)
                {
                    Character tempCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                    if(tempCharacter != null)
                    {
                        characterCollection.Remove(tempCharacter);
                    }
                }
            }

            #endregion

            #region BattleSequence

            if (screenSequence == Enums.BattleScreenSequences.Battle)
            {
                //if Selecting
                if (battlePhase == Enums.BattlePhases.Selecting)
                {
                    if (input.LeftClick)
                    {
                        //Selecting phase, nothing set yet, selecting random shit, if inplay is selected bring up actionmenu then let it listen
                        if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tileWidth, tileHeight))
                        {  
                            Select(inputPoint);
                        }
                        else
                        {
                            //if during phase one, unselect
                            UnselectAll();
                        }
                    }

                    if (input.RightClick)
                    {
                        UnselectAll();
                    }
                }

                //if targetting
                if (battlePhase == Enums.BattlePhases.Targetting)
                {
                    if (input.LeftClick)
                    {
                        if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tileWidth, tileHeight))
                        {   //assuming that we only allow possible moves, else cancel
                            if (currentOperation == Enums.CurrentOperation.Move)
                            {
                                if (!characterCollection.ContainsAtCoordinate(inputPoint)) //is it empty tile?
                                {
                                    inPlay.SetCoordinateToGrid(inputPoint, tileWidth, tileHeight);
                                    ProgressBattlePhase();
                                }
                            }

                            if (currentOperation == Enums.CurrentOperation.Action)
                            {
                                if (IsAdjacentCoordinate(inPlay.Coordinate, inputPoint) && characterCollection.ContainsAtCoordinate(inputPoint))
                                {
                                    //IsTargeted = true;
                                    ProgressBattlePhase();
                                    TargettedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                                }
                            }
                        }
                        else
                        {
                            CancelOperation();
                        }
                    }

                    if (input.RightClick)
                    {
                        CancelOperation();
                    }
                }

                // if confirming 
                if (battlePhase == Enums.BattlePhases.Confirming)
                {
                    
                }
            }

            #endregion

            #region Middle Click

            if (input.MiddleClick)
            {
                Console.WriteLine("Sequence: {0} | phase: {1}", screenSequence, battlePhase);
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

            if (input.Move)
            {
                if (input.MiddleDown && tilemap != null)
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

            #region Hovering

            if (!(screenSequence == Enums.BattleScreenSequences.Battle) || !(battlePhase == Enums.BattlePhases.Confirming))
            {
                if (characterCollection.ContainsAtCoordinate(inputPoint))
                {
                    Hover(inputPoint);
                }
                else
                {
                    if (isCharacterHovered)
                    {
                        UnHover();
                    }
                }
            }

            #endregion 
        }

        public void UnselectAll()
        {
            isTileSelected = false;
            UnselectCharacter();
            UnHover();
            //notify that object has been unselected
            //this.Publish(new BattleScreenDeselectedAll() { }.AsTask());
            eventAggregator.Publish(new BattleScreenDeselectedAll() { });
        }

        public void UnselectCharacter()
        {
            isCharacterSelected = false;
            SelectedCharacter = null;

            //this.Publish(new BattleScreenDeselectedCharacter() { }.AsTask());
            eventAggregator.Publish(new BattleScreenDeselectedCharacter() { });
        }

        public void Select(Point inputPoint)
        {
            SelectedTile = inputPoint;
            isTileSelected = true;
            // notify that something selectable has been selected
            this.Publish(new BattleScreenSomethingSelected() { }.AsTask());

            if (isCharacterSelected) // character is already selected 
            {
                if (characterCollection.ContainsAtCoordinate(inputPoint)) // is there a character on selected tile?
                {
                    // change if different 
                    if (SelectedCharacter.Coordinate != SelectedTile)
                    {
                        SelectedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                        // notify that new selected object has CHANGED with character info characterCollection.GetCharacterAtCoordinate
                        // this.Publish(new BattleScreenCharacterIsSelected() { character = SelectedCharacter }.AsTask());
                        eventAggregator.Publish(new BattleScreenCharacterIsSelected() { character = SelectedCharacter });
                    }
                }
                else
                {
                    UnselectCharacter();
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
                    //this.Publish(new BattleScreenCharacterIsSelected() { character = SelectedCharacter }.AsTask());
                    eventAggregator.Publish(new BattleScreenCharacterIsSelected() { character = SelectedCharacter });
                }
            }

            if (screenSequence == Enums.BattleScreenSequences.Battle && battlePhase == Enums.BattlePhases.Selecting && SelectedCharacter == inPlay && !isActionMenuPoppedUp)
            {
                ScreenManager.AddScreen(new TestActionMenuPopup(SelectedCharacter, eventAggregator) { });
                isActionMenuPoppedUp = true;
            }
        }

        public void UnHover()
        {
            if (isCharacterHovered)
            {
                isCharacterHovered = false;
            }
            //notify that character is no longer focused
            eventAggregator.Publish(new BattleScreenCharacterNotHovered() { });
        }

        public void Hover(Point inputPoint)
        {
            if (isCharacterHovered) //are we already on a character?
            {
                if (TargettedCharacter != characterCollection.GetCharacterAtCoordinate(inputPoint)) //did focus shift to different object?
                {
                    //clear and destory hover to remake
                    UnHover();

                    TargettedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
                }
            }
            else // focus a character
            {
                TargettedCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
            }

            isCharacterHovered = true;
        }  

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            characterCollection.Update(gameTime);

            #region Character Placement Sequence

            if (screenSequence == Enums.BattleScreenSequences.Placement)
            {
                if (isTileSelected && !isCharPlacementPoppedUp)
                {
                    ScreenManager.AddScreen(new TestCharacterPlacementPopup(eventAggregator));
                    isCharPlacementPoppedUp = true;
                }    

                if (characterCollection.Count >= 1)
                {
                    if (!isButtonPoppedUp)
                    {
                        ScreenManager.AddScreen(new TestButtonPopup(eventAggregator));
                        isButtonPoppedUp = true;
                    }
                    eventAggregator.Publish(new BattleScreenCharacterCollectionNotEmpty() { });
                }
                else if (!characterCollection.Any() && isButtonPoppedUp)
                {
                    //If no chars are selected for play
                        eventAggregator.Publish(new BattleScreenCharacterCollectionNowEmpty() { });
                }
            }

            #endregion

            #region BottomRight hovered/targetted Popup

            if ((isCharacterHovered || (battlePhase == Enums.BattlePhases.Confirming && currentOperation == Enums.CurrentOperation.Action)) && !isBottomRightPoppedUp)
            {
                ScreenManager.AddScreen(new TestBottomRight(TargettedCharacter, eventAggregator));
                isBottomRightPoppedUp = true;
            }

            #endregion

            #region BottomLeft Selected Popup

            if (isCharacterSelected && !isBottomLeftPoppedUp)
            {
                ScreenManager.AddScreen(new TestBottomLeftPopup(SelectedCharacter, eventAggregator));
                isBottomLeftPoppedUp = true;
            }

            //TODO: LISTEN IF BL GETS CLOSED TO SET ISSELECTEDMENUPOPED UP TO FALSE AND TO DESELECT SHIT
            #endregion

            if (screenSequence == Enums.BattleScreenSequences.Battle && CheckEnd())
            {
                ScreenManager.AddScreen(new SampleScreen());
                ExitScreen();
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            ScreenManager.GraphicsDevice.Clear(Color.Black);

            ScreenManager.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.CameraTransformation);

            tilemap.Draw(ScreenManager.SpriteBatch);

            characterCollection.Draw(ScreenManager.SpriteBatch);

            ScreenManager.SpriteBatch.End();
        }

        public void ProgressBattlePhase()
        {
            switch(battlePhase)
            {
                case Enums.BattlePhases.Selecting:
                    battlePhase = Enums.BattlePhases.Targetting;
                    break;
                case Enums.BattlePhases.Targetting:
                    battlePhase = Enums.BattlePhases.Confirming;
                    eventAggregator.Publish(new BattleScreenConfirming() { });
                    UnHover();
                    break;
                case Enums.BattlePhases.Confirming:
                    ResetBattlePhase();
                    break;
            }
        }

        public void ResetBattlePhase()
        {
            battlePhase = Enums.BattlePhases.Selecting;
            eventAggregator.Publish(new BattleScreenNotConfirming() { });
            UnselectAll();
        }

        public bool IsAdjacentCoordinate(Point targetPoint, Point inputPoint)
        {
            if(inputPoint == new Point(targetPoint.X + 1, targetPoint.Y) || inputPoint == new Point(targetPoint.X - 1, targetPoint.Y) ||
                inputPoint == new Point(targetPoint.X, targetPoint.Y + 1) || inputPoint == new Point(targetPoint.X, targetPoint.Y - 1))
            {
                return true;
            }
            return false;
        }
        public void CancelOperation()
        {
            if (currentOperation == Enums.CurrentOperation.Move)
            {
                inPlay.SetCoordinateToGrid(SelectedTile, tileWidth, tileHeight);
            }

            ResetBattlePhase();
        }

        public void ExecuteOperation()
        {
            if (currentOperation == Enums.CurrentOperation.Move)
            {
                inPlay.MoveToken--;
            }
            
            if (currentOperation == Enums.CurrentOperation.Action)
            {
                TargettedCharacter.Health -= 25;
                inPlay.ActionToken--;
            }

            if (inPlay.MoveToken == 0 && inPlay.ActionToken == 0)
            {
                EndTurn();
            }
            else
            {
                ResetBattlePhase();
            }
        }

        public void EndTurn()
        {
            characterCollection.EndTurn(inPlay);
            ResetBattlePhase();
            inPlay = characterCollection.GetNext();
            Console.WriteLine("It is: " + inPlay.CharacterName + "'s turn");
        }

        public bool CheckEnd()
        {
            int counter = 0;

            foreach (Character character in characterCollection)
            {
                if (!character.isDead)
                {
                    counter++;
                }
            }
            return (counter == 1);
        }
            

        #region ButtonPopup Events

        public void OnEvent (ButtonPopupStartBattleClicked e)
        {
            if (screenSequence != Enums.BattleScreenSequences.Battle)
            {
                screenSequence = Enums.BattleScreenSequences.Battle;
                eventAggregator.Publish(new BattleScreenStartingBattleSequence() { });
            }
            //will probably need to add enemy units to character collection
            
            inPlay = characterCollection.GetNext();
            Console.WriteLine("It is: " + inPlay.CharacterName + "'s turn");
        }

        public void OnEvent (ButtonPopupCancelClicked e)
        {
            CancelOperation();
        }

        public void OnEvent(ButtonPopupExecuteClicked e)
        {
            ExecuteOperation();
        }

        #endregion

        #region CharacterPlacement Events

        public void OnEvent(CharacterPlacementIsExiting e)
        {
            isCharPlacementPoppedUp = false;
        }

        public void OnEvent(CharacterPlacementCharacterIsSelected e)
        {
            if (screenSequence == Enums.BattleScreenSequences.Placement)
            {
                UnselectAll();

                Character tempCharacter = characterCollection.GetCharacterAtCoordinate(SelectedTile);
                //Is a character already on the selected tile, if so remove
                if (tempCharacter != null)
                {
                    tempCharacter.IsVisible = false;
                    tempCharacter.IsActive = false;
                    characterCollection.Remove(tempCharacter);
                }

                tempCharacter = characterCollection.GetCharacterWithName(e.character.CharacterName);
                //Does selected character exist already
                if (tempCharacter == null)
                {
                    //Does not exist, add
                    tempCharacter = playerCharacterCollection.GetCharacterWithName(e.character.CharacterName);
                    tempCharacter.IsActive = true;
                    tempCharacter.IsVisible = true;
                    characterCollection.Add(tempCharacter);
                }

                tempCharacter.SetCoordinateToGrid(SelectedTile, tileWidth, tileHeight);

                //isCharPlacementPopedUp = false;
            }
        }
        
        #endregion

        #region BottomLeft Events

        public void OnEvent(BottomLeftIsExiting e)
        {
            isBottomLeftPoppedUp = false;
        }

        #endregion

        #region BottomRight Events

        public void OnEvent(BottomRightIsExiting e)
        {
            isBottomRightPoppedUp = false;
        }

        #endregion

        #region ActionMenu Events

        public void OnEvent(ActionMenuIsExiting e)
        {
            isActionMenuPoppedUp = false;
        }

        public void OnEvent(ActionMenuActionClicked e)
        {
            currentOperation = Enums.CurrentOperation.Action;
            ProgressBattlePhase();
        }

        public void OnEvent(ActionMenuMoveClicked e)
        {
            currentOperation = Enums.CurrentOperation.Move;
            ProgressBattlePhase();
        }

        public void OnEvent(ActionMenuWaitClicked e)
        {
            currentOperation = Enums.CurrentOperation.Wait;
            //progress shit
            EndTurn();
        }

        #endregion
    }
}
