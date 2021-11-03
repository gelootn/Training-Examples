using G3L.Examples.DDD.Domain.Common;

namespace G3L.Examples.DDD.Domain.Visiting.Exceptions
{
    public class InvalidVisitorException : BaseDomainException
    {
        public InvalidVisitorException()
        {
            
        }

        public InvalidVisitorException(string error) => Error = error;

    }
}