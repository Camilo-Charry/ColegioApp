namespace ColegioApp.Entity.Models;
public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
