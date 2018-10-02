using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace WebApplication1
{
    public class PersonRepository : IPersonRepository
    {
        private IDbConnection _connection;

        public PersonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<string> GetNames()
        {
            IEnumerable<string> names = Enumerable.Empty<string>();
            return _connection.Query<string>("SELECT name FROM Person");
        }
    }
}
