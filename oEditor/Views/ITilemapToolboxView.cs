using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Views
{
    public interface ITilemapToolboxView
    {
        Guid ID { get; set; }

        string TilemapName { get; set; }
        string TilemapDescription { get; set; }

        int TilemapWidth { get; set; }
        int TilemapHeight { get; set; }
    }
}
