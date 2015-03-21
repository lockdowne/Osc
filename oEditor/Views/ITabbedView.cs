using oEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEditor.Views
{
    public interface ITabbedView
    {
        Guid ID { get; set; }

        Enums.EditorEntities EntityType { get; set; }
    }
}
