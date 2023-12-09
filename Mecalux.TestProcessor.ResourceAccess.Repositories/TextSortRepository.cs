using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.ResourceAccess.Domains;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.ResourceAccess.Repositories
{
    public class TextSortRepository : ITextSortRepository
    {
        // TODO: Currently, this method generates a list of sort options directly from the SortOption enum.
        // This approach serves as a representative example for the technical exercise.
        // In a real-world scenario, this data might come from a database or a configuration file.
        
        public IEnumerable<TextSort> List()
        {
            return Enum
                    .GetValues(typeof(SortOption))
                    .Cast<SortOption>()
                    .Select((option, index) => new TextSort
                    {
                        Id = index,
                        Option = option
                    })
                    .ToList();
        }
    }
}