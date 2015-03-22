using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Views
{
    public interface ITilemapToolsView
    {
        RadPageViewPageCollection Pages { get; }

        event Action AddTilesetClicked;
        event Action DeleteTilesetClicked;
        event Action AddLayerClicked;
        event Action DeleteLayerClicked;
        event Action MoveLayerUpClicked;
        event Action MoveLayerDownClicked;
    }
}
