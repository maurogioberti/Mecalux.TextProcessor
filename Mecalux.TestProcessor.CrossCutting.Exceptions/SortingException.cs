namespace Mecalux.TestProcessor.CrossCutting.Exceptions
{
    namespace Mecalux.TestProcessor.CrossCutting.Exceptions
    {
        public class SortingException : Exception
        {
            public SortingException()
            {
            }

            public SortingException(string message)
                : base(message)
            {
            }

            public SortingException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}
