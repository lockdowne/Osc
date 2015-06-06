using Osc.Rotch.Editor.Events;
using Osc.Engine.Aggregators;
using Osc.Engine.Common;
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

namespace Osc.Rotch.Editor.Views
{
    public partial class TilesetListView : RadForm
    {
        private readonly IEventAggregator eventAggregator;

        public RadListDataItem SelectedItem
        {
            get { return radListControl.SelectedItem; }
            set { radListControl.SelectedItem = value; }
        }

        public TilesetListView(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            InitializeComponent();

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            StartPosition = FormStartPosition.CenterScreen;

            if (!Directory.Exists(Consts.OscPaths.TexturesDirectory))
            {
                Directory.CreateDirectory(Consts.OscPaths.TexturesDirectory);
            }

            DirectoryInfo directory = new DirectoryInfo(Consts.OscPaths.TexturesDirectory);

            foreach(var file in directory.GetFiles("*.png"))
            {
                radListControl.Items.Add(file.Name);
            }

            radListControl.SelectedIndexChanged += (sender, e) =>
            {
                if (SelectedItem == null)
                    return;

                pictureBox.Image = new Bitmap(Consts.OscPaths.TexturesDirectory + @"\" + SelectedItem.Text);
            };          
        }

        private void btnAddTilesetImage_Click(object sender, EventArgs e)
        {
            this.eventAggregator.Publish(new OnAddTilesetTexture() { List = radListControl });
        }

        private void btnTilesetSelectTexture_Click(object sender, EventArgs e)
        {
            if(SelectedItem == null)
            {
                RadMessageBox.Show(Consts.AlertMessages.Messages.SelectTilesetImage, Consts.AlertMessages.Captions.SelectTilesetImage, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            this.eventAggregator.Publish(new OnSelectTilesetTexture() { FileName = SelectedItem.Text });
        }
    }
}
