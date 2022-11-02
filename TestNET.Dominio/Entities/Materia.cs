using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNET.Dominio.Entities
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(40)]
        public string Descripcion { get; set; }
        [MaxLength(2)]
        public string Semestre { get; set; }
        public int ProfesorId { get; set; }
        public int CursoId { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("ProfesorId")]
        public virtual Profesor Profesor { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }
    }
}
