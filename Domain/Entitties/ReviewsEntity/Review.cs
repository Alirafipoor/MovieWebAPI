using Domain.BaseEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Entitties.UserEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitties.ReviewsEntity
{
    public class Review:Base
    {
        public int ReviewsCount { get; set; }
        public ICollection<User> UserReviews { get; set; }

       

    }
}
