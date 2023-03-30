using WebApplication1.Models;

namespace WebApplication1.Repositorios.Interfaces
{
	public interface IUsuarioRepositorio
	{
		Task<List<UsuarioModel>> BuscarTodosUsuarios();

		Task<UsuarioModel> BuscarPorId (int id);

		Task<UsuarioModel> Cadastrar (UsuarioModel usuario);

		Task<UsuarioModel> Atualizar (UsuarioModel usuario, int id);

		Task<bool> Deletar (int  id);
	}
}
