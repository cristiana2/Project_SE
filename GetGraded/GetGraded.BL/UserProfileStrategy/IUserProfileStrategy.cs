using GetGraded.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.BL.UserProfileStrategy
{
    public interface IUserProfileStrategy
    {
        Task SaveAdditionalProperties(string userId, UserProfileView userProfileView);
        bool CheckIfStudentHasPassed(int minimumScore, int score);
    }
}
