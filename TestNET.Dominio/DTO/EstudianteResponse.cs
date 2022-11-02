namespace TestNET.Dominio.DTO
{
    public class EstudianteResponse
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CursoId { get; set; }
        public bool Activo { get; set; }
    }
}
