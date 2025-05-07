using GetGraded.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGraded.Models.ViewModels
{
    public class AssignmentDetailsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int MinunumPassingScore { get; set; }
        public int? AnswerId { get; set; }
        public string?  PathFile { get; set; }
        public int Role { get; set; }
        public int Score {get;set;} 
        public bool isCompleted { get; set; }
    }
}
