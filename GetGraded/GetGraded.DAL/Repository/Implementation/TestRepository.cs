using GetGraded.DAL.Repository.Interface;
using GetGraded.Migrations;
using GetGraded.Models.Models;

namespace GetGraded.DAL.Repository.Implementation
{
    public class TestRepository : ITestRepository
    {
       private readonly GetGradedContext _context;
      public TestRepository(GetGradedContext context)
        {
            _context = context;
        }
     
        public async Task SaveChanges(TestSave test)
        {
            _context.Service.Add(test);
             _context.SaveChanges();
        }
    }
}
