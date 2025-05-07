using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.DAL.Repository.Implementation
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly GetGradedContext _context;
        public UserProfileRepository(GetGradedContext context)
        {
            _context = context;
        }

        public async Task<int> SaveUserProfile(UserProfile userProfile)
        {
          
            await _context.UserProfile.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile.Id;
        }

        public async Task SaveUserLoginDetails(UserLoginDetails userLoginDetails)
        {
            await _context.UserLoginDetails.AddAsync(userLoginDetails);
            await _context.SaveChangesAsync();
         
        }

        public async Task<int?> FindUserProfile(string email)
        {
            var userProfile = await  _context.UserLoginDetails.FirstOrDefaultAsync(m => m.Email ==email);
            return userProfile!=null? userProfile.Id : null ;
        }
        public async Task<UserProfile> FindUserProfileById(string id)
        {
            return  await _context.UserProfile.FirstOrDefaultAsync(m => m.AspNetUserId == id);
        }
        public async Task SaveStudentDetails(StudentDetails studentDetails)
        {
            await _context.StudentDetail.AddAsync(studentDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentDetailsByUserId(string userId)
        {
            return await _context.StudentDetail.FirstOrDefaultAsync(s => s.AspNetUserId == userId);
        }

    }
}
