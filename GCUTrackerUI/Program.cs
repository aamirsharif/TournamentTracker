using GCUTrackerLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCUTrackerLibrary;

namespace GCUTrackerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize the Database Connection
            DataConfig.InitializeConnection(DatabaseType.MSSql);
            Application.Run(new DashBoard());
        }
    }
}
