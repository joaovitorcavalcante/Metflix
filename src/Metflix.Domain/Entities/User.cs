using Metflix.Domain.Abstractions;

namespace Metflix.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string? Document { get; private set; }
        public string Password { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public string[] SeparateName()
        {
            var explitedName = Name.Split(" ");
            var firstName = explitedName[0];
            var lastName = "";

            if (explitedName.Length > 1) 
            {
                lastName = explitedName[explitedName.Length - 1];
            }

            return new[] { firstName, lastName };
        }
    }
}
