using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string[]> Get([FromServices] IPersonRepository repository)
        {
            return repository.GetNames().ToArray();
        }
    }
}
