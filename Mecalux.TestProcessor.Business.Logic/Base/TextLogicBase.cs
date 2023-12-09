using Mecalux.TestProcessor.CrossCutting.Utils.Constants;

namespace Mecalux.TestProcessor.Business.Logic.Base
{
    public class TextLogicBase
    {
        protected IEnumerable<string> SplitText(string textContent)
        {
            return textContent.Split(new[] { TextConstants.Space, TextConstants.CarriageReturn, TextConstants.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}