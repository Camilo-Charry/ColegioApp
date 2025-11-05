namespace ColegioApp.Entity.Models;
public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Grado { get; set; } = string.Empty;
    public ICollection<Nota> Notas { get; set; } = new List<Nota>();
}
