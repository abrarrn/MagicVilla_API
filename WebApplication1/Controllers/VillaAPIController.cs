using Microsoft.AspNetCore.Http.HttpResults;
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
        public ActionResult<IEnumerable<VillaDTO>> GetVillas() {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (id == 0){
                return BadRequest();
            }
            if(id == null) { 
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
        {
            if(villaDTO == null) { 
                return  BadRequest(villaDTO); 
            }
            if(villaDTO.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Name = "Bliss View";
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("GetVilla", new {villaDTO.Id}, villaDTO);
        }
    }
}
