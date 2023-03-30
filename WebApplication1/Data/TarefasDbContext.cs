using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class TarefasDbContext : DbContext
	{
		public TarefasDbContext(DbContextOptions<TarefasDbContext> options)
			: base(options) { }

		public DbSet<UsuarioModel> Usuarios { get; set; }
		public DbSet<TarefaModel> Tarefas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new TarefaMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
