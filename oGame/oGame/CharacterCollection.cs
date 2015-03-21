using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using oEngine.Common;

namespace oGame
{
    class CharacterCollection
    {
        private List<TestCharacterClass> characterCollection;

        public CharacterCollection()
        {
            characterCollection = new List<TestCharacterClass>();
        }
        public void Add(TestCharacterClass character)
        {
            characterCollection.Add(character);
        }
        
        public TestCharacterClass GetNext()
        {
            List<TestCharacterClass> highestCT = new List<TestCharacterClass>();
            List<TestCharacterClass> fastestSpeed = new List<TestCharacterClass>();

            while(!IsSomethingReady()) 
            {
                ProgressCT();
            }
            
            //find the character(s) with the highest CT in collection
            foreach (TestCharacterClass character in characterCollection)
            {
                if (character.IsReady)
                {
                    if (highestCT.Count <= 0) //if empty Add
                    {
                        highestCT.Add(character);
                    }
                    else
                    {
                        if (character.CT == highestCT[0].CT) // is same speed?
                        {
                            highestCT.Add(character);
                        }
                        else if (character.CT > highestCT[0].CT) //there exists something faster
                        {
                            highestCT.Clear();
                            highestCT.Add(character);
                        } 
                    }
                }
            }


            if (highestCT.Count == 1)
            {
                highestCT[0].TurnSpent();
                ProgressCT();
                return highestCT[0];
            }

            //find the character with the fastest speed within highestCT
            foreach (TestCharacterClass character in highestCT)
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
                fastestSpeed[0].TurnSpent();
                ProgressCT();
                return fastestSpeed[0];
            }
            else
            {
                //randomly select one of the fastest
                MathExtension.Shuffle(fastestSpeed);
                fastestSpeed[0].TurnSpent();
                ProgressCT();
                return fastestSpeed[0];
            }
        }
    
          
        

        public bool IsSomethingReady()
        {
            foreach (TestCharacterClass character in characterCollection)
            {
                if(character.IsReady)
                {
                    return true;
                }
            }            
            return false;
        }

        public void ProgressCT()
        {
            foreach (TestCharacterClass character in characterCollection)
            {
                character.ProgressCT();
            }
        }

        public void debugGetSpeed()
        {
            foreach (TestCharacterClass character in characterCollection)
            {
                Console.WriteLine(character.CT.ToString());
            }
        }
    }
}
