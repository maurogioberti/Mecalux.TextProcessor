using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;
using Mecalux.TestProcessor.Services.Abstractions;
using Mecalux.TestProcessor.Services.Base;

namespace Mecalux.TestProcessor.Services
{
    public class TextSortService : ServiceBase, ITextSortService
    {
        public ITextSortLogic TextSortLogic { get; }

        public TextSortService(ITextSortLogic textSortLogic)
        {
            TextSortLogic = textSortLogic;
        }

        public SortCollection List()
        {
            try
            {
                return this.TextSortLogic.List();
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }

        public string Sort(string textSortContent, SortOption orderOption)
        {
            try
            {
                return this.TextSortLogic.Sort(textSortContent, orderOption);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }
    }
}