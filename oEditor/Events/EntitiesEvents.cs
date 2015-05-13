using oEditor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Events
{
   public class OnTilemapNodeDoubleClicked
   {
       public EntitiesTilemapNode Node { get; set; }       
   }

    public class OnCreateTilemapNode
    {
        public EntitiesRootNode Root { get; set; }
        public EntitiesTilemapNode Node { get; set; }
    }
}
