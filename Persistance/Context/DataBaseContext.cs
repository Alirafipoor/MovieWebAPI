using Application.Context;
using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.GenreEntity;
using Domain.Entitties.MovieEnttiy;
using Domain.Entitties.ReviewsEntity;
using Domain.Entitties.UserEntity;
using Domain.Entitties.UserRatingEntity;
using Infrastructure.Entitconfiguration;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class DataBaseContext : DbContext, IDatabaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MyMovie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SmsCode> SmsCodes { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new MyMovieConfiguration());


            base.OnModelCreating(modelBuilder);
        }


    }
}
