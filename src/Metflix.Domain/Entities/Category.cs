using Metflix.Domain.Abstractions;

namespace Metflix.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category()
        { }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
