using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;

namespace Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions
{
    public interface ITextSortMapper
    {
        SortCollection MapCollection(IEnumerable<Domains.TextSort> items);
    }
}