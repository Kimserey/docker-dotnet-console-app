namespace WebApplication1
{
    public class PersonRepository : IPersonRepository
    {
        private object _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string[] GetNames()
        {
            return new[] { "Kim", "Tom" };
        }
    }
}
