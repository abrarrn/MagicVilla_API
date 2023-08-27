using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Models.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/VillaAPI")] //can also be used as [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        /*Endpoint in API is something that accepts requests and sends back response*/
        [HttpGet]   //an end point
        public IEnumerable<VillaDTO> GetVillas() {
            return VillaStore.villaList;
        }

        [HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(u => u.Id == id);
        }
    }
}
