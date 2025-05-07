using GetGraded.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
namespace GetGraded.Models.ViewModels
{
    public class UserProfileView
    {
        [Required(ErrorMessage = "Please provide your first name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Please provide your last name", AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide your email", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your password", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int UniversityYearId { get; set; }
        public IEnumerable<SelectListItem> UniversityYears { get; set; }
        public IEnumerable<SelectListItem> Universites { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
