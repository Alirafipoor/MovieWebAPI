using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Movie
{
    public class GetMovieByIdDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
        public int? Review { get; set; }
        public double? UserRate { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Directors { get; set; }
        
    }
}
