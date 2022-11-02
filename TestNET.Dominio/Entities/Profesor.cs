using System.ComponentModel.DataAnnotations;

namespace TestNET.Dominio.Entities
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Cedula { get; set; }
        [MaxLength(40)]
        public string Nombres { get; set; }
        [MaxLength(40)]
        public string Apellidos { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
