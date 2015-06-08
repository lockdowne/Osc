using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Inputs;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Osc.Rotch.Engine.Scenes;

namespace Osc.Rotch.Game.States
{
    public class RandomBattlePlacementState : IState
    {
        private readonly RandomBattleScene scene;

        public RandomBattlePlacementState(RandomBattleScene scene)
        {
            this.scene = scene;
        }

        public void HandleInput(InputState input)
        {
            //if (input.LeftClick)
            //{
            //    if (MathExtension.CoordinateWithinBounds(inputPoint.X, inputPoint.Y, tilemap.Width, tilemap.Height))
            //    {
            //        //TODO IF LOCATION IS AN ACCEPTABLE TILE and else
            //        Select(inputPoint);
            //    }
            //    else
            //    {
            //        UnselectAll();
            //    }
            //}

            //if (input.RightClick)
            //{
            //    Character tempCharacter = characterCollection.GetCharacterAtCoordinate(inputPoint);
            //    if (tempCharacter != null)
            //    {
            //        characterCollection.Remove(tempCharacter);
            //    }
            //}
            if(input.LeftClick)
            {

            }
        }

        public void Update(GameTime gameTime)
        {
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
        }
    }
}
