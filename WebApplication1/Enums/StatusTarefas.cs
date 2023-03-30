using System.ComponentModel;

namespace WebApplication1.Enums
{
	public enum StatusTarefas
	{
		[Description("A fazer")]
		AFazer = 1,
		[Description("Em Andamento")]
		EmAndamento = 2,
		[Description("Feito")]
		Feito = 3
	}
}
