using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data
{
    /// <summary>
    /// Global class which contains methods to support the database and application
    /// </summary>
    public static class DataConfig
    {
        public static IDataConnection connection { get;private  set; }

        /// <summary>
        /// Initializes the connection with the selected database type.
        /// </summary>
        /// <param name="database">Type of database selected.</param>
        public static void InitializeConnection(DatabaseType database)
        {
            if(database == DatabaseType.MSSql)
            {
                MSSqlConnector connector = new MSSqlConnector();
                connection = connector;
            }

            //New databases can be added here if required
        }

        /// <summary>
        /// Gets the connection string for the database connectivity
        /// </summary>
        /// <param name="name">Name of database.</param>
        /// <returns>Connection String.</returns>
        public static string getConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
