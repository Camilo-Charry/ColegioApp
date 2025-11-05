namespace ColegioApp.Entity.Models;
// Pivote extendido Estudiante ↔ (Curso, Materia)
public class Nota
{
    public int Id { get; set; }
    public int EstudianteId { get; set; }
    public int CursoId { get; set; }
    public int MateriaId { get; set; }
    public decimal Calificacion { get; set; }
    public string? Observacion { get; set; }

    public Estudiante? Estudiante { get; set; }
    public Curso? Curso { get; set; }
    public Materia? Materia { get; set; }
}
