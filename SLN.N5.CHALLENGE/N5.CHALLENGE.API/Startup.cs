using Microsoft.EntityFrameworkCore;
using N5.CHALLENGE.APPLICATION.AppServices;
using N5.CHALLENGE.APPLICATION.Interfaces;
using N5.CHALLENGE.APPLICATION.Permisos.ListarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ModificarPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.ObtenerPermisos;
using N5.CHALLENGE.APPLICATION.Permisos.RegistroPermisos;
using N5.CHALLENGE.APPLICATION.Profiles;
using N5.CHALLENGE.APPLICATION.TipoPermisos.ListarTipoPermisos;
using N5.CHALLENGE.DOMAIN.Interfaces;
using N5.CHALLENGE.INFRA.REPOSITORY;
using N5.CHALLENGE.INFRA.REPOSITORY.Services;
using System.Reflection;

namespace N5.CHALLENGE.API
{
    public static class Startup
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPermisosAppService, PermisosAppService>();
            services.AddScoped<IElasticSearchAppService, ElasticSearchAppService>();

            services.AddDbContext<N5NowEFContext>(options => options.UseSqlServer(configuration["ConnectionString"]));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(new Assembly[] {
                typeof(AddPermissionCommandHandler).Assembly,
                typeof(ModifyPermissionCommandHandler).Assembly,
                typeof(GetPermissionQueryHandler).Assembly,
                typeof(ListarPermisosQueryHandler).Assembly,
                typeof(ListarTipoPermisoQueryHandler).Assembly,
            }));

            services.AddAutoMapper(cfg => cfg.AddProfile<PermisosProfile>());

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(policy =>
            {
                policy.AddPolicy("AllowAll", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
        }
        public static WebApplication UseServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowAll");

            return app;
        }
    }
}
