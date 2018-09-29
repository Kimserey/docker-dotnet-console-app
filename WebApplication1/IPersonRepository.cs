using System.Collections.Generic;

namespace WebApplication1
{
    public interface IPersonRepository
    {
        IEnumerable<string> GetNames();
    }
}
