using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public IdentityUser AspNetUser { get; set; }
        public int UniversityYearId { get; set; }
        public UniversityYear UniversityYear { get; set; }
    }
}
