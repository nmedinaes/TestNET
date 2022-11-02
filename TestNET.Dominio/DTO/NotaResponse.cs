namespace TestNET.Dominio.DTO
{
    public class NotaResponse
    {
        public decimal TotalNota { get; set; }
        public string Descripcion { get; set; }
        public int? MateriaId { get; set; }
        public int EstudianteId { get; set; }
        public bool Activo { get; set; }
    }
}
