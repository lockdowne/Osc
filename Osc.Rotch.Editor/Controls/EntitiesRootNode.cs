using Osc.Engine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Controls
{
    public class EntitiesRootNode : RadTreeNode
    {
        public Enums.EntityTypes EntityType { get; set; }

        public EntitiesRootNode()
            : base()
        {
            Image = global::Osc.Rotch.Editor.Properties.Resources.Folder_6222;
        }

        protected override void NotifyExpandedChanged(RadTreeNode node)
        {
            base.NotifyExpandedChanged(node);

            if (Expanded)
                Image = global::Osc.Rotch.Editor.Properties.Resources.Folder_6221;
            else
                Image = global::Osc.Rotch.Editor.Properties.Resources.Folder_6222;
        }
    }
}
