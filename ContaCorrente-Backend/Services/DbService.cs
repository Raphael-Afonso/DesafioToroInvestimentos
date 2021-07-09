using ContaCorrente_Backend.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente_Backend.Services
{
    public static class DbService
    {
        public static void IniciarMigracao(IApplicationBuilder applicationBuilder)
        {
            using IServiceScope Scope = applicationBuilder.ApplicationServices.CreateScope();
            Scope.ServiceProvider.GetService<SQLContext>().Database.Migrate();
        }
    }
}
