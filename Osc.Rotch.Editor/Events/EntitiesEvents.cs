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

    public class OnTilemapPropertiesSaved
    {
        public Guid ID { get; set; }

        public string TilemapName { get; set; }
        public string TilemapDescription { get; set; }
    }

    public class OnNodeNameChanged
    {
        public EntitiesChildNode Node { get; set; }

        public string Name { get; set; }
    }
}
