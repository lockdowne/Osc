using Microsoft.Xna.Framework;
using Osc.Rotch.Editor.Controls;
using Osc.Rotch.Engine.Entities;
using Osc.Rotch.Engine.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    public interface ITilemapAssetDocumentView
    {
        Guid ID { get; set; }
        TilemapAssetEditor TilemapAssetEditor { get; set; }

        Vector2? SelectionBoxStart { get; }
        Vector2? SelectionBoxEnd { get; }

        RadPageView TilesetPages { get; set; }
        TilesetPage SelectedTilesetPage { get; }
        ListViewDataItem SelectedTilemapLayer { get; }
        RadCheckedListBox TilemapLayersListBox { get; }

        Osc.Rotch.Engine.Common.Enums.TilemapStates TilemapState { get; set; }
        TilePattern TilePattern { get; set; }

        void HideCloseButtonForPage(RadPageViewPage page);
    }
}
