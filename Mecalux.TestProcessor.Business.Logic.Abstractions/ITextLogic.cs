using Mecalux.TestProcessor.CrossCutting.Enums;

namespace Mecalux.TestProcessor.Business.Logic.Abstractions
{
    public interface ITextLogic
    {
        ResourceAccess.Contracts.Text GetRandom();
        ResourceAccess.Contracts.Statistics GetStatistics(string textContent);
        string Sort(string textContent, SortOption orderOption);
    }
}