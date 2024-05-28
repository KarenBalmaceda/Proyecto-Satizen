using System.ComponentModel.DataAnnotations;

namespace Satizen_Api.Models.Dto
{
    public class InstitucionCreateDto
    {
        public int idInstitucion { get; set;}
        public string? nombreInstitucion { get; set; }
        public string? direccionInstitucion { get; set; }
        public string? telefonoInstitucion { get; set; }
        public string? correoInstitucion { get; set; }
        public string? celularInstitucion { get; set; }
        [Required]
        public int Id { get; internal set; }
    }
}
