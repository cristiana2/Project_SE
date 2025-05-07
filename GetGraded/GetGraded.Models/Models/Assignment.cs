namespace GetGraded.Models.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UniversityYearId { get; set; }
        public UniversityYear UniversityYear { get; set; }
        public int MinunumPassingScore { get; set; }
    }
}
