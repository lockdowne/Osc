using System.Collections;
using Osc.Rotch.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Common;

namespace Osc.Rotch.Engine.DataStructures
{
    public class CharacterCollection : List<Character>
    {
        /// <summary>
        /// Gets the first character with a turn counter over 100
        /// </summary>
        /// <returns></returns>
        public Character FindHighestTurnCounter()
        {
            Character selectedCharacter = this.MaxBy(character => character.TurnCounter);

            return selectedCharacter.TurnCounter >= Consts.TurnReady ? selectedCharacter : null;

        }

        /// <summary>
        /// Increment all characaters in the collection
        /// </summary>
        public void IncrementTurnCounter()
        {
            this.ForEach(character => character.TurnCounter += character.Speed);
        }

        /// <summary>
        /// Reset characters turn counter with the difference of over 100
        /// </summary>
        /// <param name="character"></param>
        public void ApplyDifference(Character character)
        {
            if(character.TurnCounter < Consts.TurnReady)
                return;

            character.TurnCounter = Consts.TurnReady - character.TurnCounter;
        }
    }
}
