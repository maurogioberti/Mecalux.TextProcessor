using Mecalux.TestProcessor.ResourceAccess.Domains;

namespace Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions
{
    public interface ITextSortRepository
    {
        IEnumerable<TextSort> List();
    }
}
