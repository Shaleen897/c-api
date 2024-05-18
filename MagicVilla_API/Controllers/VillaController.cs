using Azure;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("id:int",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if(id == 0)
            {
                _logger.LogError("Error al traer villa con id " + id);
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /* if(VillaStore.villaList.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) != null)
             {
                 ModelState.AddModelError("validatorName", "Este nombre existe");
                 return BadRequest(ModelState);
             }*/

            if (_db.villas.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("validatorName", "Este nombre existe");
                return BadRequest(ModelState);
            }

            if (villaDto == null)
          {
                return BadRequest(villaDto);
          }
         if(villaDto.Id>0)
          {
                return StatusCode(StatusCodes.Status500InternalServerError);
          }
           // villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;

           // VillaStore.villaList.Add(villaDto);

         Villa model = new()
         { 
          Id= villaDto.Id,
          Name= villaDto.Name,  
          Detalle = villaDto.Detalle,
          ImgURL= villaDto.ImgURL,  
          Ocupantes= villaDto.Ocupantes,
          Tarifa= villaDto.Tarifa,
          MetrosCuadrados= villaDto.MetrosCuadrados,
          Amenidad= villaDto.Amenidad,
         };

            _db.villas.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetVilla", new {id = villaDto.Id}, villaDto);
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            // var Villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            var Villa = _db.villas.FirstOrDefault(v => v.Id == id);

            if (Villa == null)
            {
                return NotFound();
            }
            
            _db.villas.Remove(Villa);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (villaDto ==null || id!= villaDto.Id)
            {
                return BadRequest();
            }
            /*
            var Villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

            Villa.Name = villaDto.Name;
            Villa.Ocupantes = villaDto.Ocupantes;
            Villa.MetrosCuadrados = villaDto.MetrosCuadrados;*/

            Villa model = new()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Detalle = villaDto.Detalle,
                ImgURL = villaDto.ImgURL,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                Amenidad = villaDto.Amenidad,
            };
            _db.villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateParcialVilla(int id, JsonPatchDocument<VillaDto>  patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            // var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

            var villa = _db.villas.FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Detalle = villa.Detalle,
                ImgURL = villa.ImgURL,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad,
            };

            if(villa == null ) return BadRequest();

            patchDto.ApplyTo(villaDto, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Detalle = villa.Detalle,
                ImgURL = villa.ImgURL,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad,
            };
            _db.villas.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpGet("getdossql")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas2()
        {
            return Ok(_db.villas.ToList());
        }
    }
}
