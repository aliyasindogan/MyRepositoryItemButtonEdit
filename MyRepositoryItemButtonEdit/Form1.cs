using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyRepositoryItemButtonEdit
{
    public partial class Form1 : Form
    {
        private MyRepositoryItemButtonEdit ri;

        public Form1()
        {
            InitializeComponent();

            dataTable1.Rows.Add(new object[] { "Value 1" });
            dataTable1.Rows.Add(new object[] { "Value 2" });
            dataTable1.Rows.Add(new object[] { "Value 3" });
            dataTable1.Rows.Add(new object[] { "Value 4" });

            ri = new MyRepositoryItemButtonEdit();
            ri.Buttons[0].Kind = ButtonPredefines.Glyph;
            ri.TextEditStyle = TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(ri);
            gridView1.Columns["Column1"].ColumnEdit = ri;

            ri.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
        }

        private DataTable GetPersonDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Persons";
            table.Columns.Add(new DataColumn("FirstName", typeof(string)));
            table.Columns.Add(new DataColumn("SecondName", typeof(string)));
            table.Columns.Add(new DataColumn("Age", typeof(int)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            for (int i = 0; i < 500000; i++)
            {
                string name = "Adam";
                string secondName = "Smith";
                if (i % 2 == 0)
                {
                    name = "Ben";
                    secondName = "Black";
                }
                table.Rows.Add(name, secondName, 20 + i / 2, i);
            }
            return table;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show(e.Button.Caption);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Column1")
            {
                ButtonEditViewInfo editInfo = (ButtonEditViewInfo)((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell).ViewInfo;
                editInfo.RightButtons[0].Button.Caption = e.DisplayText;
                Debug.WriteLine("Caption: " + e.DisplayText);
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.FocusedColumn.FieldName == "Column1")
            {
                ButtonEdit ed = (ButtonEdit)view.ActiveEditor;
                ed.Properties.Buttons[0].Caption = view.GetFocusedDisplayText();
            }
        }
    }

    //
    // Custom RepositoryItemButtonEdit
    //
    public class MyRepositoryItemButtonEdit : RepositoryItemButtonEdit
    {
        public override DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo CreateViewInfo()
        {
            return new MyRepositoryItemButtonEditViewInfo(this);
        }
    }

    public class MyRepositoryItemButtonEditViewInfo : ButtonEditViewInfo
    {
        public MyRepositoryItemButtonEditViewInfo(RepositoryItem item) : base(item)
        {
        }

        protected override DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs CreateButtonInfo(EditorButton button, int index)
        {
            return base.CreateButtonInfo(new MyEditorButton(), index);
        }
    }

    public class MyEditorButton : EditorButton
    {
        public MyEditorButton() : this(string.Empty)
        {
        }

        public MyEditorButton(string myCaption)
        {
            this.myCaption = myCaption;
            Kind = ButtonPredefines.Glyph;
        }

        private string myCaption = "";

        public override string Caption
        {
            get
            {
                return myCaption;
            }
            set
            {
                myCaption = value;
            }
        }
    }
}