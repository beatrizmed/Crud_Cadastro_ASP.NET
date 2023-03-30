using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
	public class TarefaRepositorio : ITarefaRepositorio
	{
		private readonly TarefasDbContext _dbContext;
		public TarefaRepositorio(TarefasDbContext tarefasDbContext)
		{
			_dbContext = tarefasDbContext;
		}

		public async Task<TarefaModel> BuscarPorId(int id)
		{
			return await _dbContext.Tarefas
				.Include(x => x.Usuario)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<TarefaModel>> BuscarTodasTarefas()
		{
			return await _dbContext.Tarefas
				.Include (x => x.Usuario)
				.ToListAsync();
		}

		public async Task<TarefaModel> Cadastrar(TarefaModel tarefa)
		{
			await _dbContext.Tarefas.AddAsync(tarefa);
			await _dbContext.SaveChangesAsync();

			return tarefa;
		}

		public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
		{
			TarefaModel tarefaPorId = await BuscarPorId(id);

			if (tarefaPorId == null)
			{
				throw new Exception($"Tarefa do ID: {id} não foi encontrado.");
			}

			tarefaPorId.Name = tarefa.Name;
			tarefaPorId.Description = tarefa.Description;
			tarefaPorId.Status = tarefa.Status;
			tarefaPorId.UsuarioId = tarefa.UsuarioId;

			_dbContext.Tarefas.Update(tarefaPorId);
			await _dbContext.SaveChangesAsync();

			return tarefaPorId;

		}

		public async Task<bool> Deletar(int id)
		{
			TarefaModel tarefaPorId = await BuscarPorId(id);

			if (tarefaPorId == null) 
			{
				throw new Exception($"Tarefa por ID: {id} não foi encontrado.");
			}

			_dbContext.Tarefas.Remove(tarefaPorId);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
