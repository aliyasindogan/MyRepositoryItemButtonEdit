using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyRepositoryItemButtonEdit
{
    public partial class Form2 : Form
    {
        private MyRepositoryItemButtonEdit ri;

        public Form2()
        {
            InitializeComponent();

            gridControl1.DataSource = GetPersonDataTable();
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[14].Visible = false;
            gridView1.Columns[16].Visible = false;
            ri = new MyRepositoryItemButtonEdit();
            ri.Buttons[0].Kind = ButtonPredefines.Glyph;
            ri.TextEditStyle = TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(ri);
            gridView1.Columns["ReaderName1"].ColumnEdit = ri;
            gridView1.Columns["ReaderName2"].ColumnEdit = ri;
            gridView1.Columns["ReaderName3"].ColumnEdit = ri;
            gridView1.Columns["ReaderName4"].ColumnEdit = ri;
            gridView1.Columns["ReaderName5"].ColumnEdit = ri;
            gridView1.Columns["ReaderName6"].ColumnEdit = ri;
            gridView1.Columns["ReaderName7"].ColumnEdit = ri;
            gridView1.Columns["ReaderName8"].ColumnEdit = ri;

            ri.ButtonClick += new ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
        }

        private DataTable GetPersonDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Readers";
            table.Columns.Add(new DataColumn("DeviceID", typeof(int)));
            table.Columns.Add(new DataColumn("DeviceName", typeof(string)));
            table.Columns.Add(new DataColumn("Reader1", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName1", typeof(string)));
            table.Columns.Add(new DataColumn("Reader2", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName2", typeof(string)));
            table.Columns.Add(new DataColumn("Reader3", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName3", typeof(string)));
            table.Columns.Add(new DataColumn("Reader4", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName4", typeof(string)));
            table.Columns.Add(new DataColumn("Reader5", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName5", typeof(string)));
            table.Columns.Add(new DataColumn("Reader6", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName6", typeof(string)));
            table.Columns.Add(new DataColumn("Reader7", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName7", typeof(string)));
            table.Columns.Add(new DataColumn("Reader8", typeof(bool)));
            table.Columns.Add(new DataColumn("ReaderName8", typeof(string)));

            string DeviceName = "Device";
            string ReaderName = "Kapı ";
            for (int i = 1; i <= 5; i++)
            {
                if (i % 2 == 0)
                {
                    table.Rows.Add(i, DeviceName + i.ToString(), 0,
                        ReaderName + "1", 1,
                        ReaderName + "2", 0,
                        ReaderName + "3", 1,
                        ReaderName + "4", 0,
                        ReaderName + "5", 1,
                        ReaderName + "6", 0,
                        ReaderName + "7", 1,
                        ReaderName + "8");
                }
                else
                {
                    table.Rows.Add(i, DeviceName + i.ToString(), 1,
                                ReaderName + "1", 0,
                                ReaderName + "2", 1,
                                ReaderName + "3", 0,
                                ReaderName + "4", 1,
                                ReaderName + "5", 0,
                                ReaderName + "6", 1,
                                ReaderName + "7", 0,
                                ReaderName + "8");
                }
            }
            return table;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MessageBox.Show(e.Button.Caption);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "ReaderName1"
                || e.Column.FieldName == "ReaderName2"
                || e.Column.FieldName == "ReaderName3"
                || e.Column.FieldName == "ReaderName4"
                || e.Column.FieldName == "ReaderName5"
                || e.Column.FieldName == "ReaderName6"
                || e.Column.FieldName == "ReaderName7"
                || e.Column.FieldName == "ReaderName8")
            {
                ButtonEditViewInfo editInfo = (ButtonEditViewInfo)((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell).ViewInfo;
                editInfo.RightButtons[0].Button.Caption = e.DisplayText;

                #region Color Code

                //if (e.CellValue.ToString() == "Kapı 1")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader1");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 2")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader2");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 3")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader3");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 4")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader4");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 5")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader5");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 6")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader6");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 7")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader7");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}
                //if (e.CellValue.ToString() == "Kapı 8")
                //{
                //    bool status1 = (bool)gridView1.GetFocusedRowCellValue("Reader8");
                //    if (status1)
                //        e.Appearance.BackColor = Color.Green;
                //    else
                //        e.Appearance.BackColor = Color.Red;
                //}

                #endregion Color Code

                Debug.WriteLine("Caption: " + e.DisplayText);
            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.FocusedColumn.FieldName == "ReaderName1"
                || view.FocusedColumn.FieldName == "ReaderName2"
                || view.FocusedColumn.FieldName == "ReaderName3"
                || view.FocusedColumn.FieldName == "ReaderName4"
                || view.FocusedColumn.FieldName == "ReaderName5"
                || view.FocusedColumn.FieldName == "ReaderName6"
                || view.FocusedColumn.FieldName == "ReaderName7"
                || view.FocusedColumn.FieldName == "ReaderName8")
            {
                ButtonEdit ed = (ButtonEdit)view.ActiveEditor;
                ed.Properties.Buttons[0].Caption = view.GetFocusedDisplayText();
                ed.Properties.Appearance.BackColor = Color.Yellow;
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
}