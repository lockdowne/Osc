using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace oEngine.Entities
{
    public interface ISoundEffect
    {
        [IgnoreDataMember]
        SoundEffect SoundEffect { get; set; }

        string SoundName { get; set; }
    }
}
