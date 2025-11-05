using ColegioApp.Entity.Context;
using ColegioApp.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColegioApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoMateriaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CursoMateriaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AsignarMateria(int cursoId, int materiaId)
    {
        var entity = new CursoMateria { CursoId = cursoId, MateriaId = materiaId };
        _context.CursoMaterias.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Materia asignada al curso correctamente" });
    }

    [HttpGet("{cursoId}")]
    public async Task<IActionResult> GetMateriasPorCurso(int cursoId)
    {
        var materias = await _context.CursoMaterias
            .Where(cm => cm.CursoId == cursoId)
            .Include(cm => cm.Materia)
            .Select(cm => new { cm.Materia.Id, cm.Materia.Nombre, cm.Materia.Codigo })
            .ToListAsync();

        return Ok(materias);
    }
}
