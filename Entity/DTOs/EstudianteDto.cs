namespace ColegioApp.Entity.DTOs
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public int Edad { get; set; }
    }

    public class EstudianteCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Grado { get; set; } = string.Empty;
    }

    public class EstudianteUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Grado { get; set; } = string.Empty;
    }
}
