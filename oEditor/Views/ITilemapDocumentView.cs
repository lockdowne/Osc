using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Views
{
    public interface ITilemapDocumentView
    {
        Guid ID { get; set; }
        Tilemap Tilemap { get; set; }
    }
}
