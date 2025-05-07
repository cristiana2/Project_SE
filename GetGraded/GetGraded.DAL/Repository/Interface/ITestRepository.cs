using GetGraded.Models.Models;

namespace GetGraded.DAL.Repository.Interface
{
    public interface ITestRepository
    {
        public Task SaveChanges(TestSave test);
    }
}
