using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oEditor.Views
{
    public interface ISceneView
    {
        event MouseEventHandler SceneMouseDown;
        event MouseEventHandler SceneMouseUp;
        event MouseEventHandler SceneMouseMove;
        event MouseEventHandler SceneMouseWheel;

        Scene Tilemap { get; set; }
    }
}
