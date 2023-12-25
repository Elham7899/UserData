using Microsoft.EntityFrameworkCore;
using Test.BLL.Contracts;
using Test.BLL.Services;
using Test.Host.Contracts;
using Test.Host.Repositories;
using Test.Host.TDbContext;

namespace TestProject.Infrastructure;

public static class ServiceConfiguration
{
	public static void Registration(this WebApplicationBuilder builder)
	{
		builder.Services.AddScoped<IUserBLL,UserBLL>();
		builder.Services.AddScoped<IUserReository,UserRepository>();
		builder.Services.AddScoped<IChildBLL, ChildBLL>();
		builder.Services.AddScoped<IChildRepository, ChildRepository>();
		builder.Services.AddDbContext<DbContexts>(c=>c.UseSqlServer("Data Source=.;Initial Catalog=ICANTest;Persist Security Info=True;User ID=sa;Password=12345;Integrated security=true;TrustServerCertificate=True"));
	}
}
