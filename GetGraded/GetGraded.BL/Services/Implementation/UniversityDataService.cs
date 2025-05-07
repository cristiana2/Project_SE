using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Implementation
{
    public class UniversityDataService: IUniversityDataService
    {
        private readonly IUniversityDataRepository _universityDataRepository;
        public UniversityDataService(IUniversityDataRepository universityDataRepository)
        {
            _universityDataRepository = universityDataRepository;
        }
        public async Task<List<Department>> GetDepartmentByUniversityId(int universityId)
        {
            return await _universityDataRepository.GetDepartmentByUniversityId(universityId);
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _universityDataRepository.GetDepartments();
        }
        public async Task<IEnumerable<University>> GetUninversities()
        {
            return await _universityDataRepository.GetUniversities();
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _universityDataRepository.GetRoles();
        }
        public async Task<IEnumerable<UniversityYear>> GetUniversityYears()
        {
            return await _universityDataRepository.GetUniversityYears();
        }
    }
}
