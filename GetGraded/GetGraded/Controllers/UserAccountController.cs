using GetGraded.BL.Services.Interface;
using GetGraded.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace GetGraded.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserProfileService _userProfileSrvice;
        private readonly IUniversityDataService _universityDataService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;

        private readonly ILogger<HomeController> _logger;

        public UserAccountController(ILogger<HomeController> logger, 
            IUserProfileService userProfileSrvice,
            IUniversityDataService universityDataService,

              UserManager<IdentityUser> userManager,
  IUserStore<IdentityUser> userStore,
  SignInManager<IdentityUser> signInManager,
  IEmailSender emailSender)
        {
            _logger = logger;
            _userProfileSrvice = userProfileSrvice;
            _universityDataService = universityDataService;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _emailSender = emailSender;
        }


        public async Task<IActionResult> SignUp(UserProfileView userProfile)
        {

            userProfile.Universites = (await _universityDataService.GetUninversities()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.Roles = (await _universityDataService.GetRoles()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.UniversityYears = (await _universityDataService.GetUniversityYears()).ToList().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            userProfile.Departments = new List<SelectListItem>();
            return View(userProfile);
        }
       
        [HttpGet]
        public async Task<IActionResult> GetDepartments(int universityId)
        {
            var departments = (await _universityDataService.GetDepartmentByUniversityId(universityId))
                .Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name });
            return Json(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmailAvailability(string email)
        {
           
            bool isEmailAvailable = await _userProfileSrvice.CheckEmailAvailability(email);
            return Json(new { available = !isEmailAvailable });
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAccount( UserProfileView userProfile)
        {
            await _userProfileSrvice.CreateAccount(userProfile);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return RedirectToAction("Login", "UserAccount");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LoginUser(UserLoginView userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return RedirectToAction("Overview", "Assignment");
            }
         
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                 return RedirectToAction("Login", "UserAccount");
            }
          
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
