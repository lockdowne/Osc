using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace oEngine.Entities
{
    public class Trigger : IEntity
    {

        public List<Guid> Conditions { get; set; }
        public List<Guid> Actions { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
