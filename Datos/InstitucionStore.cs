using Satizen_Api.Models.Dto;

namespace Satizen_Api.Datos
{
    public static class InstitucionStore
    {
        public static List<InstitucionDto> institucionList = new List<InstitucionDto>
        {
            new InstitucionDto {idInstitucion=1, nombreInstitucion= "Clinica Santa Clara", telefonoInstitucion="4963724", direccionInstitucion= "Calle alberdi", correoInstitucion="clinicasantaclara@gmail.com", celularInstitucion="26457832" },
             new InstitucionDto {idInstitucion=2, nombreInstitucion= "Clinica Santa Clara", telefonoInstitucion="4963724", direccionInstitucion= "Calle alberdi", correoInstitucion="clinicasantaclara@gmail.com", celularInstitucion="26457832" },
        };
    }
}
