using AutoFixture;
using Mecalux.TestProcessor.CrossCutting.Utils.Constants;
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
            // Generating random text to test the application functionality.
            // A random number is created to represent the length of the text, ranging from 5 to 120 words.
            // AutoFixture is then used to generate that number of random strings (words),
            // and they are joined using a space as a separator to form a long string simulating a text.
            Random random = new Random();
            var randomLength = random.Next(5, 120);
            var longString = string.Join(TextConstants.Space, fixture.CreateMany<string>(randomLength));

            return fixture
                    .Build<Domains.Text>()
                    .With(x => x.Id, id)
                    .With(x => x.Content, longString)
                    .Create();
        }
    }
}