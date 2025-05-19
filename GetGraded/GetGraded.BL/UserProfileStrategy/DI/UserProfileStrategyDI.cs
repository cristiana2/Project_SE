using GetGraded.BL.UserProfileStrategy.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace GetGraded.BL.UserProfileStrategy.DI
{
    public static class ServiceExtension
    {
        public static void RegisterUserProfileStrategy(this IServiceCollection services)
        {
            services.AddTransient<StudentProfileStrategy>();
            services.AddTransient<TeacherProfileStrategy>();
            services.AddTransient(GetUserProfileStrategy);
        }

        internal static IUserProfileStrategy GetUserProfileStrategy(IServiceProvider serviceProvider)
        {
           
            IHttpContextAccessor contextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
            int? role = contextAccessor.GetRoleId();
            return role switch
            {
                1 => serviceProvider.GetService<TeacherProfileStrategy>(),
                _ => serviceProvider.GetService<StudentProfileStrategy>(),
            };
        }

      
      
        public static int? GetRoleId(this IHttpContextAccessor httpContextAccessor)
        {
            HttpContext httpContext = httpContextAccessor.HttpContext;
            var  roleId = GetRoleIdFromParams(httpContext);
            return roleId;
        }

        public static int? GetRoleIdFromParams(HttpContext httpContext)
        {
            if (httpContext.Request.ContentLength > 0)
            {
                httpContext.Request.EnableBuffering();
                var reader = new StreamReader(httpContext.Request.Body);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                string rawMessage = reader.ReadToEndAsync().Result;
                httpContext.Request.Body.Position = 0;
                int roleId = 0;
                if (rawMessage != null && rawMessage.Contains("roleId", StringComparison.OrdinalIgnoreCase))
                {
                    roleId = GetRoleIdValue(rawMessage);
                }
                if (roleId != 0)
                {          
                    return roleId;
                }
            }
            return null;
        }

        public static int GetRoleIdValue(string rawMessage)
        {
            Match match = Regex.Match(rawMessage, @"RoleId=(\d+)");
            if (match.Success)
            {
                string roleIdValue = match.Groups[1].Value;
                return Int32.Parse(roleIdValue);
            }
            return 0;
        }
    }
}
