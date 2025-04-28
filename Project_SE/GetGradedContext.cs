using GetGraded.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_SE
{
    public class GetGradedContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Professor"},
                new Role { Id = 2, Name = "Student" }

            );
            modelBuilder.Entity<University>().HasData(
                new University { Id = 1, Name = "University 1" },
                new University { Id = 2, Name = "University 2" }
                
            );
            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, Name = "Department 1" , UniversityId = 1 },
               new Department { Id = 2, Name = "Department 2", UniversityId = 1 },
               new Department { Id = 3, Name = "Department 3", UniversityId = 2 }
           );
            modelBuilder.Entity<UniversityYear>().HasData(
             new UniversityYear { Id = 1, Name = "1st year"},
             new UniversityYear { Id = 2, Name = "2nd year"},
             new UniversityYear { Id = 3, Name = "3rd year" },
             new UniversityYear { Id = 4, Name = "4th year" }
         );
        }
    }
}
