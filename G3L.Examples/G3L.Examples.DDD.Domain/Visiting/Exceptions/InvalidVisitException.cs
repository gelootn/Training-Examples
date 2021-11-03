using G3L.Examples.DDD.Domain.Common;

namespace G3L.Examples.DDD.Domain.Visiting.Exceptions
{
    public class InvalidVisitException : BaseDomainException
    {
        public InvalidVisitException()
        {
            
        }

        public InvalidVisitException(string error) => Error = error;
    }
}