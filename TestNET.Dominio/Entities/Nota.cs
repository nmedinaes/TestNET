using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNET.Dominio.Entities
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalNota { get; set; }
        [MaxLength(40)]
        public string Descripcion { get; set; }
        public int? MateriaId { get; set; }
        public int EstudianteId { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("MateriaId")]
        public virtual Materia Materia { get; set; }

        [ForeignKey("EstudianteId")]
        public virtual Estudiante Estudiante { get; set; }
    }
}
