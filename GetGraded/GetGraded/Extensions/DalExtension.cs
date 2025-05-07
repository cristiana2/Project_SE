using GetGraded.BL.Services.Implementation;
using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Implementation;
using GetGraded.DAL.Repository.Interface;

namespace GetGraded.Extensions
{
    public static class DalExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUniversityDataRepository, UniverisityDataRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            return services;
        }
    }
}
