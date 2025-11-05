namespace ColegioApp.Entity.DTOs
{
    public class NotaDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public int MateriaId { get; set; }
        public decimal Calificacion { get; set; }
        public string Observacion { get; set; } = string.Empty;

        public string? EstudianteNombre { get; set; }
        public string? MateriaNombre { get; set; }
        public string? CursoNombre { get; set; }
    }

    public class NotaCreateDto
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public int MateriaId { get; set; }
        public decimal Calificacion { get; set; }
        public string Observacion { get; set; } = string.Empty;
    }

    public class NotaUpdateDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public int MateriaId { get; set; }
        public decimal Calificacion { get; set; }
        public string Observacion { get; set; } = string.Empty;
    }
}
