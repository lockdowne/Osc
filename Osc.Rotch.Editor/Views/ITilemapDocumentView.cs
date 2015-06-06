using Osc.Rotch.Editor.Controls;
using Osc.Engine.Entities;
using Osc.Engine.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    public interface ITilemapDocumentView
    {
        Guid ID { get; set; }
        Tilemap Tilemap { get; set; }

        RadPageView TilesetPages { get; set; }
        TilesetPage SelectedTilesetPage { get; }
        ListViewDataItem SelectedTilemapLayer { get; }
        RadCheckedListBox TilemapLayersListBox { get; }

        Osc.Engine.Common.Enums.TilemapStates TilemapState { get; set; }
        TilePattern TilePattern { get; set; }

        void HideCloseButtonForPage(RadPageViewPage page);
    }
}
