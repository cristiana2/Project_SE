using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.Models
{
    public class Department
    {
        public int Id { get; set; }
       
        public int UniversityId {  get; set; }
        public University University { get; set; }
        public string Name { get; set; }
    }
}
