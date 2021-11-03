using System;
using System.Collections.Generic;
using System.Linq;

namespace G3L.Examples.DDD.Application.Common.Models
{
    public class Result
    {
        private readonly List<string> _errors;
        
        internal Result(bool succeeded, List<string> errors)
        {
            Succeeded = succeeded;
            _errors = errors;
        }

        public bool Succeeded { get; private set; }

        public List<string> Errors => Succeeded ? new List<string>() : _errors;
        
        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors.ToList());
        
        public static implicit operator Result(bool success)
            => success ? Success : Failure(new[] { "Unsuccessful operation." });
    }
    
    public class Result<TData> : Result
    {
        private readonly TData data;

        private Result(bool succeeded, TData data, List<string> errors)
            : base(succeeded, errors)
            => this.data = data;

        public TData Data
            => this.Succeeded
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with a failed result. Use {this.Errors} instead.");

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, new List<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default!, errors.ToList());

        /*public static implicit operator Result<TData>(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);

        public static implicit operator bool(Result<TData> result)
            => result.Succeeded;*/
    }
}