namespace Quilix.TestTask.App.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Server=(localdb)\\mssqllocaldb;Database=EmployeeManager;Trusted_Connection=True;";
        //Server=  (localdb)\\MSSQLLocalDB;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true

        public static string CName { get => cName; }
    }
}
