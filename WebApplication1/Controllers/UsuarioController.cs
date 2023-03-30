using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorios.Interfaces;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private IUsuarioRepositorio _usuarioRepositorio;
		public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
		{
			_usuarioRepositorio = usuarioRepositorio;
		}

		[HttpGet]
		public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
		{
			List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
			return Ok(usuarios);
		}

		[HttpGet("{id}")]

		public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
		{
			UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
			return Ok(usuario);
		}

		[HttpPost]
		public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
		{
			UsuarioModel usuario = await _usuarioRepositorio.Cadastrar(usuarioModel);

			return Ok(usuario);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
		{
			usuarioModel.Id = id;
			UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);

			return Ok(usuario);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<UsuarioModel>> Deletar(int id)
		{
			bool deletado = await _usuarioRepositorio.Deletar(id);

			return Ok(deletado);
		}
	}
}
