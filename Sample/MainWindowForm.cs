using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBSorter.Controller;
using System.IO;
using ClosedXML.Excel;

namespace DBSorter
{
    public partial class MainWindowForm : Form
    {
        Query query;
        Manager manager;
        bool FiltersOn = true;

        public MainWindowForm(string DBType)
        {
            InitializeComponent();            
            manager = new Manager(DBType);
            if (DBType == "accdb")
            {
                query = new Query(ConnectionStringAccdb.ConnStr);
            }
            else
            {
                if (DBType == "mdb")
                {
                    query = new Query(ConnectionStringMdb.ConnStr);
                }
            }
            dataGridView.DataSource = query.DBToDataTable(manager.CurrentTableName);
            filterLogicComboBox.SelectedIndex = 0;
            manager.IdColumnName = query.IdColumnName(manager.CurrentTableName);
            flowLayoutPanel.Controls.Add(
            new FilterUserControl
            {
                Parent = flowLayoutPanel
            });
        }

        //public Form1(string DBType)
        //{
        //    InitializeComponent();
        //    manager = new Manager();
        //    manager.DBType = DBType;
        //    switch (DBType)
        //    {
        //        case "accdb":
        //            query = new Query(ConnectionStringAccdb.ConnStr);
        //            break;
        //        case "mdb":
        //            query = new Query(ConnectionStringMdb.ConnStr);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = query.GetTableNames();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manager.SelectTable(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["TABLE_NAME"].Value.ToString());            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //manager.IdColumnName = query.IdColumnName(manager.CurrentTableName);
            //manager.WorkOneFilter(textBox5.Text, textBox6.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = query.IDColumn(manager.CurrentTableName);
            //textBox4.Text = query.IdColumnName(manager.CurrentTableName);
            //textBox4.Text = Convert.ToString(query.IDColumn(manager.CurrentTableName));
            //manager.IdColumnName = query.IdColumnName(manager.CurrentTableName);
            //manager.WorkOneFilter(textBox5.Text, textBox6.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        }

        private void addFilterButton_Click(object sender, EventArgs e)
        {
            //addFilterButton.Location = new System.Drawing.Point(215, addFilterButton.Location.Y + 50);
            //flowLayoutPanel1.Controls[0].Location = new System.Drawing.Point(215, flowLayoutPanel1.Controls[0].Location.Y + 50);
            flowLayoutPanel.Controls.Add(
            new FilterUserControl
            {
                Parent = flowLayoutPanel
            });
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChangeTableButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new MenuForm("select table");
            f.Show();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new MenuForm();
            f.Show();
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            dataGridView.Hide();
            loadingLabel.Show();
            loadingLabel.Update();
            try
            {
                int filterCount;
                switch (filterLogicComboBox.SelectedIndex)
                {
                    case 0:
                        foreach (Control ctrl in flowLayoutPanel.Controls)
                        {
                            FilterUserControl c = ctrl as FilterUserControl;
                            switch (c.comboType.SelectedIndex)
                            {
                                case 0:
                                    manager.WorkOneFilter("PatternPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, true);
                                    break;
                                case 1:
                                    manager.WorkOneFilter("ContentPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, true);
                                    break;
                                case 2:
                                    manager.WorkOneFilter("SimpleRegex", c.textPattern.Text, 1, " не менее", c.textColumn.Text, true);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 1:
                        filterCount = 0;
                        foreach (Control ctrl in flowLayoutPanel.Controls)
                        {
                            FilterUserControl c = ctrl as FilterUserControl;
                            switch (c.comboType.SelectedIndex)
                            {
                                case 0:
                                    manager.WorkOneFilter("PatternPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, false);
                                    break;
                                case 1:
                                    manager.WorkOneFilter("ContentPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, false);
                                    break;
                                case 2:
                                    manager.WorkOneFilter("SimpleRegex", c.textPattern.Text, 1, " не менее", c.textColumn.Text, false);
                                    break;
                                default:
                                    break;
                            }
                            filterCount++;
                        }
                        query.DeleteFilterdRows(manager.IdColumnName, manager.CurrentTableName, filterCount, 1);
                        break;
                    case 2:
                        filterCount = 0;
                        foreach (Control ctrl in flowLayoutPanel.Controls)
                        {
                            FilterUserControl c = ctrl as FilterUserControl;
                            switch (c.comboType.SelectedIndex)
                            {
                                case 0:
                                    manager.WorkOneFilter("PatternPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, false);
                                    break;
                                case 1:
                                    manager.WorkOneFilter("ContentPercent", c.textPattern.Text, Convert.ToDouble(c.textThreshold.Text), c.comboOrder.Text, c.textColumn.Text, false);
                                    break;
                                case 2:
                                    manager.WorkOneFilter("SimpleRegex", c.textPattern.Text, 1, " не менее", c.textColumn.Text, false);
                                    break;
                                default:
                                    break;
                            }
                            filterCount++;
                        }
                        query.DeleteFilterdRows(manager.IdColumnName, manager.CurrentTableName, filterCount, Convert.ToInt32(filterLogicTextBox.Text));
                        break;
                    default:
                        break;
                }
                dataGridView.DataSource = query.DBToDataTable(manager.CurrentTableName);
            }
            catch (Exception)
            {
                MessageBox.Show(
                "Один из фильтров заполнен некорректно.",
                "Сообщение об ошибке",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            loadingLabel.Hide();
            dataGridView.Show();
        }

        private void HideFiltersButton_Click(object sender, EventArgs e)
        {
            if (FiltersOn == true)
            {
                hideFiltersButton.BackgroundImage = Properties.Resources.ShowFiltersIcon;
                FiltersOn = false;
                dataGridView.Location = new System.Drawing.Point(80, 80);
                dataGridView.Size = new System.Drawing.Size(1070, 564);
                topRightLabel.Location = new System.Drawing.Point(500, 29);
                topLeftLabel.Hide();
                filterPanel.Hide();

            }
            else
            {
                hideFiltersButton.BackgroundImage = Properties.Resources.HideFiltersIcon;
                FiltersOn = true;
                dataGridView.Location = new System.Drawing.Point(574, 80);
                dataGridView.Size = new System.Drawing.Size(576, 564); 
                topRightLabel.Location = new System.Drawing.Point(757, 29);
                topLeftLabel.Show();
                filterPanel.Show();
            }
        }

        private void SaveDBButton_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog sfd = new SaveFileDialog();
            switch (manager.DBType)
            {
                case "accdb":
                    sfd.Filter = "Data base|*.accdb|Excel data table|*.xlsx|All Files|*.*";
                    break;
                case "mdb":
                    sfd.Filter = "Data base|*.mdb|Excel data table|*.xlsx|All Files|*.*";
                    break;
                default:
                    break;
            }            
            sfd.Title = "Save a DB";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                switch (sfd.FilterIndex)
                {
                    case 1:
                        fs.Close();
                        switch (manager.DBType)
                        {
                            case "accdb":
                                System.IO.File.Copy(System.IO.Directory.GetCurrentDirectory() + "/DB.accdb", sfd.FileName, true);
                                break;
                            case "mdb":
                                System.IO.File.Copy(System.IO.Directory.GetCurrentDirectory() + "/DB.mdb", sfd.FileName, true);
                                break;
                            default:
                                break;
                        }                        
                        break;
                    case 2:
                        fs.Close();
                        XLWorkbook wb = new XLWorkbook();
                        wb.Worksheets.Add(query.DBToDataTable(manager.CurrentTableName), "FilteredDataTable");
                        wb.SaveAs(sfd.FileName);
                        break;
                    default:
                        break;
                }                
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            manager.RestoreDBFromBackUp();
            dataGridView.DataSource = query.DBToDataTable(manager.CurrentTableName);
        }

        private void FilterLogicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterLogicComboBox.SelectedIndex == 2)
            {
                filterLogicTextBox.Show();
            }
            else
            {
                filterLogicTextBox.Hide();
            }
        }
    }
}
