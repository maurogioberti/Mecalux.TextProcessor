using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;

namespace Mecalux.TestProcessor.Business.Logic.Abstractions
{
    public interface ITextSortLogic
    {
        SortCollection List();
        string Sort(string textContent, SortOption orderOption);
    }
}