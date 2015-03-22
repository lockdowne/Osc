using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oEditor.Views
{
    public interface ITilemapView
    {
        event MouseEventHandler TilemapMouseDown;
        event MouseEventHandler TilemapMouseUp;
        event MouseEventHandler TilemapMouseMove;
        event MouseEventHandler TilemapMouseWheel;

        Tilemap Tilemap { get; set; }
    }
}
