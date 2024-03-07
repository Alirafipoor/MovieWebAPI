using Domain.BaseEntity;
using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.GenreEntity;
using Domain.Entitties.ReviewsEntity;
using Domain.Entitties.UserRatingEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitties.MovieEnttiy
{
    public  class MyMovie:Base
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

       
        public UserRating UserRating { get; set; }
        public int? UserRatingId { get; set; }

       
        public Review Review { get; set; }
        public int? ReviewId { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Director> Directors { get; set; }
       
    }
}
