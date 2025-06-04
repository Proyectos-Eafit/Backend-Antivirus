using Microsoft.EntityFrameworkCore;
using Antivirus.Services;
using Antivirus.Models;
using Antivirus.Services.Interfaces;
using Antivirus.Data;

namespace Antivirus.config
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de dependencias
            services.AddScoped<AuthService>();
     
            services.AddScoped<IUbicationInstitutionService, UbicationInstitutionService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IInstitutionOpportunityService, InstitutionOpportunityService>();
            services.AddScoped<IUserBootcampService, UserBootcampService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBootcampService, BootcampService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOpportunityService, OpportunityService>();
            services.AddScoped<IInstituteBootcampService, InstituteBootcampService>();
            services.AddScoped<IUserRoleService, UserRoleService>();        
            services.AddScoped<IUserOpportunityService, UserOpportunityService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IBenefitService, BenefitService>();
            // Configuración de la base de datos
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
