using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quilix.TestTask.App.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=EmployeesManager";
        public static string CName { get => cName; }
    }
}
