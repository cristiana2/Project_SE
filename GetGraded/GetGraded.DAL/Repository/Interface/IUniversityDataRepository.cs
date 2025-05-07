using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IUniversityDataRepository
    {
       
        Task<IEnumerable<University>> GetUniversities();
        Task<IEnumerable<Department>> GetDepartments();
        Task<List<Department>> GetDepartmentByUniversityId(int universityId);
        Task<Department> GetDepartmentById(int id);
        Task<IEnumerable<Role>> GetRoles();
        Task<IEnumerable<UniversityYear>> GetUniversityYears();
    }
}
