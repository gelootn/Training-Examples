using System;

namespace G3L.Examples.DDD.Domain.Common
{
    public abstract class BaseDomainException : Exception
    {
        private string _error;

        public string Error
        {
            get => _error ?? base.Message;
            set => _error = value;
        }
    }
}