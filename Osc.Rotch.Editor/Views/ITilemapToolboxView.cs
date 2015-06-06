using oEditor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Views
{
    public interface ITilemapToolboxView
    {
        Guid ID { get; set; }

        string TilemapName { get; set; }
        string TilemapDescription { get; set; }

        int TilemapWidth { get; set; }
        int TilemapHeight { get; set; }

        TilesetPage SelectedTilesetPage { get; }

        ListViewDataItem SelectedTilemapLayer { get; }

        RadCheckedListBox TilemapLayersListBox { get; }

        RadPageView TilesetsPages { get; }

        TabStripPanel TabStrip { get; }

        void HideCloseButtonForPage(RadPageViewPage page);
    }
}
