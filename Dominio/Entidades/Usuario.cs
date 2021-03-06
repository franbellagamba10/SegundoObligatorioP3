using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [MaxLength(50)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(20, ErrorMessage = "La contraseña debe tener entre {2} y {0} caracteres.", MinimumLength = 6)] //indice de parametros donde 0 es 20, 1 es el mensaje de error y 2 es 6
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")] //testear Regex, no se si la precisamos asi de desarrollada
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
        public List<Planta> PlantasIngresadas { get; set; }
        public Usuario()
        {
            Activo = true;
        }
    }
}
