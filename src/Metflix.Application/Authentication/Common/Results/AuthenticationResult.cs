namespace Metflix.Application.Authentication.Common.Results
{
    public class AuthenticationResult
    {
        public UserResult User { get; set; }
        public string Token { get; set; }

        public AuthenticationResult(
            Guid id, 
            string firstName, 
            string lastName, 
            string email, 
            string token)
        {
            var user = new UserResult
            { 
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
            };

            User = user;
            Token = token;
        }
    }

    public class UserResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
