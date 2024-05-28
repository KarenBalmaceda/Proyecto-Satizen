using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Satizen_Api.Datos;
using Satizen_Api.Models;
using Satizen_Api.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AutoMapper;
namespace Satizen_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        private readonly ILogger <InstitucionController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private int idInstitucion;

        public InstitucionController(ILogger<InstitucionController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InstitucionDto>>> GetInstitucion()
        {
            _logger.LogInformation("Obtener las Instituciones");

            IEnumerable<InstitucionModels> institucionList = await _db.Institucion.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<InstitucionDto>>(institucionList));

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InstitucionDto>> GetInstitucion(int idInstitucion)
        {
            if (idInstitucion == 0)
            {
                _logger.LogError("Error al traer una Institucion con Id" + idInstitucion);
                return BadRequest();
            }
            // var institucion = InstitucionStore.institucionList.FirstOrDefault(v => v.Id == id);
            var institucion = await _db.Institucion.FirstOrDefaultAsync(v => v.idInstitucion == idInstitucion);
            if(institucion== null)
            {
                return NotFound();

            }

            return Ok(_mapper.Map<InstitucionDto>(institucion));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InstitucionDto>> CrearInstitucion([FromBody] InstitucionCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _db.Institucion.FirstOrDefaultAsync(v => v.nombreInstitucion.ToLower() == createDto.nombreInstitucion.ToLower()) != null) 
            {
                ModelState.AddModelError("NombreExiste", "La institucion ya existe");
                return BadRequest(ModelState);
            }
            if (createDto == null)
            {
                return BadRequest(createDto);
            }
            InstitucionModels models = _mapper.Map<InstitucionModels>(createDto);

         

             await _db.Institucion.AddAsync(models);
             await _db.SaveChangesAsync();

            return base.CreatedAtRoute("GetInstitucion", new { idInstitucion = models.idInstitucion }, models);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInstitucion(int idInstitucion, InstitucionUpdateDto updateDto)
        {
            if (updateDto==null || idInstitucion!= updateDto.idInstitucion)
            {
                return BadRequest();
            }

            InstitucionModels models = _mapper.Map<InstitucionModels>(updateDto);

            _db.Institucion.Update(models);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteInstitucion(int idInstitucion)
        {
            if (idInstitucion == 0)
            {
                return BadRequest();
            }
            var institucion = await _db.Institucion.FirstOrDefaultAsync(v => v.idInstitucion ==idInstitucion);
            if (institucion == null)
            {
                return NotFound();
            }
            _db.Institucion.Remove(institucion);
            await _db.SaveChangesAsync();

     
            return NoContent();
        }

        

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< IActionResult> UpdatePartialInstitucion(int idInstitucion, JsonPatchDocument<InstitucionUpdateDto> patchDto)
        {
            if (patchDto == null || idInstitucion == 0)
            {
                return BadRequest();
            }
            var institucion = await _db.Institucion.AsNoTracking().FirstOrDefaultAsync(v => v.idInstitucion == idInstitucion);

            InstitucionUpdateDto institucionDto = _mapper.Map<InstitucionUpdateDto>(institucion);

            if (institucion == null) return BadRequest();

            patchDto.ApplyTo(institucionDto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            InstitucionModels models = _mapper.Map<InstitucionModels>(institucionDto);
            
            _db.Institucion.Update(models);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
   
