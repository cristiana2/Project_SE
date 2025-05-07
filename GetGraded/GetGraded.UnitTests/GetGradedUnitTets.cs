using GetGraded.BL.UserProfileStrategy;
using GetGraded.BL.UserProfileStrategy.Implementation;
using GetGraded.DAL.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace GetGraded.UnitTests
{

    
    public class StudentProfileStrategyTests
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
            // Arrange
            int score = 80;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.ChehckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreIsBelowPassingScore_ReturnsFalse()
        {
            // Arrange
            int score = 60;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.ChehckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckIfStudentHasPassed_WhenScoreEqualsPassingScore_ReturnsTrue()
        {
            // Arrange
            int score = 70;
            int passingScore = 70;

            // Act
            bool result = studentProfileStrategy.ChehckIfStudentHasPassed(score, passingScore);

            // Assert
            Assert.IsTrue(result);
        }
    }

}

