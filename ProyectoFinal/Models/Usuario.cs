using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5,ErrorMessage = "El nombre de usuario debe contener entre 5 y 20 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "La contraseña debe contener entre 5 y 20 caracteres.")]
        public string Contraseña { get; set; }
    }
}