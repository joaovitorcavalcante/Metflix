using MediatR;
using Metflix.Application.Authentication.Common.Results;
using Metflix.Application.Common.Results;
using Metflix.Domain.Entities;
using Metflix.Domain.Exceptions;
using Metflix.Domain.Repositories;
using Metflix.Infraestructure.Authentication.Interfaces;
using Metflix.Infraestructure.Persistence.Managers;
using Metflix.Infraestructure.Persistence.Repositories;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;

namespace Metflix.Application.Authentication.Commands.Register
{
    public class RegisterHandler
        : IRequestHandler<RegisterCommand, CommandResult<AuthenticationResult>>
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterHandler(
            IRepositoryManager repositoryManager,
            IJWTTokenGenerator jwtTokenGenerator, 
            IPasswordHasher passwordHasher)
        {
            _repositoryManager = repositoryManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<CommandResult<AuthenticationResult>> Handle(
            RegisterCommand request, 
            CancellationToken cancellationToken)
        {
            if (await _repositoryManager.User.FindByEmailAsync(request.Email) is not null) 
            {
                throw new UserEmailAlreadyExistsException(request.Email);
            }

            var passwordHashed = _passwordHasher.GeneratePasswordHash(request.Password);

            var user = new User(request.Name, request.Email, passwordHashed);
            var token = _jwtTokenGenerator.GenerateToken(user.Id);

            await _repositoryManager.User.AddAsync(user);
            await _repositoryManager.CommitAsync();

            var firstAndLastName = user.SeparateName();

            var authenticationResult = new AuthenticationResult(
                user.Id,
                firstAndLastName[0],
                firstAndLastName[1],
                user.Email,
                token);

            return new CommandResult<AuthenticationResult>(authenticationResult);
        }
    }
}
