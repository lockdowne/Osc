using oEditor.Controls;
using oEditor.Views;
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
    #endregion
}
