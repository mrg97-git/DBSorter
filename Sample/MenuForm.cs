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

namespace DBSorter
{
    public partial class MenuForm : Form
    {
        Query query;
        string DBType;

        public MenuForm()
        {
            InitializeComponent();
        }

        public MenuForm(string selectTable)
        {
            InitializeComponent();
            bottomPanel.Hide();
            chooseTopPanel.Show();
            DBType = "";
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/DB.accdb") == true)
            {
                DBType = "accdb";
                query = new Query(ConnectionStringAccdb.ConnStr);
            }
            else
            {
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/DB.mdb") == true)
                {
                    DBType = "mdb";
                    query = new Query(ConnectionStringMdb.ConnStr);
                }
            }
            chooseTopLabel.Text = "Выберите таблицу";
            tableSelectPanel.Show();
            tableGridView.DataSource = query.GetTableNames();
        }

        private void SelectDBTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            string DBType = "";
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/DB.accdb") == true)
            {
                DBType = "accdb";
                this.Hide();
                Form f = new MainWindowForm(DBType);
                f.Show();
                //query = new Query(ConnectionStringAccdb.ConnStr);
            }
            else
            {
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "/DB.mdb") == true)
                {
                    DBType = "mdb";
                    this.Hide();
                    Form f = new MainWindowForm(DBType);
                    f.Show();
                    //query = new Query(ConnectionStringMdb.ConnStr);
                }
                else
                {
                    MessageBox.Show(
                    "Продолжить работу с предыдущей версией базы данных невозможно",
                    "Сообщение об ошибке",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }            
        }

        private void topLabel_Click(object sender, EventArgs e)
        {

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            bottomPanel.Hide();
            chooseTopPanel.Show();
            chooseTypeBottomPanel.Show();
        }

        private void accdbButton_Click(object sender, EventArgs e)
        {
            DBType = "accdb";
            chooseDB();
        }

        private void mdbButton_Click(object sender, EventArgs e)
        {
            DBType = "mdb";
            chooseDB();
;        }

        private void chooseDB()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"С:\";            
            //switch (DBType)
            //{
            //    case ".accdb":
            //        ofd.Filter = "*Word Documents|.accdb";
            //        ofd.FilterIndex = 1;
            //        break;
            //    case ".mdb":
            //        ofd.Filter = "*.mdb";
            //        ofd.FilterIndex = 1;
            //        break;
            //    default:
            //        break;
            //}
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (DBType)
                    {
                        case "accdb":
                            //ConnectionStringAccdb.ConnText = "Sample.Properties.Settings.ConnStr.accdb";
                            System.IO.File.Copy(ofd.FileName, System.IO.Directory.GetCurrentDirectory() + "/DB.accdb", true);
                            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DB.mdb");
                            System.IO.File.Copy(ofd.FileName, System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.accdb", true);
                            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.mdb");
                            query = new Query(ConnectionStringAccdb.ConnStr);
                            break;
                        case "mdb":
                            //ConnectionString.ConnText = "Sample.Properties.Settings.ConnStr.mdb";
                            System.IO.File.Copy(ofd.FileName, System.IO.Directory.GetCurrentDirectory() + "/DB.mdb", true);
                            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DB.accdb");
                            System.IO.File.Copy(ofd.FileName, System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.mdb", true);
                            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.accdb");
                            query = new Query(ConnectionStringMdb.ConnStr);
                            break;
                        default:
                            break;
                    }
                    tableGridView.DataSource = query.GetTableNames();
                    chooseTopLabel.Text = "Выберите таблицу";
                    chooseTypeBottomPanel.Hide();
                    tableSelectPanel.Show();                    
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show(
                    "Работа с данным типом БД не возможна на вашем компьютере. Проверьте наличие драйверов для соответствующего типа БД.",
                    "Сообщение об ошибке",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                    "Что-то пошло не так!",
                    "Сообщение об ошибке",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void tableConfirmButton_Click(object sender, EventArgs e)
        {
            selectTable();
        }

        private void selectTable()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "/LastTable.txt", false);
            writer.Write(tableGridView.Rows[tableGridView.CurrentRow.Index].Cells["TABLE_NAME"].Value.ToString());
            writer.Close();
            this.Hide();
            Form f = new MainWindowForm(DBType);
            f.Show();
        }
    }
}
