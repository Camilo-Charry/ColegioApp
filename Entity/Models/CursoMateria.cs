namespace ColegioApp.Entity.Models;
// Pivote Curso-Materia
public class CursoMateria
{
    public int CursoId { get; set; }
    public int MateriaId { get; set; }

    public Curso? Curso { get; set; }
    public Materia? Materia { get; set; }

    public ICollection<Nota> Notas { get; set; } = new List<Nota>();
}
