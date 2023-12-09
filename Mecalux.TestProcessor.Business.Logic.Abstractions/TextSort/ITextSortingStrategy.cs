using Mecalux.TestProcessor.CrossCutting.Utils.Constants;

namespace Mecalux.TestProcessor.Business.Logic.Abstractions.TextSort
{
    public interface ITextSortingStrategy
    {
        public string SortedContent(IEnumerable<string> words)
        {
            var sortedWords = Sort(words);
            return string.Join(TextConstants.Space, sortedWords);
        }

        IEnumerable<string> Sort(IEnumerable<string> words);
    }
}