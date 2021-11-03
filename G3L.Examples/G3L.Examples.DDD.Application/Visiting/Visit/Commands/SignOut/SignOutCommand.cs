using G3L.Examples.DDD.Application.Common.Models;
using MediatR;

namespace G3L.Examples.DDD.Application.Visiting.Visit.Commands.SignOut
{
    public class SignOutCommand : IRequest<Result>
    {
        public string Email { get; set; }
    }
}