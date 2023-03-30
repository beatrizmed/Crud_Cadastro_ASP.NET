using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private ITarefaRepositorio _tarefaRepositorio;
		public TarefaController(ITarefaRepositorio tarefaRepositorio) 
		{
			_tarefaRepositorio = tarefaRepositorio;
		}

		[HttpGet]
		public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
		{
			List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
			return Ok(tarefas);
		}

		[HttpGet("{id}")]

		public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
		{
			TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
			return Ok(tarefa);
		}

		[HttpPost]
		public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
		{
			TarefaModel tarefa = await _tarefaRepositorio.Cadastrar(tarefaModel);

			return Ok(tarefa);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
		{
			tarefaModel.Id = id;
			TarefaModel usuario = await _tarefaRepositorio.Atualizar(tarefaModel, id);

			return Ok(usuario);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<TarefaModel>> Deletar(int id)
		{
			bool deletado = await _tarefaRepositorio.Deletar(id);

			return Ok(deletado);
		}
	}
}
