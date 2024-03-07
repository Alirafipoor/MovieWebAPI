using Domain.BaseEntity;
using Newtonsoft.Json.Linq;

namespace Domain.Entitties.MovieEnttiy
{
    public class MovieIMDB
    {

        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Released { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }

        public MovieIMDB()
        {

        }

        public MovieIMDB(JToken u)
        {
            this.Title = u["Title"].ToString();
            this.Year = int.Parse(u["Year"].ToString());
            this.Rated = u["Rated"].ToString();
            this.Genre = u["Genre"].ToString();
            this.Director = u["Director"].ToString();
            this.Poster = u["Poster"].ToString();
            this.Released = u["Released"].ToString();
            this.Country = u["Country"].ToString();
            this.Language = u["Language"].ToString();
            this.Awards = u["Awards"].ToString();
        }
    }
}
