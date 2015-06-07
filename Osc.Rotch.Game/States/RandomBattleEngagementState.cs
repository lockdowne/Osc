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
    public class RandomBattleEngagementState : IState
    {
        private readonly RandomBattleScene scene;

        public RandomBattleEngagementState(RandomBattleScene scene)
        {
            this.scene = scene;
        }

        public void HandleInput(InputState input)
        {
         
        }

        public void Update(GameTime gameTime)
        {
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
        }
    }
}
