namespace Quilix.TestTask.App.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Server=(localdb)\\mssqllocaldb;Database=EmployeeManager;Trusted_Connection=True;";

        public static string CName { get => cName; }
    }
}