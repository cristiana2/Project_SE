using GetGraded.BL.Services.Interface;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.Services.Implementation
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUniversityDataRepository _universityDataRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository,
            IUserProfileRepository userProfileRepository,
            IUniversityDataRepository universityDataRepository)
        {
            _assignmentRepository = assignmentRepository;
            _userProfileRepository = userProfileRepository;
            _universityDataRepository = universityDataRepository;
        }
        public async Task<List<AssignmentDetailsView>> GetAssignments(string userId)
        {
            var userProfile = await _userProfileRepository.FindUserProfileById(userId);
            var assignments = new List<Assignment>();
            var assignmentsView = new List<AssignmentDetailsView>();
            if (userProfile.RoleId == 2)
            {
                var studentDetails = await _userProfileRepository.GetStudentDetailsByUserId(userId);

                assignments = await _assignmentRepository.GetAssignmentsByDepartmentIdUniversityYearId(userProfile.DepartmentId, studentDetails.UniversityYearId);
                foreach (var assignment in assignments)
                {
                    var department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);
                    var answer = await _assignmentRepository.GetAnswerByAssignmentId(assignment.Id);
                    if (answer == null)
                    {
                        assignmentsView.Add(new AssignmentDetailsView()
                        {
                            Id = assignment.Id,
                            Name = assignment.Name,
                            Description = assignment.Description,
                            DeadLine = assignment.DeadLine,
                            DepartmentId = assignment.DepartmentId,
                            Department = department,
                            MinunumPassingScore = assignment.MinunumPassingScore,
                            PathFile = null,
                            Role = 2,
                            Score = 0,
                            isCompleted = false,
                        });
                    }
                }

            }
            else
            {
                var assignmentsTotal = await _assignmentRepository.GetAssignmentsByDepartmentId(userProfile.DepartmentId);
                foreach (var assignment in assignmentsTotal)
                {
                    assignment.Department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);
                }
                foreach (var assignment in assignmentsTotal)
                {
                    var answer = await _assignmentRepository.GetAnswerByAssignmentId(assignment.Id);
                    if (answer != null && answer.ReviewerId == null)
                    {
                        var department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);

                        assignmentsView.Add(new AssignmentDetailsView()
                        {
                            Id = assignment.Id,
                            Name = assignment.Name,
                            Description = assignment.Description,
                            DeadLine = assignment.DeadLine,
                            DepartmentId = assignment.DepartmentId,
                            Department = department,
                            AnswerId = answer.Id,
                            MinunumPassingScore = assignment.MinunumPassingScore,
                            PathFile = answer.Path,
                            Role = 1,
                            Score = 0,
                            isCompleted = false,
                        });
                    }
                }
            }
            return assignmentsView;
        }

        public async Task<AssignmentDetailsView> GetAssignmentsById(int id, string userId)
        {
            var userProfile = await _userProfileRepository.FindUserProfileById(userId);
            var assignment = await _assignmentRepository.GetAssignmentsById(id);
            if (userProfile.RoleId == 2)
            {
                var answer = await _assignmentRepository.GetAnswerByAssignmentId(assignment.Id);
                if (answer == null)
                {
                    var department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);
                    return new AssignmentDetailsView()
                    {
                        Id = assignment.Id,
                        Name = assignment.Name,
                        Description = assignment.Description,

                        DeadLine = assignment.DeadLine,
                        DepartmentId = assignment.DepartmentId,
                        Department = department,
                        MinunumPassingScore = assignment.MinunumPassingScore,
                        PathFile = null,
                        Role = 2,
                        Score = 0,
                        isCompleted = false,
                    };
                }

            }
            else
            {
                var answer = await _assignmentRepository.GetAnswerByAssignmentId(assignment.Id);
                if (answer != null && answer.ReviewerId == null)
                {
                    var department = await _universityDataRepository.GetDepartmentById(assignment.DepartmentId);

                    return new AssignmentDetailsView()
                    {
                        Id = assignment.Id,
                        Name = assignment.Name,
                        Description = assignment.Description,
                        DeadLine = assignment.DeadLine,
                        DepartmentId = assignment.DepartmentId,
                        Department = department,
                        AnswerId = answer.Id,
                        MinunumPassingScore = assignment.MinunumPassingScore,
                        PathFile = answer.Path,
                        Role = 1,
                        Score = 0,
                        isCompleted = false,
                    };
                }
            }
            return null;
          
        }

        public async Task SaveAnswer(int assignmentId, string userId, string path)
        {
            await _assignmentRepository.SaveAnswer(new SubmittedAnswer()
            {
                AssignmentId = assignmentId,
                SubmitterId = userId,
                Path = path
            });
        }

        public async Task UpdateAnwer(int score, int answerId, string userId)
        {
          
            var answer = await _assignmentRepository.GetAnswerById(answerId);
            if (answer != null)
            {
                answer.Score = score;
                answer.ReviewerId = userId;
                await _assignmentRepository.SaveAnswer(answer);
            }
        }
    }
}
