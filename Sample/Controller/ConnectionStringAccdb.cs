﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBSorter.Controller
{
    class ConnectionStringAccdb
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Sample.Properties.Settings.ConnStr.accdb"].ConnectionString;
            }
        }
    }
}
