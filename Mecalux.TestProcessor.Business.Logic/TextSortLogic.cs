using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.Business.Logic
{
    public class TextSortLogic
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
    }
}