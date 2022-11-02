using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNET.Dominio.Entities
{
    public class Estudiante
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
        public int CursoId { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }
    }
}
