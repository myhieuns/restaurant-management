using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.Db
{
    public abstract class DbConnection
    {
        private readonly string connectionString;
        public DbConnection()
        {
            connectionString = "Data Source=tsunami;Initial Catalog=Kombo;Integrated Security=True";

        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);

        }
    }
}
