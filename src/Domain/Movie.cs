namespace Domain
{
    public class Movie : Common.BaseDomainEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<CinemaMovie> CinemaMovies { get; set; }


        public Movie()
        {
            CinemaMovies = new List<CinemaMovie>();
        }
    }
}