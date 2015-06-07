using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osc.Rotch.Engine.Inputs
{
    public class InputState
    {
        #region Fields

        private MouseState currentMouseState = new MouseState();
        private MouseState previousMouseState = new MouseState();

        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        public bool LeftClick
        {
            get { return (currentMouseState.LeftButton == ButtonState.Pressed) && (previousMouseState.LeftButton == ButtonState.Released); }
        }

        public bool RightClick
        {
            get { return (currentMouseState.RightButton == ButtonState.Pressed) && (previousMouseState.RightButton == ButtonState.Released); }
        }

        public bool MiddleClick
        {
            get { return (currentMouseState.MiddleButton == ButtonState.Pressed) && (previousMouseState.MiddleButton == ButtonState.Released); }
        }

        public bool MiddleDown
        {
            get { return (currentMouseState.MiddleButton == ButtonState.Pressed) && (previousMouseState.MiddleButton == ButtonState.Pressed); }
        }

        public bool LeftDown
        {
            get { return (currentMouseState.LeftButton == ButtonState.Pressed) && (previousMouseState.LeftButton == ButtonState.Pressed); }
        }

        public bool RightDown
        {
            get { return (currentMouseState.RightButton == ButtonState.Pressed) && (previousMouseState.RightButton == ButtonState.Pressed); }
        }

        public bool ScrollUp
        {
            get { return ((float)(previousMouseState.ScrollWheelValue - currentMouseState.ScrollWheelValue) < 0.0f); }
        }

        public bool ScrollDown
        {
            get { return ((float)(previousMouseState.ScrollWheelValue - currentMouseState.ScrollWheelValue) > 0.0f); }
        }

        public bool Move
        {
            get { return (new Vector2(previousMouseState.X, previousMouseState.Y) != new Vector2(currentMouseState.X, currentMouseState.Y)); }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Reads the latest state of the keyboard and gamepad.
        /// </summary>
        public void Update()
        {   
            previousMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
        }



        #endregion
    }
}
