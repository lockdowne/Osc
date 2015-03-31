using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Controls
{
    public class EntitiesRootNode : RadTreeNode
    {
        public Enums.EditorEntities EntityType { get; set; }

        public EntitiesRootNode()
            :base()
        {
            Image = global::oEditor.Properties.Resources.Folder_6222;
        }

        protected override void NotifyExpandedChanged(RadTreeNode node)
        {
            base.NotifyExpandedChanged(node);

            if (Expanded)
                Image = global::oEditor.Properties.Resources.Folder_6221;
            else
                Image = global::oEditor.Properties.Resources.Folder_6222;
        }      
    }
}
