using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interface;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace JP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ICepService _cepService;

        public AlunoController(IAlunoRepositorio alunoRepositorio, ICepService cepService)
        {
            _alunoRepositorio = alunoRepositorio;
            _cepService = cepService;
        }

        // GET - Buscar por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarDadosAluno(int id)
        {
            var aluno = await _alunoRepositorio.BuscarAluno(id);

            if (aluno == null)
                return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        // POST - Adicionar
        [HttpPost("adicionar")]
        public IActionResult AdicionarAluno([FromBody] Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Adicionar(aluno);
                return Ok("Aluno adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar aluno: {ex.Message}");
            }
        }

        // PUT - Editar
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAluno(int id, [FromBody] Aluno aluno)
        {
            aluno.Id = id;

            var linhas = await _alunoRepositorio.EditarAluno(aluno);

            if (linhas == 0)
                return NotFound("Aluno não encontrado");

            return Ok("Aluno atualizado com sucesso");
        }

        // DELETE - Excluir
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var linhas = await _alunoRepositorio.ExcluirAluno(id);

            if (linhas == 0)
                return NotFound("Aluno não encontrado");

            return Ok("Aluno excluído com sucesso");
        }

        // GET - CEP
        [HttpGet("BuscarCep/{cep}")]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            try
            {
                var endereco = await _cepService.BuscarEnderecoPorCep(cep);
                return Ok(endereco);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
