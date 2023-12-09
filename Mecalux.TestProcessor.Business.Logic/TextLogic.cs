using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.Business.Logic
{
    public class TextLogic
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

        public ResourceAccess.Contracts.Statistics GetStatics(string textContent)
        {
            var hyphenCount = textContent.Count(c => c == '-');
            var wordCount = textContent.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            var spaceCount = textContent.Count(char.IsWhiteSpace);

            return new ResourceAccess.Contracts.Statistics
            {
                Hypens = hyphenCount,
                Words = wordCount,
                Spaces = spaceCount
            };
        }
    }
}