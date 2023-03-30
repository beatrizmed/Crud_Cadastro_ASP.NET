using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
	public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
	{

		public void Configure(EntityTypeBuilder<UsuarioModel> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(X => X.Name).IsRequired().HasMaxLength(255);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
		}
	}
}
