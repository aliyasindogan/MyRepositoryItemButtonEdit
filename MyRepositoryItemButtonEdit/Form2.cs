using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyRepositoryItemButtonEdit
{
    public partial class Form2 : Form
    {
        private MyRepositoryItemButtonEdit ri;

        public Form2()
        {
            InitializeComponent();

            gridControl1.DataSource = GetReaders();
            //gridView1.Columns[2].Visible = false;
            //gridView1.Columns[4].Visible = false;
            //gridView1.Columns[6].Visible = false;
            //gridView1.Columns[8].Visible = false;
            //gridView1.Columns[10].Visible = false;
            //gridView1.Columns[12].Visible = false;
            //gridView1.Columns[14].Visible = false;
            //gridView1.Columns[16].Visible = false;
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

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            #region Color Code

            Debug.WriteLine(
                   e.Column.FieldName + ": " + e.CellValue.ToString()
                );

            foreach (var item in GetColumnNames())
            {
                if (e.Column.FieldName == item.ReaderName)
                {
                    bool status = (bool)gridView1.GetRowCellValue(e.RowHandle, item.Reader);//Index no ya göre kontrol ediyor.
                    if (status)
                        e.Appearance.BackColor = Color.Green;
                    else
                        e.Appearance.BackColor = Color.Red;
                }
            }

            #endregion Color Code
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

                //Debug.WriteLine("Caption: " + e.DisplayText);
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

        #region Datas

        private class ColumnName
        {
            public string ReaderName { get; set; }
            public string Reader { get; set; }
        }

        private List<ColumnName> GetColumnNames()
        {
            List<ColumnName> columnNames = new List<ColumnName>();

            columnNames.Add(new ColumnName() { Reader = "Reader1", ReaderName = "ReaderName1" });
            columnNames.Add(new ColumnName() { Reader = "Reader2", ReaderName = "ReaderName2" });
            columnNames.Add(new ColumnName() { Reader = "Reader3", ReaderName = "ReaderName3" });
            columnNames.Add(new ColumnName() { Reader = "Reader4", ReaderName = "ReaderName4" });
            columnNames.Add(new ColumnName() { Reader = "Reader5", ReaderName = "ReaderName5" });
            columnNames.Add(new ColumnName() { Reader = "Reader6", ReaderName = "ReaderName6" });
            columnNames.Add(new ColumnName() { Reader = "Reader7", ReaderName = "ReaderName7" });
            columnNames.Add(new ColumnName() { Reader = "Reader8", ReaderName = "ReaderName8" });
            columnNames.Add(new ColumnName() { Reader = "Reader1", ReaderName = "ReaderName1" });
            return columnNames;
        }

        private class Reader
        {
            public int DeviceID { get; set; }
            public string DeviceName { get; set; }
            public bool Reader1 { get; set; }
            public string ReaderName1 { get; set; }
            public bool Reader2 { get; set; }
            public string ReaderName2 { get; set; }
            public bool Reader3 { get; set; }
            public string ReaderName3 { get; set; }
            public bool Reader4 { get; set; }
            public string ReaderName4 { get; set; }
            public bool Reader5 { get; set; }
            public string ReaderName5 { get; set; }
            public bool Reader6 { get; set; }
            public string ReaderName6 { get; set; }
            public bool Reader7 { get; set; }
            public string ReaderName7 { get; set; }
            public bool Reader8 { get; set; }
            public string ReaderName8 { get; set; }
        }

        private List<Reader> GetReaders()
        {
            List<Reader> readers = new List<Reader>();
            string DeviceName = "Device";
            string ReaderName = "Kapı ";
            for (int i = 1; i <= 5; i++)
            {
                if (i % 2 == 0)
                {
                    readers.Add(new Reader()
                    {
                        DeviceID = i,
                        DeviceName = DeviceName + i.ToString(),
                        Reader1 = false,
                        ReaderName1 = ReaderName + "1",
                        Reader2 = true,
                        ReaderName2 = ReaderName + "2",
                        Reader3 = false,
                        ReaderName3 = ReaderName + "3",
                        Reader4 = true,
                        ReaderName4 = ReaderName + "4",
                        Reader5 = false,
                        ReaderName5 = ReaderName + "5",
                        Reader6 = true,
                        ReaderName6 = ReaderName + "6",
                        Reader7 = false,
                        ReaderName7 = ReaderName + "7",
                        Reader8 = true,
                        ReaderName8 = ReaderName + "8"
                    });
                }
                else
                {
                    readers.Add(new Reader()
                    {
                        DeviceID = i,
                        DeviceName = DeviceName + i.ToString(),
                        Reader1 = true,
                        ReaderName1 = ReaderName + "1",
                        Reader2 = false,
                        ReaderName2 = ReaderName + "2",
                        Reader3 = true,
                        ReaderName3 = ReaderName + "3",
                        Reader4 = false,
                        ReaderName4 = ReaderName + "4",
                        Reader5 = true,
                        ReaderName5 = ReaderName + "5",
                        Reader6 = false,
                        ReaderName6 = ReaderName + "6",
                        Reader7 = true,
                        ReaderName7 = ReaderName + "7",
                        Reader8 = false,
                        ReaderName8 = ReaderName + "8"
                    });
                }
            }
            return readers;
        }

        #endregion Datas

        #region Custom RepositoryItemButtonEdit

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

        #endregion Custom RepositoryItemButtonEdit

        #region OldCode

        //private DataTable GetPersonDataTable()
        //{
        //    DataTable table = new DataTable();
        //    table.TableName = "Readers";
        //    table.Columns.Add(new DataColumn("DeviceID", typeof(int)));
        //    table.Columns.Add(new DataColumn("DeviceName", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader1", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName1", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader2", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName2", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader3", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName3", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader4", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName4", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader5", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName5", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader6", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName6", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader7", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName7", typeof(string)));
        //    table.Columns.Add(new DataColumn("Reader8", typeof(bool)));
        //    table.Columns.Add(new DataColumn("ReaderName8", typeof(string)));

        //    string DeviceName = "Device";
        //    string ReaderName = "Kapı ";
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            table.Rows.Add(i, DeviceName + i.ToString(),
        //                0, ReaderName + "1",
        //                1, ReaderName + "2",
        //                0, ReaderName + "3",
        //                1, ReaderName + "4",
        //                0, ReaderName + "5",
        //                1, ReaderName + "6",
        //                0, ReaderName + "7",
        //                1, ReaderName + "8");
        //        }
        //        else
        //        {
        //            table.Rows.Add(i, DeviceName + i.ToString(),
        //                1, ReaderName + "1",
        //                0, ReaderName + "2",
        //                1, ReaderName + "3",
        //                0, ReaderName + "4",
        //                1, ReaderName + "5",
        //                0, ReaderName + "6",
        //                1, ReaderName + "7",
        //                0, ReaderName + "8");
        //        }
        //    }
        //    return table;
        //}

        #endregion OldCode
    }
}