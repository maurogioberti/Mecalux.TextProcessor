namespace Mecalux.TestProcessor.Services.Abstractions
{
    public interface ITextService
    {
        ResourceAccess.Contracts.Text GetRandom();
        ResourceAccess.Contracts.Statistics GetStatistics(string textContent);
    }
}