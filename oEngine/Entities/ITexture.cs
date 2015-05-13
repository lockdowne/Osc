using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oEngine.Entities
{
    public interface ITexture
    {
        string TextureName { get; set; }

        Texture2D Texture { get; set; }
    }
}
