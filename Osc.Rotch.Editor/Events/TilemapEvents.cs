using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Osc.Rotch.Editor.Events
{
    public class OnTilemapMouseDown
    {
        public MouseEventArgs MouseEvent { get; set; }
    }

    public class OnTilemapMouseUp
    {
        public MouseEventArgs MouseEvent { get; set; }
    }

    public class OnTilemapMouseMove
    {
        public MouseEventArgs MouseEvent { get; set; }
    }

    public class OnTilemapMouseWheel
    {
        public MouseEventArgs MouseEvent { get; set; }
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
       
    public class OnMergeLayer
    {
        public ListViewDataItem Item1 { get; set; }
        public ListViewDataItem Item2 { get; set; }
    }

    public class OnRenameTilemapLayer
    {
        public ListViewDataItem Item { get; set; }
    }

    public class OnTilemapDocumentChanged
    {
        public DockWindow Window { get; set; }
    }

    public class OnTilemapSelectionBoxClicked
    {
        
    }

    public class OnTilemapDrawClicked
    {

    }

    public class OnTilemapFillClicked
    {

    }

    public class OnTilemapEraseClicked
    {

    }

    public class OnTilemapCollisionClicked
    {

    }

    public class OnTilemapHeightMapClicked
    {

    }

    public class OnTilemapCopyClicked
    {

    }

    public class OnTilemapCutClicked
    {

    }

    public class OnTilemapPropertiesClicked
    {

    }

    public class OnTilemapGridClicked
    {
        public ToggleState ToggleState { get; set; }
    }

    public class OnDrawModeMouseClicked
    {

    }

    public class OnEraseModeMouseClicked
    {
        public List<Vector2> Positions { get; set; }
    }

    public class OnCollisionModeMouseClicked
    {
        public List<Vector2> Positions { get; set; }
    }

    public class OnTilemapLayerVisibilityChanged
    {
        public ListViewDataItem Item { get; set; }
    }


}
