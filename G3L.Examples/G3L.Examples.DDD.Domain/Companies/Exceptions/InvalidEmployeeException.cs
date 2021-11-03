using G3L.Examples.DDD.Domain.Common;

namespace G3L.Examples.DDD.Domain.Companies.Exceptions
{
    public class InvalidEmployeeException : BaseDomainException
    {
        public InvalidEmployeeException()
        {
            
        }

        public InvalidEmployeeException(string error) => Error = error;
    }
}