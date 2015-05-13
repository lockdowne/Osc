using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Controls
{
    public class EntitiesTilemapNode : RadTreeNode
    {
        public Enums.EntityTypes EntityType { get { return Enums.EntityTypes.Tilemaps; } }

        /// <summary>
        /// Assign this ID to a new empty tilemap
        /// </summary>
        public Guid ID { get; set; }

        public event Action DoubleClicked;

        public EntitiesTilemapNode()
        {
            Image = global::oEditor.Properties.Resources.Control_433;

            //TreeView.NodeMouseDoubleClick += (sender, e) =>
            //{
            //    if(e.Node == this)
            //    {
            //        if (DoubleClicked != null)
            //            DoubleClicked();
            //    }
            //};
        }
    }
}
