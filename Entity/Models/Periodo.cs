namespace ColegioApp.Entity.Models;
public class Periodo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
