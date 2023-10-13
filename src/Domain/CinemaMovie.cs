namespace Domain
{
    public class CinemaMovie : Common.BaseDomainEntity
    {
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}