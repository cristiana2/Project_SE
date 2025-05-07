using GetGraded.BL.Services.Implementation;
using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Implementation;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;

namespace GetGraded.Extensions
{
    public static class BlExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<IUniversityDataService, UniversityDataService>();
            return services;
        }
    }
}
