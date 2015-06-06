using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Osc.Engine.Entities
{
    public interface ISoundEffect
    {
        [IgnoreDataMember]
        SoundEffect SoundEffect { get; set; }

        string SoundName { get; set; }
    }
}
