using GetGraded.BL.Services.Interface;
using GetGraded.BL.UserProfileStrategy;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GetGraded.BL.Services.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserProfileStrategy _userProfileStrategy;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;

        public UserProfileService(IUserProfileRepository userProfileRepository, 
            IUserProfileStrategy userProfileStrategy,
               UserManager<IdentityUser> userManager,
  IUserStore<IdentityUser> userStore,
  SignInManager<IdentityUser> signInManager,
  IEmailSender emailSender)
        {
            _userProfileRepository = userProfileRepository;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userProfileStrategy = userProfileStrategy;

        }


        public async Task CreateAccount(UserProfileView userprofile)
        {
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, userprofile.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, userprofile.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, userprofile.Password);

            if (result.Succeeded)
            {
              

                var userId = await _userManager.GetUserIdAsync(user);
                
                await _userProfileRepository.SaveUserProfile(new UserProfile()
                {
                    FirstName = userprofile.FirstName,
                    MiddleName = userprofile.MiddleName,
                    LastName = userprofile.LastName,
                    BirthDate = userprofile.BirthDate,
                    AspNetUserId = userId,
                    RoleId = userprofile.RoleId,
                    DepartmentId = userprofile.DepartmentId,
                });
                await _userProfileStrategy.SaveAdditionalProperties(userId,  userprofile);
            }
        }
        public async Task<bool> CheckEmailAvailability(string email)

        {
            var userProfile = await  _userProfileRepository.FindUserProfile(email);
            return userProfile == null ? false : true ;
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

    }
        
}
