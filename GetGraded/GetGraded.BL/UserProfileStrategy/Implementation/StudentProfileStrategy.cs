using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;

namespace GetGraded.BL.UserProfileStrategy.Implementation
{
    public class StudentProfileStrategy : IUserProfileStrategy
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        public StudentProfileStrategy(IUserProfileRepository userProfileRepository, IAssignmentRepository assignmentRepository)
        {
            _userProfileRepository = userProfileRepository;
            _assignmentRepository = assignmentRepository;
        }
        public async Task SaveAdditionalProperties(string userId, UserProfileView userProfileView)
        {
            await _userProfileRepository.SaveStudentDetails(new StudentDetails()
            {
                AspNetUserId = userId,
                UniversityYearId = userProfileView.UniversityYearId
            });
        }

        public async Task GetReviewedAssignments(string userId)
        {
            // 
           
        }

        public bool CheckIfStudentHasPassed(int minimumScore, int score)
        {
            if(minimumScore>= score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
