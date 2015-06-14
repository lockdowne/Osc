using Osc.Rotch.Editor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    /// <summary>
    /// Represents the binding to the settings file
    /// Using anti pattern due to configuration already being static
    /// </summary>
    public partial class ThemeView : RadForm
    {
        public ThemeView()
        {
            InitializeComponent();

            // Backgrounds
            colorTilemap.Value = Configuration.Settings.TilemapBackground.ToGdiColor();
            colorTileset.Value = Configuration.Settings.TilesetBackground.ToGdiColor();

            // Selection
            colorSelectionBox.Value = Configuration.Settings.SelectionBoxColor.ToGdiColor();
            numericSelectionBox.Value = (decimal)Configuration.Settings.SelectionBoxOpacity;

            colorCollisionBox.Value = Configuration.Settings.CollisionBoxColor.ToGdiColor();
            numericCollisionBox.Value = (decimal)Configuration.Settings.CollisionBoxOpacity;

            colorCollisionLayer.Value = Configuration.Settings.CollisionLayerColor.ToGdiColor();
            numericCollisionLayer.Value = (decimal)Configuration.Settings.CollisionLayerOpacity;

            colorEraseBox.Value = Configuration.Settings.EraseBoxColor.ToGdiColor();
            numericEraseBox.Value = (decimal)Configuration.Settings.EraseBoxOpacity;

            this.FormClosed += (sender, e) =>
            {
                // Backgrounds
                Configuration.Settings.TilemapBackground = colorTilemap.Value.ToXnaColor();
                Configuration.Settings.TilesetBackground = colorTileset.Value.ToXnaColor();

                // Selection
                Configuration.Settings.SelectionBoxColor = colorSelectionBox.Value.ToXnaColor();
                Configuration.Settings.SelectionBoxOpacity = (float)numericSelectionBox.Value;

                Configuration.Settings.CollisionBoxColor = colorCollisionBox.Value.ToXnaColor();
                Configuration.Settings.CollisionBoxOpacity = (float)numericCollisionBox.Value;

                Configuration.Settings.CollisionLayerColor = colorCollisionLayer.Value.ToXnaColor();
                Configuration.Settings.CollisionLayerOpacity = (float)numericCollisionLayer.Value;

                Configuration.Settings.EraseBoxColor = colorEraseBox.Value.ToXnaColor();
                Configuration.Settings.EraseBoxOpacity = (float)numericEraseBox.Value;
            };
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
