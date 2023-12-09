using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.Services.Abstractions;
using Mecalux.TestProcessor.Services.Base;

namespace Mecalux.TestProcessor.Services
{
    public class TextService : ServiceBase, ITextService
    {
        public ITextLogic TextLogic { get; }

        public TextService(ITextLogic textLogic)
        {
            TextLogic = textLogic;
        }


        public ResourceAccess.Contracts.Text GetRandom()
        {
            try
            {
                return this.TextLogic.GetRandom();
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }

        public ResourceAccess.Contracts.Statistics GetStatistics(string textContent)
        {
            try
            {
                return this.TextLogic.GetStatistics(textContent);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }

            return default;
        }
    }
}
