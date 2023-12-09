using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;

namespace Mecalux.TestProcessor.Services.Abstractions
{
    public interface ITextSortService
    {
        SortCollection List();
        string Sort(string textContent, SortOption orderOption);
    }
}