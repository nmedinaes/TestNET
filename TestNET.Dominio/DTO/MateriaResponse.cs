namespace TestNET.Dominio.DTO
{
    public class MateriaResponse
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Semestre { get; set; }
        public int ProfesorId { get; set; }
        public int CursoId { get; set; }
        public bool Activo { get; set; }
    }
}
