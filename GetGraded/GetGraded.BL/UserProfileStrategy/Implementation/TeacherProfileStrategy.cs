using GetGraded.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.UserProfileStrategy.Implementation
{
    public class TeacherProfileStrategy : IUserProfileStrategy
    {
        public bool CheckIfStudentHasPassed(int minimumScore, int score)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAdditionalProperties(string userId, UserProfileView userProfileView)
        {
          
        }
    }
}
