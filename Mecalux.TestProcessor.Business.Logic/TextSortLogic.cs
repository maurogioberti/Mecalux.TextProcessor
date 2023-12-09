using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.Business.Logic.Abstractions.TextSort;
using Mecalux.TestProcessor.Business.Logic.Base;
using Mecalux.TestProcessor.Business.Logic.TextSort;
using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.CrossCutting.Exceptions.Mecalux.TestProcessor.CrossCutting.Exceptions;
using Mecalux.TestProcessor.CrossCutting.Globalization;
using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.Business.Logic
{
    public class TextSortLogic : TextLogicBase, ITextSortLogic
    {
        public ITextSortRepository TextSortRepository { get; }
        public ITextSortMapper TextSortMapper { get; }

        public TextSortLogic(ITextSortRepository textSortRepository,
            ITextSortMapper textSortMapper)
        {
            TextSortRepository = textSortRepository;
            TextSortMapper = textSortMapper;
        }

        public SortCollection List()
        {
            var textSortDomains = TextSortRepository.List();

            return TextSortMapper.MapCollection(textSortDomains);
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
                    throw new SortingException(Messages.InvalidOrderOption);
            }

            return textSortingStrategy.SortedContent(words);
        }

    }
}