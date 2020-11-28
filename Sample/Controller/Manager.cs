using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBSorter.Controller;
using System.Data;
using System.IO;

namespace DBSorter.Controller
{
    class Manager
    {
        Query query; 
        Sorter sorter = new Sorter();

        public string CurrentTableName { private set; get; }
        public List<string> ColumnNames = new List<string>();
        public string IdColumnName;
        public string DBType;

        char[] RegexSymbols = new[] { '.', '^', '$', '*', '+', '?', '{', '}', '[', ']', @"\"[0], '|', '(', ')'};

        public Manager(string DBType)
        {
            this.DBType = DBType;
            System.IO.StreamReader reader = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()+"/LastTable.txt");
            CurrentTableName = reader.ReadLine();
            reader.Close();
        }

        //public void OpenDB(string fileName)
        //{
        //    string Extension = Path.GetExtension(fileName);
        //    switch (Extension)
        //    {
        //        case ".accdb":
        //            //ConnectionStringAccdb.ConnText = "Sample.Properties.Settings.ConnStr.accdb";
        //            System.IO.File.Copy(fileName, System.IO.Directory.GetCurrentDirectory()+"/DB.accdb", true);
        //            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DB.mdb");
        //            System.IO.File.Copy(fileName, System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.accdb", true);
        //            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.mdb");
        //            break;
        //        case ".mdb":
        //            //ConnectionString.ConnText = "Sample.Properties.Settings.ConnStr.mdb";
        //            System.IO.File.Copy(fileName, System.IO.Directory.GetCurrentDirectory()+"/DB.mdb", true);
        //            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DB.accdb");
        //            System.IO.File.Copy(fileName, System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.mdb", true);
        //            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.accdb");
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public void RestoreDBFromBackUp()
        {
            switch (DBType)
            {
                case "accdb":
                    //ConnectionStringAccdb.ConnText = "Sample.Properties.Settings.ConnStr.accdb";
                    System.IO.File.Copy(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.accdb", System.IO.Directory.GetCurrentDirectory() + "/DB.accdb", true);
                    break;
                case "mdb":
                    //ConnectionString.ConnText = "Sample.Properties.Settings.ConnStr.mdb";
                    System.IO.File.Copy(System.IO.Directory.GetCurrentDirectory() + "/DBBackUp.mdb", System.IO.Directory.GetCurrentDirectory() + "/DB.mdb", true);
                    break;
                default:
                    break;
            }
        }

        public void SelectTable(string tableName)
        {
            CurrentTableName = tableName;
            System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory()+"/LastTable.txt", false);
            writer.Write(CurrentTableName);
            writer.Close();
        }

        public void SetColumnNames()
        {
            int i = 0;
            do
            {
                ColumnNames.Add(query.GetColumnName(i, CurrentTableName));
                i++;
            }
            while (ColumnNames[i - 1] != "Empty");
                ColumnNames.RemoveAt(i - 1);
        }

        public void WorkOneFilter(string sortingType, string pattern, double threshold, string thresholdDirection, string columnName, bool deleteSurplus)
        {
            switch (DBType)
            {
                case "accdb":
                    query = new Query(ConnectionStringAccdb.ConnStr);
                    break;
                case "mdb":
                    query = new Query(ConnectionStringMdb.ConnStr);
                    break;
                default:
                    break;
            }
            DataTable currentTable = query.DBToDataTable(CurrentTableName);
            string resultColumnName = pattern;
            foreach (char i in RegexSymbols)
            {
                while (resultColumnName.IndexOf(i) != -1)
                {
                    resultColumnName = resultColumnName.Remove(resultColumnName.IndexOf(i), 1);
                }
            }            
            resultColumnName = resultColumnName + "_in_" + columnName;  
            
            var ParcialOverlapsList = new List<Tuple<int, string>> { };
            switch (sortingType)
            {
                case "PatternPercent":
                    ParcialOverlapsList = sorter.PatternPercent(pattern, columnName, IdColumnName, currentTable);
                    break;
                case "ContentPercent":
                    ParcialOverlapsList = sorter.ContentPercent(pattern, columnName, IdColumnName, currentTable);
                    break;
                case "SimpleRegex":
                    ParcialOverlapsList = sorter.SimpleRegex(pattern, columnName, IdColumnName, currentTable);
                    break;
                default:
                    break;
            }                  
            bool resultColumnAlreadyExist = false;
            for (int i = 0; i < currentTable.Columns.Count; i++)
            {
                if (currentTable.Columns[i].ColumnName == resultColumnName)
                {
                    resultColumnAlreadyExist = true;
                }
            }
            if (resultColumnAlreadyExist == false)
            {
                query.AddDoubleColumn(resultColumnName, CurrentTableName);
            }      
            if (deleteSurplus == true)
            {
                query.FillColumnWithThreshold(resultColumnName, IdColumnName, CurrentTableName, ParcialOverlapsList, threshold, thresholdDirection);
            }
            else
            {
                int resulti = 0;
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < currentTable.Columns.Count; j++)
                    {
                        if ("filter_" + i == (currentTable.Columns[j].ColumnName))
                        {
                            resulti = i+1;
                        }
                    }
                    
                }
                string boolColumnName = "filter_" + resulti;
                query.AddBoolColumn(boolColumnName, CurrentTableName);
                query.FillColumnWithThresholdResults(resultColumnName, IdColumnName, boolColumnName, CurrentTableName, ParcialOverlapsList, threshold, thresholdDirection);
            }
            


        }
    }
}
