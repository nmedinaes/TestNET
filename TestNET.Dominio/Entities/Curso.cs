using System.ComponentModel.DataAnnotations;

namespace TestNET.Dominio.Entities
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(40)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
