using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.Models
{
    public class SubmittedAnswer
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public string SubmitterId { get; set; }
        public IdentityUser Submitter { get; set; }

        public string? ReviewerId { get; set; }
        public IdentityUser Reviewer { get; set; }
        public int? Score {  get; set; }
    }
}
