using oEditor.Events;
using oEngine.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace oEditor.Views
{
    public partial class TilesetListView : RadForm
    {

        public RadListDataItem SelectedItem
        {
            get { return radListControl.SelectedItem; }
            set { radListControl.SelectedItem = value; }
        }

        public TilesetListView()
        {
            InitializeComponent();

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            StartPosition = FormStartPosition.CenterScreen;

            if(!Directory.Exists(Consts.OscPaths.TilesetTexturesDirectory))
            {
                Directory.CreateDirectory(Consts.OscPaths.TilesetTexturesDirectory);
            }

            DirectoryInfo directory = new DirectoryInfo(Consts.OscPaths.TilesetTexturesDirectory);

            foreach(var file in directory.GetFiles("*.png"))
            {
                radListControl.Items.Add(file.Name);
            }

            radListControl.SelectedIndexChanged += (sender, e) =>
            {
                if (SelectedItem == null)
                    return;

                pictureBox.Image = new Bitmap(Consts.OscPaths.TilesetTexturesDirectory + @"\" + SelectedItem.Text);
            };          
        }

        private void btnAddTilesetImage_Click(object sender, EventArgs e)
        {
            this.Publish(new OnAddTilesetTexture() { List = radListControl });
        }

        private void btnTilesetSelectTexture_Click(object sender, EventArgs e)
        {
            if(SelectedItem == null)
            {
                RadMessageBox.Show(Consts.AlertMessages.Messages.SelectTilesetImage, Consts.AlertMessages.Captions.SelectTilesetImage, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            this.Publish(new OnSelectTilesetTexture() { FileName = SelectedItem.Text });
        }
    }
}
