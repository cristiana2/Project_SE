using GetGraded.BL.Services.Implementation;
using GetGraded.DAL.Repository.Interface;
using GetGraded.Models.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GetGrader.Tests
{
    public class AssignmentServiceTests
    {
        private Mock<IAssignmentRepository> _assignmentRepository;
        private Mock<IUserProfileRepository> _userProfileRepository;
        private Mock<IUniversityDataRepository> _universityDataRepository;
        private AssignmentService _assignmentService;

        [SetUp]
        public void Setup()
        {
            _assignmentRepository = new Mock<IAssignmentRepository>();
            _userProfileRepository = new Mock<IUserProfileRepository>();
            _universityDataRepository = new Mock<IUniversityDataRepository>();

            _assignmentService = new AssignmentService(
                _assignmentRepository.Object,
                _userProfileRepository.Object,
                _universityDataRepository.Object
            );
        }

        [Test]
        public async Task SaveAnswer_ShouldCallRepositoryWithCorrectSubmittedAnswer()
        {
            // Arrange
            int assignmentId = 1;
            string userId = "student123";
            string path = "/path/to/file.pdf";

            SubmittedAnswer capturedAnswer = null;

            _assignmentRepository
                .Setup(x => x.SaveAnswer(It.IsAny<SubmittedAnswer>()))
                .Callback<SubmittedAnswer>(a => capturedAnswer = a)
                .Returns(Task.CompletedTask);

            // Act
            await _assignmentService.SaveAnswer(assignmentId, userId, path);

            // Assert
            _assignmentRepository.Verify(x => x.SaveAnswer(It.IsAny<SubmittedAnswer>()), Times.Once);
            Assert.IsNotNull(capturedAnswer);
            Assert.AreEqual(assignmentId, capturedAnswer.AssignmentId);
            Assert.AreEqual(userId, capturedAnswer.SubmitterId);
            Assert.AreEqual(path, capturedAnswer.Path);
        }
    }
}
