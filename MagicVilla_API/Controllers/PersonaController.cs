using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly ApplicationDbContext _db;
        public PersonaController(ILogger<PersonaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("GetPersona")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PersonaDto>> GetPersona()
        {
            return Ok(_db.persona.ToList());
        }
        [HttpGet("id:int", Name = "GetPersona")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonaDto> GetPersona(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Persona con id " + id);
                return BadRequest();
            }

            var persona = _db.persona.FirstOrDefault(p => p.Id == id);

            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<PersonaDto>> GetCrearPersona([FromBody] PersonaDto personaDto)
        {

            Persona modelo = new()
            {
                Id = personaDto.Id,
                Name = personaDto.Name,
                lastName = personaDto.lastName
            };
            _db.persona.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetPersona", new { id = personaDto.Id }, personaDto);
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePersona(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var personas = _db.persona.FirstOrDefault(p => p.Id == id);

            if(personas == null)
            {
                return NotFound();
            }
            _db.persona.Remove(personas);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<PersonaDto>> GetActualizarPersona(int id, [FromBody] PersonaDto personaDto)
        {
            if (personaDto == null || id != personaDto.Id)
            {
                return BadRequest();
            }

            Persona modelo = new()
            {
                Id = personaDto.Id,
                Name = personaDto.Name,
                lastName = personaDto.lastName
            };
            _db.persona.Update(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetPersona", new { id = personaDto.Id }, personaDto);
        }


    }
}
