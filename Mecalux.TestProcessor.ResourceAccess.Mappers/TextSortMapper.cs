using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;

namespace Mecalux.TestProcessor.ResourceAccess.Mappers
{
    public class TextSortMapper : ITextSortMapper
    {
        private Contracts.Sort Map(Domains.TextSort textSort) => new Contracts.Sort
        {
            Id = textSort.Id,
            Option = textSort.Option.ToString()
        };

        public SortCollection MapCollection(IEnumerable<Domains.TextSort> items)
        {
            var contracts = items.Select(x => Map(x));
            return new SortCollection(contracts, contracts.Count());
        }
    }
}