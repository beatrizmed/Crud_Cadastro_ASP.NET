using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
	public interface ITarefaRepositorio
	{
		Task<List<TarefaModel>> BuscarTodasTarefas();

		Task<TarefaModel> BuscarPorId (int id);

		Task<TarefaModel> Cadastrar (TarefaModel tarefa);

		Task<TarefaModel> Atualizar (TarefaModel tarefa, int id);

		Task<bool> Deletar (int id);
	}
}
