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
        public int UserLoginId { get; set; }
        public UserLoginDetails UserLogin { get; set; }
        public int UniverisityYearId { get; set; }
        public UniversityYear UniversityYear { get; set; }
    }
}
