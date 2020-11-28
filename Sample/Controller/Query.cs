using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace DBSorter.Controller
{
    class Query
    {
        OleDbConnection     connection;
        OleDbCommand        command;
        OleDbDataAdapter    dataAdapter;
        DataTable           bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
        }

        public DataTable DBToDataTable(string tableName)
        {
            connection.Open();
            string queryString = "SELECT * FROM " + tableName;
            dataAdapter = new OleDbDataAdapter(queryString, connection);
            bufferTable = new DataTable();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add(string WG, string WG_index, string WG_comment)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO VOC_WG(WG, WG_index, WG_comment) VALUES(@WG, @WG_index, @WG_comment)", connection);
            command.Parameters.AddWithValue("WG", WG);
            command.Parameters.AddWithValue("WG_index", WG_index);
            command.Parameters.AddWithValue("WG_comment", WG_comment);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int code_WG)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM VOC_WG WHERE code_WG = {code_WG}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string ReadCell(int column, int row, string tableName)
        {
            connection.Open();
            string queryString = "SELECT * FROM " + tableName;
            dataAdapter = new OleDbDataAdapter(queryString, connection);
            bufferTable = new DataTable();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return Convert.ToString(bufferTable.Rows[row][column]);
        }

        public void AddDoubleColumn(string columnName, string tableName)
        {
            connection.Open();
            string queryString = "ALTER TABLE " + tableName + " ADD " + columnName + " DOUBLE NULL";
            command = new OleDbCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddBoolColumn(string columnName, string tableName)
        {
            connection.Open();
            string queryString = "ALTER TABLE " + tableName + " ADD " + columnName + " BIT";
            command = new OleDbCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void FillColumn(string columnName, string idColumnName, string tableName, List<Tuple<int, string>> list)
        {
            connection.Open();
            for(int i = 0; i < list.Count; i++)
            {
                //string queryString = "INSERT INTO " + tableName + "(" + columnName + ") VALUES(" + list[i].Item2 + ") WHERE " + idColumnName + " = " + list[i].Item1;
                string queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2 + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }            
            connection.Close();
        }

        public void FillColumnWithThreshold(string columnName, string idColumnName, string tableName, List<Tuple<int, string>> list, double threshold, string thresholdDirection)
        {
            connection.Open();
            for (int i = 0; i < list.Count; i++)
            {
                //string queryString = "INSERT INTO " + tableName + "(" + columnName + ") VALUES(" + list[i].Item2 + ") WHERE " + idColumnName + " = " + list[i].Item1;
                string queryString = "";
                switch (thresholdDirection)
                {
                    case " не более":
                        if (Convert.ToDouble(list[i].Item2) <= (double)threshold)
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";                           
                        }
                        else
                        {
                            queryString = "DELETE FROM " + tableName + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        break;
                    case " не менее":
                        if (Convert.ToDouble(list[i].Item2) >= (double)threshold)
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        else
                        {
                            queryString = "DELETE FROM " + tableName + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                            break;
                    default:
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        break;
                }                
                command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void FillColumnWithThresholdResults(string columnName, string idColumnName, string boolColumnName, string tableName, List<Tuple<int, string>> list, double threshold, string thresholdDirection)
        {
            connection.Open();
            for (int i = 0; i < list.Count; i++)
            {
                //string queryString = "INSERT INTO " + tableName + "(" + columnName + ") VALUES(" + list[i].Item2 + ") WHERE " + idColumnName + " = " + list[i].Item1;
                string queryString = "";
                switch (thresholdDirection)
                {
                    case " не более":
                        if (Convert.ToDouble(list[i].Item2) <= (double)threshold)
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + ", " + boolColumnName + " = " + true + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        else
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + ", " + boolColumnName + " = " + false + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        break;
                    case " не менее":
                        if (Convert.ToDouble(list[i].Item2) >= (double)threshold)
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + ", " + boolColumnName + " = " + true + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        else
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + ", " + boolColumnName + " = " + false + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        break;
                    default:
                        {
                            queryString = "UPDATE " + tableName + " SET " + columnName + " = " + list[i].Item2.Replace(",", ".") + " WHERE " + idColumnName + " = " + list[i].Item1 + ";";
                        }
                        break;
                }
                command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void RemoveColumn(string columnName, string tableName)
        {
            connection.Open();
            string queryString = "ALTER TABLE " + tableName + " DROP " + columnName;
            command = new OleDbCommand(queryString, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string IdColumnName(string tableName)
        {
            connection.Open();
            bufferTable = new DataTable();
            bufferTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
            string answer = "";
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                if ((bool)bufferTable.Rows[i][10] == false && (int)bufferTable.Rows[i][11] == 3 && (int)bufferTable.Rows[i][15] == 10)
                {
                    answer = (string)bufferTable.Rows[i][3];
                }
            }
            connection.Close();
            return answer;
            //string id = "-1";
            //string queryString = "select COLUMN_NAME, TABLE_NAME from INFORMATION_SCHEMA.COLUMNS where COLUMNPROPERTY(object_id(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 order by TABLE_NAME";
            //command = new OleDbCommand(queryString, connection);
            //id = (string)command.ExecuteScalar();
        }

        public string GetColumnName(int column, string tableName)
        {
            connection.Open();
            string queryString = "SELECT * FROM " + tableName;
            dataAdapter = new OleDbDataAdapter(queryString, connection);
            bufferTable = new DataTable();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            string anwer = "Empty";
            if (bufferTable.Columns.Count - 1 >= column)
            {
                anwer = Convert.ToString(bufferTable.Columns[column].ColumnName);
            }
            return anwer;

        }

        public DataTable GetTableNames()
        {
            connection.Open();
            bufferTable = new DataTable();
            bufferTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            bufferTable.Columns.RemoveAt(0);
            bufferTable.Columns.RemoveAt(0);
            for (int i = 0; i < 6; i++)
            {
                bufferTable.Columns.RemoveAt(1);
            }
            connection.Close();
            return bufferTable;
        }

        public void DeleteFilterdRows(string idColumnName, string tableName, int filterCount, int requiredFilterCount)
        {
            connection.Open();
            int sumj;
            string queryString = "SELECT * FROM " + tableName;
            dataAdapter = new OleDbDataAdapter(queryString, connection);
            bufferTable = new DataTable();
            dataAdapter.Fill(bufferTable);
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                sumj = 0;
                for (int j = 0; j < filterCount; j++)
                {
                    if (Convert.ToBoolean(bufferTable.Rows[i]["filter_" + j]) == true)
                    {
                        sumj++;
                    }                        
                }
                if (sumj < requiredFilterCount)
                {
                    queryString = "DELETE FROM " + tableName + " WHERE " + idColumnName + " = " + Convert.ToInt32(bufferTable.Rows[i][idColumnName]) + ";";
                    command = new OleDbCommand(queryString, connection);
                    command.ExecuteNonQuery();
                }
            }
            for (int i = 0; i < filterCount; i++)
            {
                queryString = "ALTER TABLE " + tableName + " DROP filter_" + i;
                command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
