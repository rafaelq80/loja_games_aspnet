using loja_games.Model;
using loja_games.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace loja_games.Controller
{
    [Authorize]
    [Route("~/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<Categoria> _categoriaValidator;

        public CategoriaController(
            ICategoriaService categoriaService,
            IValidator<Categoria> categoriaValidator
            )
        {
            _categoriaService = categoriaService;
            _categoriaValidator = categoriaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _categoriaService.GetById(id);

            if (Resposta is null)
            {
                return NotFound("Categoria não encontrado!");
            }

            return Ok(Resposta);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> GetByTipo(string tipo)
        {
            return Ok(await _categoriaService.GetByTipo(tipo));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            var validarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);

            await _categoriaService.Create(categoria);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            if (categoria.Id == 0)
                return BadRequest("O Id do Categoria é inválido!");

            var validarCategoria = await _categoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);

            var Resposta = await _categoriaService.Update(categoria);

            if (Resposta is null)
                return NotFound("Categoria não encontrado!");

            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var BuscaCategoria = await _categoriaService.GetById(id);

            if (BuscaCategoria is null)
                return NotFound("Categoria não encontrado!");

            await _categoriaService.Delete(BuscaCategoria);

            return NoContent();

        }

    }
}