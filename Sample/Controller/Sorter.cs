using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace DBSorter.Controller
{
    class Sorter
    {
        Regex regex;
        MatchCollection matches;       

        public List<Tuple<int, string>> PatternPercent(string pattern, string columnName, string IdColumnName, DataTable currentTable)
        {
            var ParcialOverlapsList = new List<Tuple<int, string>> { };
            for (int i = 0; i < currentTable.Rows.Count; i++)
            {
                double OverlapDegree = 0;
                string partialPattern = pattern;
                for (int j = 0; j < pattern.Length; j++)
                {
                    for (int k = 0; k < pattern.Length - j; k++)
                    {
                        partialPattern = pattern.Remove(0, j);
                        partialPattern = partialPattern.Remove(partialPattern.Length - k, k);
                        if (Convert.ToString(currentTable.Rows[i][columnName]).Contains(partialPattern) && OverlapDegree < (double)partialPattern.Length / (double)pattern.Length * 100)
                        {
                            OverlapDegree = (double)partialPattern.Length / (double)pattern.Length * 100;
                        }
                    }
                }
                ParcialOverlapsList.Add(Tuple.Create((int)currentTable.Rows[i][IdColumnName], Convert.ToString(Math.Round(OverlapDegree, 2))));
            }
            return ParcialOverlapsList;
        }

        public List<Tuple<int, string>> ContentPercent(string pattern, string columnName, string IdColumnName, DataTable currentTable)
        {
            var ParcialOverlapsList = new List<Tuple<int, string>> { };
            for (int i = 0; i < currentTable.Rows.Count; i++)
            {
                double OverlapDegree = 0;
                string partialPattern = pattern;
                for (int j = 0; j < pattern.Length; j++)
                {
                    for (int k = 0; k < pattern.Length - j; k++)
                    {
                        partialPattern = pattern.Remove(0, j);
                        partialPattern = partialPattern.Remove(partialPattern.Length - k, k);
                        if (Convert.ToString(currentTable.Rows[i][columnName]).Contains(partialPattern) && OverlapDegree < (double)partialPattern.Length / (double)Convert.ToString(currentTable.Rows[i][columnName]).Length * 100)
                        {
                            OverlapDegree = (double)partialPattern.Length / (double)Convert.ToString(currentTable.Rows[i][columnName]).Length * 100;
                        }
                    }
                }
                ParcialOverlapsList.Add(Tuple.Create((int)currentTable.Rows[i][IdColumnName], Convert.ToString(Math.Round(OverlapDegree, 2)).Replace(",", ".")));
            }
            return ParcialOverlapsList;
        }

        public List<Tuple<int, string>> SimpleRegex(string pattern, string columnName, string IdColumnName, DataTable currentTable)
        {
            var ParcialOverlapsList = new List<Tuple<int, string>> { };
            for (int i = 0; i < currentTable.Rows.Count; i++)
            {
                regex = new Regex(pattern);
                matches = regex.Matches(Convert.ToString(currentTable.Rows[i][columnName]));
                double OverlapDegree = 0;
                if (matches.Count > 0)
                {
                    OverlapDegree = 100;
                }
                ParcialOverlapsList.Add(Tuple.Create((int)currentTable.Rows[i][IdColumnName], Convert.ToString(Math.Round(OverlapDegree, 2)).Replace(",", ".")));
            }
            return ParcialOverlapsList;
        }
    }
}
