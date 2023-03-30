using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
	public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
	{
		public void Configure(EntityTypeBuilder<TarefaModel> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
			builder.Property(x => x.Status).IsRequired();
			builder.Property(x => x.UsuarioId);

			builder.HasOne(x => x.Usuario);
			builder.ToTable("Tarefa");
		}
	}
}
