using ColegioApp.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ColegioApp.Entity.Context;

public class ApplicationDbContext : DbContext

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<Periodo> Periodos => Set<Periodo>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<CursoMateria> CursoMaterias => Set<CursoMateria>();
    public DbSet<Nota> Notas => Set<Nota>();

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 🔹 CursoMateria (tabla pivote)
        modelBuilder.Entity<CursoMateria>()
            .HasKey(cm => new { cm.CursoId, cm.MateriaId });

        // 🔹 Relaciones de Curso
        modelBuilder.Entity<Curso>()
            .HasOne(c => c.Periodo)
            .WithMany(p => p.Cursos)
            .HasForeignKey(c => c.PeriodoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Curso>()
            .HasOne(c => c.Profesor)
            .WithMany(p => p.Cursos)
            .HasForeignKey(c => c.ProfesorId)
            .OnDelete(DeleteBehavior.Restrict);

        // 🔹 Relaciones de Nota
        modelBuilder.Entity<Nota>()
            .HasOne(n => n.Estudiante)
            .WithMany(e => e.Notas)
            .HasForeignKey(n => n.EstudianteId);

        modelBuilder.Entity<Nota>()
            .HasOne(n => n.Curso)
            .WithMany(c => c.Notas)
            .HasForeignKey(n => n.CursoId);

        modelBuilder.Entity<Nota>()
            .HasOne(n => n.Materia)
            .WithMany(m => m.Notas)
            .HasForeignKey(n => n.MateriaId);

        // ✅ Definir precisión para Calificación
        modelBuilder.Entity<Nota>()
            .Property(n => n.Calificacion)
            .HasPrecision(5, 2); // permite valores como 99.99
    }
}
