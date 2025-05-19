using GetGraded.BL.UserProfileStrategy.Implementation;
using GetGraded.DAL.Repository.Interface;
using Moq;

namespace GetGrader.Tests
{
    public class GetGradedUnitTests
    {
        private Mock<IUserProfileRepository> userProfileRepositoryMock;
        private Mock<IAssignmentRepository> assignmentRepositoryMock;
        private StudentProfileStrategy studentProfileStrategy;

        [SetUp]
        public void SetUp()
        {
            userProfileRepositoryMock = new Mock<IUserProfileRepository>();
            assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            studentProfileStrategy = new StudentProfileStrategy(userProfileRepositoryMock.Object, assignmentRepositoryMock.Object);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreIsAbovePassingScore_ReturnsTrue()
        {
            // Arrangement
            int score = 80;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.CheckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreIsBelowPassingScore_ReturnsFalse()
        {
            // Arrangement
            int score = 60;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.CheckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreEqualsPassingScore_ReturnsTrue()
        {
            // Arrangement
            int score = 80;
            int passingScore = 80;

            // Act
            bool result = studentProfileStrategy.CheckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreIsNegative_ReturnsFalse()
        {
            // Arrange
            int score = -5;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.CheckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void CheckIfStudentHasPassed_WhenScoreIsVeryHigh_ReturnsTrue()
        {
            // Arrange
            int score = 1000;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.CheckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsTrue(result);
        }


    }
}