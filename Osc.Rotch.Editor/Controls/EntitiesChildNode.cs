using Osc.Engine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Controls
{
    public class EntitiesChildNode : RadTreeNode
    {
        public Enums.EntityTypes EntityType { get; set; }

        /// <summary>
        /// Assign this ID to a new empty tilemap
        /// </summary>
        public Guid ID { get; set; }

        public EntitiesChildNode()
        {
            Image = global::Osc.Rotch.Editor.Properties.Resources.Control_433;
        }
    }
}
