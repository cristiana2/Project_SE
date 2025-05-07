using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Implementation
{
    public  class UniverisityDataRepository : IUniversityDataRepository
    {
        private readonly GetGradedContext _context;
        public UniverisityDataRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentByUniversityId(int universityId)
        {
            var department = await _context.Department.Where(m => m.UniversityId == universityId).ToListAsync();
            return department;
        }

        public async Task<IEnumerable<University>> GetUniversities()
        {
            return _context.University;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return _context.Department;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return _context.Role;
        }

        public async Task<IEnumerable<UniversityYear>> GetUniversityYears()
        {
            return _context.UniversityYear;
        }

        public async  Task<Department> GetDepartmentById(int id)
        {
            var department = await _context.Department.Where(m => m.Id == id).FirstOrDefaultAsync();
            return department;
        }
    }
}
