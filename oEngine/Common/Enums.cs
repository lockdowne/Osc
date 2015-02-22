using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Common
{
    public class Enums
    {
        public enum WorldNodeTypes
        {
            Populated,
            Cleared,
            Uncleared,
            Unexplored,
        }

        public enum TileTypes
        {
            None,
            Passable,
            Impassable,
        }

        /// <summary>
        /// Enum describes the screen transition state.
        /// </summary>
        public enum ScreenState
        {
            TransitionOn,
            Active,
            TransitionOff,
            Hidden,
        }
    }
}
