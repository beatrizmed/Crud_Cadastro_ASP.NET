using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Repositorios
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private readonly TarefasDbContext _dbContext;
		public UsuarioRepositorio(TarefasDbContext tarefasDbContext) 
		{ 
			_dbContext = tarefasDbContext;
		}
		public async Task<UsuarioModel> BuscarPorId(int id)
		{
			return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
		{
			return await _dbContext.Usuarios.ToListAsync();
		}

		public async Task<UsuarioModel> Cadastrar(UsuarioModel usuario)
		{
			await _dbContext.Usuarios.AddAsync(usuario);
			await _dbContext.SaveChangesAsync();

			return usuario;
		}

		public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
		{
			UsuarioModel usuarioPorId = await BuscarPorId(id);

			if(usuarioPorId == null) 
			{
				throw new Exception($"Usuário do ID: {id} não foi encontrado.");
			}

			usuarioPorId.Name = usuario.Name;
			usuarioPorId.Email = usuario.Email;

			_dbContext.Usuarios.Update(usuarioPorId);
			await _dbContext.SaveChangesAsync();

			return usuarioPorId;
			
		}

		public async Task<bool> Deletar(int id)
		{
			UsuarioModel usuarioPorId = await BuscarPorId(id);

			if (usuarioPorId == null)
			{
				throw new Exception($"Usuário do ID: {id} não foi encontrado.");
			}

			_dbContext.Usuarios.Remove(usuarioPorId);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
