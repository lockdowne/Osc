using Osc.Rotch.Engine.Scenes;
using Osc.Rotch.Engine.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osc.Rotch.Engine.Common;
using Osc.Rotch.Game.States;
using Microsoft.Xna.Framework.Graphics;

namespace Osc.Rotch.Game.Screens
{
    public class RandomBattleScreen : GameScreen
    {
        private RandomBattleScene scene;

        private Dictionary<Enums.BattleScreenSequences, IState> states = new Dictionary<Enums.BattleScreenSequences, IState>();

        private string randomBattlePath;

        private SpriteBatch spriteBatch;

        public Enums.BattleScreenSequences CurrentState;

        

        public RandomBattleScreen(string randomBattlePath)
        {
            this.randomBattlePath = randomBattlePath;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            // scene = Serializer.Deserialize<RandomBattleScene>(randomBattlePath)
            scene = new RandomBattleScene();
            states.Add(Enums.BattleScreenSequences.Placement, new RandomBattlePlacementState(scene));
            states.Add(Enums.BattleScreenSequences.Battle, new RandomBattleEngagementState(scene));

            spriteBatch = ScreenManager.SpriteBatch;

            // Load hardcoded test objects here only
        }

        public override void HandleInput(Engine.Inputs.InputState input)
        {
            base.HandleInput(input);

            states[CurrentState].HandleInput(input);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            states[CurrentState].Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);

            states[CurrentState].Draw(spriteBatch);
        }
    }
}
