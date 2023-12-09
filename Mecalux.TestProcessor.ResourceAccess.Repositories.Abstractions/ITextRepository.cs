namespace Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions
{
    public interface ITextRepository
    {
        Domains.Text Get(int id);
    }
}