namespace Application.Dto.Movie
{
    public class PutMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int? UserRatingId { get; set; }
        public int? ReviewId { get; set; }

        
    }
}
