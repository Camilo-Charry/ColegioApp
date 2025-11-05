using ColegioApp.Business;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColegioApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protegido con JWT
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteService _service;

        public EstudianteController(EstudianteService service)
        {
            _service = service;
        }

        // ============================
        // GET: api/Estudiante
        // ============================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _service.GetAllAsync();
            return Ok(estudiantes);
        }

        // ============================
        // GET: api/Estudiante/5
        // ============================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _service.GetByIdAsync(id);
            if (estudiante == null)
                return NotFound(new { message = "Estudiante no encontrado" });

            return Ok(estudiante);
        }

        // ============================
        // POST: api/Estudiante
        // ============================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstudianteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ============================
        // PUT: api/Estudiante/5
        // ============================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstudianteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { message = "Estudiante no encontrado" });

            return Ok(updated);
        }

        // ============================
        // DELETE: api/Estudiante/5
        // ============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Estudiante no encontrado" });

            return NoContent();
        }
    }
}
