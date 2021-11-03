using G3L.Examples.DDD.Domain.Common;

namespace G3L.Examples.DDD.Domain.Companies.Exceptions
{
    public class InvalidCompanyException : BaseDomainException
    {
        public InvalidCompanyException()
        {
        }

        public InvalidCompanyException(string error) => Error = error;
    }
}