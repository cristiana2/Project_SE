using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Interface
{
    public interface IUniversityDataService
    {
        Task<List<Department>> GetDepartmentByUniversityId(int universityId);
        Task<IEnumerable<Department>> GetDepartments();
        Task<IEnumerable<University>> GetUninversities();
        Task<IEnumerable<Role>> GetRoles();
        Task<IEnumerable<UniversityYear>> GetUniversityYears();
    }
}
