﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Satizen_Api.Models
{
    public class InstitucionModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idInstitucion { get; set; }
        [Required]
        [MaxLength(40)]
        public string? nombreInstitucion { get; set; }
        [Required]
        [MaxLength(50)]
        public string? direccionInstitucion { get; set; }
        [Required]
        [MaxLength(20)]
        public string? telefonoInstitucion { get; set; }
        [Required]
        [MaxLength(40)]
        public string? correoInstitucion { get; set; }
        [Required]
        [MaxLength(20)]
        public string? celularInstitucion  { get; set; }
        [Required]
        public int Id { get; internal set; }
    }
}

