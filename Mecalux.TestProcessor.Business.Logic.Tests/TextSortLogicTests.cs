using AutoFixture;
using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.CrossCutting.Exceptions.Mecalux.TestProcessor.CrossCutting.Exceptions;
using Mecalux.TestProcessor.ResourceAccess.Contracts;
using Mecalux.TestProcessor.ResourceAccess.Mappers;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;
using Moq;
using NUnit.Framework;

namespace Mecalux.TestProcessor.Business.Logic.Tests
{
    public class TextSortLogicTests
    {
        private class TextSortLogicBuilder
        {
            private Mock<ITextSortRepository>? textSortRepositoryMock;
            public Mock<ITextSortRepository> TextSortRepositoryMock => textSortRepositoryMock ??= new Mock<ITextSortRepository>();
            private TextSortMapper? textSortMapper;
            public ITextSortMapper TextSortMapper => textSortMapper ??= new TextSortMapper();

            public TextSortLogic Build() =>
                new TextSortLogic(TextSortRepositoryMock.Object, TextSortMapper);
        }

        private Fixture fixture = new Fixture();

        [Test]
        public void List_When_Called_Should_Return_Non_Empty_Sort_Options()
        {
            // Arrange
            var builder = new TextSortLogicBuilder();

            var sortResults = fixture.CreateMany<ResourceAccess.Domains.TextSort>();
            builder
                .TextSortRepositoryMock
                .Setup(repo => repo.List())
                .Returns(sortResults);

            // Act
            var result = builder
                            .Build()
                            .List();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Items, Is.Not.Empty);
            Assert.That(result.Items.Count, Is.GreaterThan(1));
        }

        [Test]
        public void Sort_When_Sort_Option_Does_Not_Exists_Should_Throw_SortingException()
        {
            // Arrange
            var builder = new TextSortLogicBuilder();
            var textContent = fixture.Create<string>();

            // Act
            // Assert
            Assert.Throws<SortingException>(() => builder.Build().Sort(textContent, (SortOption)999));
        }

        [TestCase("Hello world apple", SortOption.AlphabeticAsc, "apple Hello world")]
        [TestCase("Hello world apple", SortOption.AlphabeticDesc, "world Hello apple")]
        [TestCase("Hello world apple", SortOption.LengthAsc, "apple Hello world")]
        [TestCase("Hello wor ap", SortOption.LengthAsc, "ap wor Hello")]
        public void Sort_When_Valid_Input_Should_Sort_With_Given_Option(string textContent, SortOption orderOption, string expectedResult)
        {
            // Arrange
            var builder = new TextSortLogicBuilder();

            // Act
            var result = builder.Build().Sort(textContent, orderOption);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}