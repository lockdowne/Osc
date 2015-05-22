﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace oGame
{
    class TestCharacterClass
    {

        #region Constants
        const int TurnReady = 10;
        const int MaxHealthPoints = 9999;
        const int MinHealthPoints = 0;
        #endregion

        #region Fields

        #endregion

        public string Name { get; set; }
        public int Speed { get; set; }

        public int CT { get; set; }

        //public int HitPoints { get; set { MathHelper.Clamp(value, MinHealthPoints, MaxHealthPoints); } }

        public bool IsReady { get { return (CT > TurnReady); } }

        public TestCharacterClass(int charSpeed, string nombre)
        {
            Speed = charSpeed;
            Name = nombre;
        }

        public void ProgressCT()
        {
            CT += Speed;
        }

        public void TurnSpent()
        {
            CT -= TurnReady;
        }
    }
}
