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

        /// <summary>
        /// Enum describes possible windows in oEditor
        /// </summary>
        public enum EditorWindows
        {
            Console,
            Entities,
            Project,
            Toolbox,
        }

        /// <summary>
        /// Enum describes entity types in oEditor
        /// </summary>
        public enum EditorEntities
        {
            Characters,
            Items,
            Quests,
            Tilemaps,
            Nodes,
            BattleScene,
            FreeRoamScene,
            RandomBattleScene,
        }

        public enum LayerTypes
        {
            Visual,
            Trigger,
            Movement,
            Placement,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PlacementType
        {
            Placeable,
            UnPlaceable,
        }
    }
}
