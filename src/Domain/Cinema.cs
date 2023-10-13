namespace Domain
{
    public class Cinema : Common.BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public ICollection<CinemaMovie> CinemaMovies { get; set; }


        public Cinema()
        {
            CinemaMovies = new List<CinemaMovie>();
        }
    }
}