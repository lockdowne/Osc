using Osc.Rotch.Editor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Events
{
   public class OnTilemapNodeDoubleClicked
   {
       public EntitiesChildNode Node { get; set; }       
   }

    public class OnCreateTilemapNode
    {
        public EntitiesRootNode Root { get; set; }
        public EntitiesChildNode Node { get; set; }
    }

    public class OnEditTilemapNodeClicked
    {
        public EntitiesChildNode Node { get; set; }
    }

    public class OnDeleteTilemapNodeClicked
    {
        public EntitiesChildNode Node { get; set; }
    }
}
