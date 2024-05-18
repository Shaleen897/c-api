using MagicVilla_API.Datos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly ApplicationDbContext _db;
        public HouseController(ILogger<HouseController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("GetHouses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<houseDto>> GetHouses()
        {
            return Ok( _db.house.ToList());
        }

        [HttpGet("id:int", Name = "GetHouses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult GetHouse(int id)
        {
            var house = _db.house.FirstOrDefault(h => h.Id == id);
            if (id == 0)
            {
                _logger.LogError("introdusca un id mayor a" + id);
                return BadRequest();
            }
            if (house == null)
            {
                return NotFound();
            }
            return Ok(house);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<houseDto>> CrearHouse([FromBody] houseDto house)
        {
            houseDto modelo = new()
            {
                Id = house.Id,
                HouseNumber = house.HouseNumber,
                HouseName = house.HouseName,
                HouseColor = house.HouseColor,
                HouseDescription = house.HouseDescription
            };

            _db.house.Add(modelo);
            _db.SaveChanges(); 
            return CreatedAtRoute("GetHouses", new {id = house.Id}, house);
        }
        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteHouse (int id)
        {
            var house = _db.house.FirstOrDefault(h => h.Id == id);

            if (id == 0)
            {
                return BadRequest();
            }
            if (house == null)
            {
                return NotFound();  
            }

            _db.house.Remove(house);
            _db.SaveChanges();
            return NoContent(); 
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<houseDto>> UpdateHouse(int id, [FromBody] houseDto house)
        {
            if (house == null || id != house.Id)
            {
                return BadRequest();
            }
         
            houseDto modelo = new()
            {
                Id = house.Id,
                HouseNumber = house.HouseNumber,
                HouseName = house.HouseName,
                HouseColor = house.HouseColor,
                HouseDescription = house.HouseDescription
            };
          

            _db.house.Update(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetHouse",new { id = house.Id }, house);
        }

    }
}
