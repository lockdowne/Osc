#region File Descrption
//------------------------------
//  CharacterCollection.cs
//
//  Game object that will handle characters


//------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osc.Engine.Common;
using Osc.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace oGame.GameObjects
{
    class CharacterCollection : List<Character>
    {

        #region Methods

        /// <summary>
        /// Retrieves the next character to take its turn (that is ready and is the fastest of the ready)
        /// </summary>
        /// <returns></returns>
        public Character GetNext()
        {
            Character characterToReturn;
            List<Character> highestTurnCounter = new List<Character>();
            List<Character> fastestSpeed = new List<Character>();

            while (!IsSomethingReady())
            {
                ProgressTurnCounter();
            }

            //find the character(s) with the highest TurnCounter in collection
            foreach (Character character in this)
            {
                if (character.IsReady)
                {
                    if (highestTurnCounter.Count <= 0) //if empty Add
                    {
                        highestTurnCounter.Add(character);
                    }
                    else
                    {
                        if (character.TurnCounter == highestTurnCounter[0].TurnCounter) // is same speed?
                        {
                            highestTurnCounter.Add(character);
                        }
                        else if (character.TurnCounter > highestTurnCounter[0].TurnCounter) //there exists something faster
                        {
                            highestTurnCounter.Clear();
                            highestTurnCounter.Add(character);
                        }
                    }
                }
            }

            // When found: remove the TurnCounter, increment all characters, return the character so that action is selected.  
            if (highestTurnCounter.Count == 1) //If count is 1, return that character
            {
                //highestTurnCounter[0].TakingTurn();
                //ProgressTurnCounter();
                //return highestTurnCounter[0];
                characterToReturn = highestTurnCounter[0];
            }
            else // Multiple chaaracters are tied for the highest TurnCounter, find fastest
            {

                // find the character with the fastest speed within highestTurnCounter
                foreach (Character character in highestTurnCounter)
                {
                    if (fastestSpeed.Count <= 0)
                    {
                        fastestSpeed.Add(character);
                    }
                    else
                    {
                        if (character.Speed == fastestSpeed[0].Speed)
                        {
                            fastestSpeed.Add(character);
                        }
                        else if (character.Speed > fastestSpeed[0].Speed)
                        {
                            fastestSpeed.Clear();
                            fastestSpeed.Add(character);
                        }
                    }
                }

                // return the fastest
                if (fastestSpeed.Count == 1) // If count is 1, return that character
                {
                    //fastestSpeed[0].TakingTurn();
                    //ProgressTurnCounter();
                    //return fastestSpeed[0];
                    characterToReturn = fastestSpeed[0];
                }
                else // Multiple characters are tied for the highest Speed
                {
                    // randomly select one of the fastest
                    fastestSpeed.Shuffle();
                    //fastestSpeed[0].TakingTurn();
                    //ProgressTurnCounter();
                    //return fastestSpeed[0];
                    characterToReturn = fastestSpeed[0];
                }
            }

            IncrementTokens(characterToReturn);
            return characterToReturn;
        }

        /// <summary>
        /// Returns true when any character in the list is ready 
        /// </summary>
        /// <returns></returns>
        public bool IsSomethingReady()
        {
            foreach (Character character in this)
            {
                if (character.IsReady)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Increments every character in characterCollection list by its speed 
        /// </summary>
        public void ProgressTurnCounter()
        {
            foreach (Character character in this)
            {
                if (!character.isDead)
                {
                    character.ProgressTurnCounter();
                }
            }
        }

        /// <summary>
        /// Returns the name of the character that is on the coordinate if it exists
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public bool ContainsAtCoordinate(Point coordinate)
        {
            foreach (Character character in this)
            {
                if ((character.Coordinate == coordinate) && character.IsActive)
                {
                    return true;
                }
            }

            return false;
        }

        public Character GetCharacterAtCoordinate(Point coordinate)
        {
            foreach (Character character in this)
            {
                if ((character.Coordinate == coordinate) && character.IsActive)
                {
                    return character;
                }
            }

            return null;
        }

        public Character GetCharacterContainingPosition(Vector2 position)
        {
            foreach (Character character in this)
            {
                if (character.Bounds.Contains(new Point(Convert.ToInt32(position.X), Convert.ToInt32(position.Y))))
                {
                    return character;
                }
            }

            return null;
        }

        public void SetAllActiveAndVisible()
        {
            foreach (Character character in this)
            {
                character.IsActive = true;
                character.IsVisible = true;
            }
        }

        public Character GetCharacterWithName(string name) // most likely need to change to entityid 
        {
            foreach (Character character in this)
            {
                if (character.CharacterName == name)
                {
                    return character;
                }
            }

            return null;
        }

        public void Update(GameTime gameTime) //most likely need to change dead
        {
            foreach (Character character in this)
            {
                character.Update(gameTime);
                if (character.isDead)
                {
                    if (character.playString != "dead")
                    {
                        character.PlayAnimation("dead");
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Character character in this)
            {
                character.Draw(spriteBatch);
            }
        }

        #endregion

        public void SetTempValues()
        {
            foreach (Character character in this)
            {
                character.HealthPool = 100;
                character.Health = 100;
            }
        }

        public void IncrementTokens(Character character)
        {
            character.ActionToken++;
            character.MoveToken++;
        }

        public void EndTurn(Character character)
        {
            character.TakingTurn();
            ProgressTurnCounter();
        }
    }
}
