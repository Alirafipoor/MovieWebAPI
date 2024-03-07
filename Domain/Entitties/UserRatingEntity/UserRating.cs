using Domain.BaseEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Entitties.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitties.UserRatingEntity
{
    public class UserRating:Base
    {
        
        public double UserRate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

       
    }
}
