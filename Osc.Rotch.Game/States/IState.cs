using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Osc.Rotch.Engine.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Game.States
{
    public interface IState
    {
        void HandleInput(InputState input);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
