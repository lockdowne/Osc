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
        event MouseEventHandler SceneMouseDown;
        event MouseEventHandler SceneMouseUp;
        event MouseEventHandler SceneMouseMove;
        event MouseEventHandler SceneMouseWheel;

        Tilemap Tilemap { get; set; }
    }
}
