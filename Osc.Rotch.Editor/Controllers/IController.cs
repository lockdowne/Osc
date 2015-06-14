using Osc.Rotch.Editor.Views;
using Osc.Rotch.Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Rotch.Editor.Controllers
{
    public interface IController
    {
        Guid ID { get; set; }
    }
}
