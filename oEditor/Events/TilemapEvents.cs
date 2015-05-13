using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oEditor.Events
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
}
