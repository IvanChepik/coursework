using CourseWorkDB.Utilities;

namespace courseWork
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var connectionString = "Server=localhost;Database=agency;TrustServerCertificate=true;Trusted_Connection=True;";
            var isDbExisted = DataBaseInitService.DoesTableExist(connectionString, "users");
            if (!isDbExisted)
            {
                DataBaseInitService.InitDatabase(connectionString);
            }
            Application.Run(new AgencyApplicationContext(new AuthForm()));
        }
    }
}