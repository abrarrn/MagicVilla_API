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
            if(VillaStore.villaList.FirstOrDefault(p => p.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "This villa already exists");
                return BadRequest(ModelState);
            }
            if(villaDTO == null) { 
                return  BadRequest(villaDTO); 
            }
            if(villaDTO.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDTO);
            return CreatedAtRoute("GetVilla", new {villaDTO.Id}, villaDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id ==  0) {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if(villa == null) {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }
    }
}
