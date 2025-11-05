namespace ColegioApp.Entity.Models;
public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int PeriodoId { get; set; }
    public int ProfesorId { get; set; }

    public Periodo? Periodo { get; set; }
    public Profesor? Profesor { get; set; }

    public ICollection<CursoMateria> CursoMaterias { get; set; } = new List<CursoMateria>();
    public ICollection<Nota> Notas { get; set; } = new List<Nota>();
}
