using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.GenreEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Entitties.ReviewsEntity;
using Domain.Entitties.UserEntity;
using Domain.Entitties.UserRatingEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IDatabaseContext
    {

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MyMovie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SmsCode> SmsCodes { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        
    }
}
