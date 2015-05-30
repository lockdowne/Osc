﻿using oEditor.Controls;
using oEngine.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace oEditor.Events
{
    public class OnAddTilesetTexture
    {
        public RadListControl List { get; set; }
    }

    public class OnSelectTilesetTexture
    {
        public string FileName { get; set; }
    }

    public class OnAddTileset
    {

    }

    public class OnRemoveTileset
    {
        public TilesetPage Page { get; set; }
    }

    public class OnTilePatternGenerated
    {
        public TilePattern TilePattern { get; set; }
    }
}
