using ContaCorrente_Backend.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ContaCorrente_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContaCorrente_Backend", Version = "v1" });
            });

            StringBuilder ConexaoSQL = new StringBuilder()
            .Append($"Server={Configuration["DbHost"]}, ")
            .Append($"{Configuration["DbPort"]};")
            .Append($"Initial Catalog={Configuration["Database"]};")
            .Append($"User ID={Configuration["DbUser"]};")
            .Append($"Password={Configuration["Password"]}");

            services.AddDbContext<SQLContext>(c => c.UseSqlServer(ConexaoSQL.ToString()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Services.DbService.IniciarMigracao(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContaCorrente_Backend v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
