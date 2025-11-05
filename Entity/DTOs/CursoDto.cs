namespace ColegioApp.Entity.DTOs
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int PeriodoId { get; set; }
        public int ProfesorId { get; set; }
        public string? PeriodoNombre { get; set; }
        public string? ProfesorNombre { get; set; }
    }

    public class CursoCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int PeriodoId { get; set; }
        public int ProfesorId { get; set; }
    }

    public class CursoUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int PeriodoId { get; set; }
        public int ProfesorId { get; set; }
    }
}
