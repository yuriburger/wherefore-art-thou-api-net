using Wherefore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wherefore.Infrastructure
{
	public static class StartupSetup
	{
		public static void AddDbContext(this IServiceCollection services) =>
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite("Data Source=database.sqlite"));
	}
}
