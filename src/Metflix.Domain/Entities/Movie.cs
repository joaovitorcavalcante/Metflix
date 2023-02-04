using Metflix.Domain.Abstractions;
using Metflix.Domain.Enums;

namespace Metflix.Domain.Entities
{
    public class Movie : EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public TimeSpan Duration { get; private set; }
        public MovieRatingEnum Rating { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public Movie(string title, string description, string author, TimeSpan duration, DateTime releaseDate)
        {
            Title = title;
            Description = description;
            Author = author;
            Duration = duration;
            Rating = (double) MovieRatingEnum.None;
            ReleaseDate = releaseDate;
        }
    }
}
