using oEditor.Controls;
using oEditor.Views;
using oEngine.Common;
using oEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace oEditor.Aggregators
{
    #region EntitiesView
    public class OnCreateEmptyTilemap
    {
        public EntitiesRootNode Root { get; set; }

        public RadContextMenu Context { get; set; }

        public Guid ID { get; set; }
    }

    public class OnDeleteTilemap
    {
        public EntitiesTilemapNode Node { get; set; }
    }

    public class OnOpenTilemap
    {
        public EntitiesTilemapNode Node { get; set; }
    }

    public class OnTilemapNodeDoubleClicked
    {
        public EntitiesTilemapNode Node { get; set; }
    }
    #endregion

    #region MainView
    public class OnMainLoaded
    {
        public IMainView View { get; set; } 
    }

    public class OnEntitiesViewLoaded
    {
        public IEntitiesView View { get; set; }
    }

    public class OnMainDockWindowAdded
    {
        public DockWindowEventArgs Args { get; set; }
    }

    public class OnMainDockWindowClosed
    {
        public DockWindowEventArgs Args { get; set; }
    }

    public class OnMainDockWindowClosing
    {
        public DockWindowCancelEventArgs Args { get; set; }
    }
    #endregion

    #region Tilemap
    public class OnTilemapMouseDown
    {
        public MouseEventArgs Args { get; set; }

        public Tilemap Tilemap { get; set; }
    }

    public class OnTilemapMouseUp
    {
        public MouseEventArgs Args { get; set; }

        public Tilemap Tilemap { get; set; }
    }

    public class OnTilemapMouseWheel
    {
        public MouseEventArgs Args { get; set; }

        public Tilemap Tilemap { get; set; }
    }

    public class OnTilemapMouseMove
    {
        public MouseEventArgs Args { get; set; }

        public Tilemap Tilemap { get; set; }
    }

    public class OnTilemapNameChanged
    {
        public string Name { get; set; }
    }

    public class OnTilemapDescriptionChanged
    {
        public string Description { get; set; }
    }

    public class OnTilemapWidthChanged
    {
        public int Width { get; set; }
    }

    public class OnTilemapHeightChanged
    {
        public int Height { get; set; }
    }

    public class OnAddTileset
    {
        public EventArgs Args { get; set; }
    }

    public class OnRemoveTileset
    {
        public TilesetPage Page { get; set; }
    }

    public class OnAddTilemapLayer
    {
        public EventArgs Args { get; set; }
    }

    public class OnRemoveTilemapLayer
    {
        public ListViewDataItem Item { get; set; }
    }

    public class OnMoveTilemapLayerUp
    {
        public ListViewDataItem Item { get; set; }
    }

    public class OnMoveTilemapLayerDown
    {
        public ListViewDataItem Item { get; set; }
    }

    // TODO: PFFFT
    public class OnMergeLayer
    {
        public ListViewDataItem Item1 { get; set; }
        public ListViewDataItem Item2 { get; set; }
    }

    public class OnRenameTilemapLayer
    {
        public ListViewDataItem Item { get; set; }
    }

    public class OnRenameTilemapLayerOK
    {
        public string LayerName { get; set; }
    }

    public class OnPaintModeClicked
    {
        public Enums.PaintModes PaintMode { get; set; }
    }

    #endregion

#region TilesetListView
    public class OnAddTilesetTexture
    {
        public RadListControl List { get; set; }
    }

    public class OnSelectTilesetTexture
    {
        public string FileName { get; set; }
    }
   
#endregion
}
