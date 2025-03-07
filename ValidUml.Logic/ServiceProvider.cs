using Microsoft.Extensions.DependencyInjection;
using ValidUml.Logic.UmlParsers;

namespace ValidUml.Logic
{
	public static class ServiceProvider
	{
		public static IServiceCollection AddLogic(this IServiceCollection services)
		{
			services.AddTransient<ClassDiagram>();
			return services;
		}
	}
}
