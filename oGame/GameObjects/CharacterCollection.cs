﻿#region File Descrption
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
using oEngine.Common;
using oEngine.Entities;
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
            if (highestTurnCounter.Count == 1)
            {
                highestTurnCounter[0].TakingTurn();
                ProgressTurnCounter();
                return highestTurnCounter[0];
            }

            //find the character with the fastest speed within highestTurnCounter
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

            //return the fastest
            if (fastestSpeed.Count == 1)
            {
                fastestSpeed[0].TakingTurn();
                ProgressTurnCounter();
                return fastestSpeed[0];
            }
            else
            {
                //randomly select one of the fastest
                MathExtension.Shuffle(fastestSpeed);
                fastestSpeed[0].TakingTurn();
                ProgressTurnCounter();
                return fastestSpeed[0];
            }
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
                character.ProgressTurnCounter();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Character character in this)
            {
                character.Update(gameTime);
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
    }
}
