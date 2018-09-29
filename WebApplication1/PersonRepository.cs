using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace WebApplication1
{
    public class PersonRepository : IPersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public IEnumerable<string> GetNames()
        {
            IEnumerable<string> names = Enumerable.Empty<string>();

            using (var conn = GetConnection())
            {
                names = conn.Query<string>("SELECT name FROM Person");
            }

            return names;
        }
    }
}
