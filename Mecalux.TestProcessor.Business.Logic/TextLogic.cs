using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.Business.Logic.Abstractions.TextSort;
using Mecalux.TestProcessor.Business.Logic.TextSort;
using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.CrossCutting.Globalization;
using Mecalux.TestProcessor.CrossCutting.Utils.Constants;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.Business.Logic
{
    public class TextLogic : ITextLogic
    {
        public ITextRepository TextRepository { get; }
        public ITextMapper TextMapper { get; }

        public TextLogic(ITextRepository textRepository,
            ITextMapper textMapper)
        {
            TextRepository = textRepository;
            TextMapper = textMapper;
        }

        public ResourceAccess.Contracts.Text GetRandom()
        {
            var random = new Random();
            var randomInteger = random.Next(0, 100);
            var textDomain = TextRepository.Get(randomInteger);

            return TextMapper.Map(textDomain);
        }

        public ResourceAccess.Contracts.Statistics GetStatistics(string textContent)
        {
            var words = SplitText(textContent);

            var hyphenCount = textContent.Count(c => c == TextConstants.Hyphen);
            var wordCount = words.Count(word => word.Any(char.IsLetter));
            var spaceCount = textContent.Count(char.IsWhiteSpace);

            return new ResourceAccess.Contracts.Statistics
            {
                Hypens = hyphenCount,
                Words = wordCount,
                Spaces = spaceCount
            };
        }

        public string Sort(string textContent, SortOption orderOption)
        {
            var words = SplitText(textContent);
            ITextSortingStrategy textSortingStrategy;
            switch (orderOption)
            {
                case SortOption.AlphabeticAsc:
                    textSortingStrategy = new AlphabeticAscendingSort();
                    break;
                case SortOption.AlphabeticDesc:
                    textSortingStrategy = new AlphabeticDescendingSort();
                    break;
                case SortOption.LengthAsc:
                    textSortingStrategy = new LengthAscendingSort();
                    break;
                default:
                    throw new ArgumentException(Messages.InvalidOrderOption);
            }

            return textSortingStrategy.SortedContent(words);
        }

        private IEnumerable<string> SplitText(string textContent)
        {
            return textContent.Split(new[] { TextConstants.Space, TextConstants.CarriageReturn, TextConstants.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}