using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El nombre es demasiado largo.")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El apellido paterno es demasiado largo.")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El apellido materno es demasiado largo.")]
        public string ApellidoMaterno { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string NombreCompleto { get { return Nombre + " " + ApellidoPaterno + " " + ApellidoPaterno; } }

        [Required]
        [Phone]
        [StringLength(10, ErrorMessage = "El teléfono es demasiado largo.")]
        public string Telefono { get; set; }

        [EmailAddress]
        public string CorreoElectronico { get; set; }

    }
}