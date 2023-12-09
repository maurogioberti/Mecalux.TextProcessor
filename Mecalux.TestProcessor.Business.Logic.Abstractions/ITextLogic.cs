namespace Mecalux.TestProcessor.Business.Logic.Abstractions
{
    public interface ITextLogic
    {
        ResourceAccess.Contracts.Text GetRandom();
        ResourceAccess.Contracts.Statistics GetStatistics(string textContent);
    }
}