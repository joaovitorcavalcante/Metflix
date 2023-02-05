using MediatR;
using Metflix.Application.Authentication.Common.Results;
using Metflix.Application.Common.Results;

namespace Metflix.Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<CommandResult<AuthenticationResult>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
