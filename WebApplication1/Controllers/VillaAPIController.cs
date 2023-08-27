using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        /*Endpoint in API is something that accepts requests and sends back response*/
        [HttpGet]   //an end point
        public IEnumerable<Villa> GetVillas() { 
            return new List<Villa>
            {
                new Villa{Id=1, Name="Pool View"},
                new Villa{Id=2, Name="Beach View"}
            };
        }
    }
}
