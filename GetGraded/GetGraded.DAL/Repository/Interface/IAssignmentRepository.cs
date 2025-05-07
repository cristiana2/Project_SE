using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.DAL.Repository.Interface
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAssignmentsByDepartmentIdUniversityYearId(int departmentId, int universityYearId);
        Task<List<Assignment>> GetAssignmentsByDepartmentId(int departmentId);
        Task<Assignment> GetAssignmentsById(int id);
        Task SaveAnswer(SubmittedAnswer answer);
        Task<SubmittedAnswer?> GetAnswerByAssignmentId(int assignmentId);
        Task<SubmittedAnswer?> GetAnswerById(int id);
    }
}
