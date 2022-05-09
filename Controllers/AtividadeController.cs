using AtividadeAPI.Data;
using AtividadeAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly AtividadeDBContext _context;
        public AtividadeController(AtividadeDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Atividade>> Get() => await _context.Atividade.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(Atividade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _context.Atividade.FindAsync(id);

            return resultado == null ? NotFound() : Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Atividade model)
        {
            await _context.Atividade.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(Atividade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Atividade model)
        {
            if (id != model.Id) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var excluirAtividade = await _context.Atividade.FindAsync(id);

            if (excluirAtividade == null) return NotFound();

            _context.Remove(excluirAtividade);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
