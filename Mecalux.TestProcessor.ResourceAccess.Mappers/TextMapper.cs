using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;

namespace Mecalux.TestProcessor.ResourceAccess.Mappers
{
    public class TextMapper : ITextMapper
    {
        public Contracts.Text Map(Domains.Text text) => new Contracts.Text
        {
            Id = text.Id,
            Content = text.Content
        };
    }
}