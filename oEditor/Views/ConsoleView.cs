using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using oEditor.Events;
using oEngine.Common;

namespace oEditor.Views
{
    public class ConsoleView : ToolWindow, IConsoleView
    {
        private RadGridView radGridView1;
        private RadTextBox radTextBox1;

        public RadGridView Grid
        {
            get { return radGridView1; }
            set { radGridView1 = value; }
        }

        public RadTextBox RadTextBox
        {
            get { return radTextBox1; }
            set { radTextBox1 = value; }
        }
    
        public ConsoleView()
        {
            InitializeComponent();

            this.radGridView1.MasterTemplate.EnableSorting = true;
            this.radGridView1.SortDescriptors.Add(new Telerik.WinControls.Data.SortDescriptor()
            {
                PropertyName = "ID",
                Direction = System.ComponentModel.ListSortDirection.Descending,
            });

            this.radGridView1.ValueChanged += (sender, e) =>
            {
                    
            };

            //this.radGridView1.MasterGridViewTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            //this.radGridView1.Columns[1].BestFit(); 
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.HeaderText = "Message";
            gridViewTextBoxColumn2.Name = "Message";
            gridViewTextBoxColumn3.HeaderText = "Class";
            gridViewTextBoxColumn3.Name = "Class";
            gridViewTextBoxColumn4.HeaderText = "Method";
            gridViewTextBoxColumn4.Name = "Method";
            gridViewTextBoxColumn5.HeaderText = "Line";
            gridViewTextBoxColumn5.Name = "Line";
            gridViewTextBoxColumn6.HeaderText = "DateTime";
            gridViewTextBoxColumn6.Name = "DateTime";
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnableSorting = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(708, 290);
            this.radGridView1.TabIndex = 1;
            this.radGridView1.Text = "radGridView1";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radTextBox1.Location = new System.Drawing.Point(0, 270);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Size = new System.Drawing.Size(708, 20);
            this.radTextBox1.TabIndex = 2;
            // 
            // ConsoleView
            // 
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radGridView1);
            this.Size = new System.Drawing.Size(708, 290);
            this.Text = "Console";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Publish(new OnParseConsoleCommand() { Command = radTextBox1.Text }.AsTask());
            }
        }

     
    }
}
