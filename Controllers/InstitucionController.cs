using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Satizen_Api.Datos;
using Satizen_Api.Models;
using Satizen_Api.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
namespace Satizen_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        private readonly ILogger <InstitucionController> _logger;
        private readonly ApplicationDbContext _db;


        public InstitucionController(ILogger<InstitucionController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<InstitucionModels>> GetInstitucion()
        {
            _logger.LogInformation("Obtener las Instituciones");
            return Ok(_db.Institucion.ToList());

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InstitucionModels>> GetInstitucion(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer una Institucion con Id" + id);
                return BadRequest();
            }
            // var institucion = InstitucionStore.institucionList.FirstOrDefault(v => v.Id == id);
            var institucion = _db.Institucion.FirstOrDefault(v => v.Id == id);
            if(institucion== null)
            {
                return NotFound();

            }

            return Ok(institucion);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InstitucionDto> CrearInstitucion([FromBody] InstitucionDto institucionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_db.Institucion.FirstOrDefault(v => v.nombreInstitucion.ToLower() == institucionDto.nombreInstitucion.ToLower()) != null) 
            {
                ModelState.AddModelError("NombreExiste", "La institucion ya existe");
                return BadRequest(ModelState);
            }
            if (institucionDto == null)
            {
                return BadRequest(institucionDto);
            }
            if (institucionDto.idInstitucion > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            InstitucionModels models = new()
            {
                nombreInstitucion = institucionDto.nombreInstitucion,
                direccionInstitucion = institucionDto.direccionInstitucion,
                telefonoInstitucion = institucionDto.telefonoInstitucion,
                correoInstitucion = institucionDto.correoInstitucion,
                celularInstitucion = institucionDto.celularInstitucion,

            };

            _db.Institucion.Add(models);
            _db.SaveChanges();

            return CreatedAtRoute("GetInstitucion", new { id = institucionDto.idInstitucion }, institucionDto);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInstitucion(int id, InstitucionDto institucionDto)
        {
            if (institucionDto==null || id!= institucionDto.idInstitucion)
            {
                return BadRequest();
            }

            InstitucionModels models = new()
            {
                idInstitucion = institucionDto.idInstitucion,
                nombreInstitucion = institucionDto.nombreInstitucion,
                direccionInstitucion = institucionDto.direccionInstitucion,
                telefonoInstitucion = institucionDto.telefonoInstitucion,
                correoInstitucion = institucionDto.correoInstitucion,
                celularInstitucion = institucionDto.celularInstitucion,
            };
            _db.Institucion.Update(models);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteInstitucion(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var institucion = _db.Institucion.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }
            _db.Institucion.Remove(await institucion);
            _db.SaveChanges();

     
            return NoContent();
        }

        

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialInstitucion(int id, JsonPatchDocument<InstitucionDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var institucion = _db.Institucion.AsNoTracking().FirstOrDefault(v => v.idInstitucion == id);

            InstitucionDto institucionDto = new()
            {
                idInstitucion = institucion.idInstitucion,
                nombreInstitucion = institucion.nombreInstitucion,
                direccionInstitucion = institucion.direccionInstitucion,
                telefonoInstitucion = institucion.telefonoInstitucion,
                correoInstitucion = institucion.correoInstitucion,
                celularInstitucion = institucion.celularInstitucion,
            };
            if (institucion == null) return BadRequest();

            patchDto.ApplyTo(institucionDto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            InstitucionModels models = new()
            {
                idInstitucion = institucionDto.idInstitucion,
                nombreInstitucion = institucionDto.nombreInstitucion,
                direccionInstitucion = institucionDto.direccionInstitucion,
                telefonoInstitucion = institucionDto.telefonoInstitucion,
                correoInstitucion = institucionDto.correoInstitucion,
                celularInstitucion = institucionDto.celularInstitucion,
            };
            _db.Institucion.Update(models);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
   
