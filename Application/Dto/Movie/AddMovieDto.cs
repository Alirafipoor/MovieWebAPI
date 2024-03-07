using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Movie
{
    public class AddMovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<DirectorsDto> Directors { get; set; }
    }
    public class ActorDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public int Award { get; set; }
        public Gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public string Description { get; set; }
    }
    public class DirectorsDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public int Award { get; set; }
        public Gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public string Description { get; set; }
    }
}
