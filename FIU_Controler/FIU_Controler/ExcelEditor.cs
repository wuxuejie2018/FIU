using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace FIU_Controler
{
    public partial class ExcelEditor : Form
    {
        String str = "";
        
        



//---------------------------------------------------
public ExcelEditor(Dictionary<string, object> dictm)
        {
            InitializeComponent();
            str = (string) dictm["ExcelPath"];
            ElPath.Text = str;
            ExcelLib.IExcel tmp1 = ExcelLib.PreExcel.GetExcel(ElPath.Text);
            if (tmp1 == null & !tmp1.Open())
            {
                MessageBox.Show("File Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ShName.DataSource = tmp1.GetWorkSheets();
            tmp1.Close();
            StRow.Text = "0";
            EXCELEdit.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                EXCELEdit.Enabled = true;//使能编辑
                ExcelLib.IExcel tmp = ExcelLib.PreExcel.GetExcel(ElPath.Text);
                if (tmp == null & !tmp.Open())
                {
                    MessageBox.Show("File Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tmp.CurrentSheetIndex = ShName.SelectedIndex;
                int columnCount = tmp.GetColumnCount();
                dataGridView1.ColumnCount = columnCount;
                int rowCount = tmp.GetRowCount() - 1;
                dataGridView1.RowCount = rowCount;
                int startRow = int.Parse(StRow.Text);
                byte[] tmprgb = new byte[3] { 255,255,255};
                for (int i = 0; i < columnCount; i++)
                {
                    dataGridView1.Columns[i].HeaderCell.Value = tmp.GetCellValue(startRow + 1, i + 1);

                }

                for (int j = 0; j < rowCount - 1; j++)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (string.IsNullOrEmpty(tmp.GetCellValue(j + startRow + 2, i + 1)))
                        {
                            dataGridView1.Rows[j].Cells[i].Value = "0";
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.FromArgb(0,255,0);
                        }
                        else
                        {
                            dataGridView1.Rows[j].Cells[i].Value = tmp.GetCellValue(j + startRow + 2, i + 1);
                            tmprgb = tmp.GetCellRGB(j + startRow + 2, i + 1);
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.FromArgb(255, tmprgb[0], tmprgb[1], tmprgb[2]);
                        }
                    }
                }
                tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)//添加行号
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y,
               dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        int TmpEnable = 0;
        private void EXCELEdit_Click(object sender, EventArgs e)
        {
            if (TmpEnable == 0)
            {
                dataGridView1.ReadOnly = false;
                TmpEnable = 1;
                EXCELEdit.Text = "Disable Edit" ;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                TmpEnable = 0;
                EXCELEdit.Text = "Enable Edit";
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelLib.IExcel tmp = ExcelLib.PreExcel.GetExcel(ElPath.Text);
                if (tmp == null)
                    MessageBox.Show("File Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                int columnCount = dataGridView1.ColumnCount;
                int rowCount = dataGridView1.RowCount;

                string[,] array = new string[rowCount, columnCount];

                for (int i = 0; i < columnCount; i++)
                {
                    array[0, i] = (string)dataGridView1.Columns[i].HeaderCell.Value;
                }

                for (int i = 1; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        array[i, j] = (string)dataGridView1.Rows[i - 1].Cells[j].Value;
                    }
                }

                string sheetName = ShName.SelectedItem.ToString();
                for (int i = 0; i < ShName.Items.Count; i++)
                {
                    if (sheetName.GetHashCode() == ShName.GetItemText(ShName.Items[i]).GetHashCode())
                    {
                       // sheetName += "(2);
                    }
                }

                if (tmp.Save(sheetName, array))
                    MessageBox.Show("File Save Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tmp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
