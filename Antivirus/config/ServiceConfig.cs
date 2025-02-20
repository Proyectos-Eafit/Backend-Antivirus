using Microsoft.EntityFrameworkCore;
using Antivirus.Services;
using Antivirus.Models;

namespace Antivirus.config
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de dependencias
            services.AddScoped<AuthService>();
            services.AddScoped<ICostsBootcampService, CostBootcampService>();
            services.AddScoped<IUbicationInstitutionService, UbicationInstitutionService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IStatusOpportunitiesService, StatusOpportunitiesService>();
            services.AddScoped<IDescriptionsBootcampsService, DescriptionsBootcampsService>();
            services.AddScoped<IInstitutionOpportunitiesService, InstitutionOpportunitiesService>();
            services.AddScoped<IStatusBootcampService, StatusBootcampService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBootcampService, BootcampService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStatusInstitutionService, StatusInstitutionService>();
            services.AddScoped<IOpportunitiesService, OpportunitiesService>();
            services.AddScoped<ICategoriesOpportunitiesService, CategoriesOpportunitiesService>();
            services.AddScoped<ITypeOpportunityService, TypeOpportunityService>();
            
            // Configuración de la base de datos
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
