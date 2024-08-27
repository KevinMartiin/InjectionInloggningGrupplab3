using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectionInloggning
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Skapa instansen av IDatabaseService med connectionString från App.config
            IDatabaseService databaseService = new MySqlDatabaseService(connectionString);

            // Skicka instansen till Form1
            Application.Run(new Form1(databaseService));
        }
    }
}
