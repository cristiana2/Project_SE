using GetGraded.Models.Models;

namespace GetGraded.BL.Services.Interface
{
    public interface ITestService
    {
        public Task SaveChanges(TestSave test);
    }
}
