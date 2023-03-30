using WebApplication1.Enums;

namespace WebApplication1.Models
{
	public class TarefaModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public StatusTarefas Status { get; set; }
		public int? UsuarioId { get; set; }
		public virtual UsuarioModel? Usuario { get; set; }

	}
}
