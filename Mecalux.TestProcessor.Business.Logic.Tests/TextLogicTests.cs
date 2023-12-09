using AutoFixture;
using Mecalux.TestProcessor.ResourceAccess.Mappers;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;
using Moq;
using NUnit.Framework;

namespace Mecalux.TestProcessor.Business.Logic.Tests
{
    public class TextLogicTests
    {
        private class TextLogicBuilder
        {
            private Mock<ITextRepository>? textRepositoryMock;
            public Mock<ITextRepository> TextRepositoryMock => textRepositoryMock ??= new Mock<ITextRepository>();
            private TextMapper? textMapper;
            public ITextMapper TextMapper => textMapper ??= new TextMapper();

            public TextLogic Build() =>
                new TextLogic(TextRepositoryMock.Object, TextMapper);
        }

        private Fixture fixture = new Fixture();

        [Test]
        public void Get_When_Called_Should_Return_Non_Empty_Content()
        {
            // Arrange
            var builder = new TextLogicBuilder();

            var text = fixture.Create<ResourceAccess.Domains.Text>();

            builder
                .TextRepositoryMock
                .Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns(text);

            // Act
            var result = builder
                            .Build()
                            .GetRandom();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.Not.Empty);
            Assert.That(result.Id, Is.GreaterThan(0));
        }

        [TestCase("Hello-world! This is a test.", 1, 5, 4)]
        [TestCase("No-hyphens here but spaces", 1, 4, 3)]
        [TestCase("Testing, one, two, three.", 0, 4, 3)]
        [TestCase("No-Spaces", 1, 1, 0)] 
        public void GetStatistics_When_Valid_Inputs_Should_Return_Expected_Results(string text, int expectedHyphens, int expectedWords, int expectedSpaces)
        {
            // Arrange
            var builder = new TextLogicBuilder();

            // Act
            var result = builder.Build().GetStatistics(text);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Hypens, Is.EqualTo(expectedHyphens), "The hyphen count is incorrect.");
            Assert.That(result.Words, Is.EqualTo(expectedWords), "The word count is incorrect.");
            Assert.That(result.Spaces, Is.EqualTo(expectedSpaces), "The space count is incorrect.");
        }

        [TestCase("", 0, 0, 0)]
        [TestCase("     ", 0, 0, 5)]
        [TestCase("-----", 5, 0, 0)]
        [TestCase("....", 0, 0, 0)]
        public void GetStatistics_When_Unexpected_Inputs_Should_Return_Zero_Or_Specific_Counts(string text, int expectedHyphens, int expectedWords, int expectedSpaces)
        {
            // Arrange
            var builder = new TextLogicBuilder();

            // Act
            var result = builder.Build().GetStatistics(text);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Hypens, Is.EqualTo(expectedHyphens), "The hyphen count is incorrect.");
            Assert.That(result.Words, Is.EqualTo(expectedWords), "The word count is incorrect.");
            Assert.That(result.Spaces, Is.EqualTo(expectedSpaces), "The space count is incorrect.");
        }
    }
}