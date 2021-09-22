using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlondAPI.Service
{
    public class DatabaseSettings
    {
        public DatabaseSettings()
        {
        }

        public DatabaseSettings(string collectionName, string connectionString, string databaseName)
        {
            ClientesCollectionName = collectionName;
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }

        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public interface IBlondDatabaseSettings
        {
            string CollecionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }

    }
}
