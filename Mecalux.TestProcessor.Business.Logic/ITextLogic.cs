namespace Mecalux.TestProcessor.Business.Logic
{
    public interface ITextLogic
    {
        ResourceAccess.Contracts.Text GetRandom();
        ResourceAccess.Contracts.Statistics GetStatistics(string textContent);

    }
}