using GetGraded.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetGraded.Migrations
{
    public class GetGradedContext : IdentityDbContext<IdentityUser>
    {
        public GetGradedContext(DbContextOptions<GetGradedContext> options)
            : base(options)
        {

        }
        public DbSet<TestSave> Service { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }
        public DbSet<StudentDetails> StudentDetail { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UniversityYear> UniversityYear { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        public DbSet<SubmittedAnswer> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Professor" },
                new Role { Id = 2, Name = "Student" }

            );
            modelBuilder.Entity<University>().HasData(
                new University { Id = 1, Name = "University 1" },
                new University { Id = 2, Name = "University 2" }

            );
            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, Name = "Department 1", UniversityId = 1 },
               new Department { Id = 2, Name = "Department 2", UniversityId = 1 },
               new Department { Id = 3, Name = "Department 3", UniversityId = 2 }
           );
            modelBuilder.Entity<UniversityYear>().HasData(
             new UniversityYear { Id = 1, Name = "1st year" },
             new UniversityYear { Id = 2, Name = "2nd year" },
             new UniversityYear { Id = 3, Name = "3rd year" },
             new UniversityYear { Id = 4, Name = "4th year" }
         );

            modelBuilder.Entity<Assignment>().HasData(
               new Assignment
               {
                   Id = 1,
                   Name = "Research Paper",
                   Description = "Write a research paper on a topic of your choice",
                   DepartmentId = 1,
                   UniversityYearId = 1,
                   DeadLine = new DateTime(2024, 05, 18, 12, 30, 0)
               },
               new Assignment
               {
                   Id = 2,
                   Name = "Math Problem Set",
                   Description = "Complete the math problem set covering chapters 1-5",
                   DepartmentId = 1,
                   UniversityYearId = 1,
                   DeadLine = new DateTime(2024, 05, 17, 17, 30, 0)
               },
               new Assignment
               {
                   Id = 3,
                   Name = "Literature Analysis",
                   Description = "Analyze and write a critical review of a selected literary work. Focus on themes, characters, and writing style",
                   DepartmentId = 2,
                   UniversityYearId = 1,
                   DeadLine = new DateTime(2024, 05, 27, 14, 30, 0)
               },
               new Assignment
               {
                   Id = 4,
                   Name = "Lab Report",
                   Description = "Conduct an experiment in the lab and write a detailed report documenting the procedure, results, and conclusions",
                   DepartmentId = 3,
                   UniversityYearId = 3,
                   DeadLine = new DateTime(2024, 05, 30, 1, 30, 0)
               }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
