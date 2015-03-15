using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace oEngine.Entities
{
    public interface ITexture
    {
        string TextureName { get; set; }

        [IgnoreDataMember] // This doesn't force the ignore on the inherited objects
        Texture2D Texture { get; set; }
    }
}
