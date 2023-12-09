using AutoFixture;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;

namespace Mecalux.TestProcessor.ResourceAccess.Repositories
{
    public class TextRepository : ITextRepository
    {
        // TODO: This class currently uses AutoFixture for mock data generation as a placeholder.
        // The actual database implementation is pending. Implement MecaluxContext for database operations.
        // This mock setup is representative for the purposes of this exercise.

        private Fixture fixture = new Fixture();

        public Domains.Text Get(int id)
        {
            return fixture
                    .Build<Domains.Text>()
                    .With(x => x.Id, id)
                    .Create();
        }
    }
}