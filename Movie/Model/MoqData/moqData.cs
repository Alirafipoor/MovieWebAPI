using Application.Dto.Movie;
using Application.Dto.ResultDto;
using AutoMapper;
using Azure.Core;
using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.MovieEnttiy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Movie.Model.MoqData
{
    public static class moqData
    {
        public static List<MyMovie> GetData()
        {
            List<MyMovie> movies = new List<MyMovie>()
        {
            new MyMovie
            {
                Id = 1,
                Title="Avengers",
                Year=2020,
                UserRatingId=null,
                ReviewId=null,
                GenreId=3,
                Directors=new List<Director>()
                {
                    new Director()
                    {
                        Id=1,
                        Name="XXx",
                        Age=10,
                        Award=10,
                        Birthday="23",
                        Description="VVVVVV",
                        Gender=0,
                        IsMarried=false,
                        InsertTime=DateTime.Now,
                        IsRemove=false,
                    }
                },
                Actors=new List<Actor>()
                {
                    new Actor()
                    {
                        Id=1,
                        Name="HHH",
                        Age=23,
                        Award=23,
                        Birthday="ZZZ",
                        Description="LLLL",
                        Gender=0,
                        IsMarried = false,
                        InsertTime=DateTime.Now,
                        IsRemove=false,


                    },

                }
                ,
                InsertTime=DateTime.Now,
                IsRemove=false,

                Genre=new Domain.Entitties.GenreEntity.Genre
                {
                    Id=2,
                    Name="Action",
                    InsertTime= DateTime.Now,
                    IsRemove=false,

                },

             }

         };

            return movies;
        }


        public static async Task<ResultDto<List<GetAllMovieDto>>> GetAllMovie()
        {
            var data = GetData();
            var result = data.Select(p => new GetAllMovieDto
            {
                Title = p.Title,
                Year = p.Year,
                Genre = p.Genre.Name,
                UserRate = p.UserRatingId != null ? p.UserRating.UserRate : null,
                Review = p.ReviewId != null ? p.Review.ReviewsCount : null,
                Actors = p.Actors.Select(c => c.Name).ToList(),
                Directors = p.Directors.Select(p => p.Name).ToList(),
            }).ToList();

            return await Task.FromResult(new ResultDto<List<GetAllMovieDto>>(result, true, "Ok"));
        }

        
        public static JToken GetJtokenSample()
        {
            var A = "{\"Title\":\"Reign of Judges: Title of Liberty - Concept Short\",\"Year\":\"2018\",\"Rated\":\"N/A\",\"Released\":\"15 Mar 2018\",\"Runtime\":\"14 min\",\"Genre\":\"Short, Action\",\"Director\":\"Darin Scott\",\"Writer\":\"Darin Scott\",\"Actors\":\"Karina Lombard, Ben Cross, Eugene Brave Rock\",\"Plot\":\"73 BC pre-Columbian New World. A humble soldier rises unexpectedly as the protector of a young republic. Now Chief Captain of a war-weary nation, Moroni defends his country with revolutionary prowess, but his greatest struggle wil...\",\"Language\":\"English\",\"Country\":\"United States\",\"Awards\":\"N/A\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BYWM0MDI1ZmItZTYzNi00ZWVlLTg5MTctNzllNjY2ZTI3NDhhXkEyXkFqcGdeQXVyNDk5MjA2MQ@@._V1_SX300.jpg\",\"Ratings\":[{\"Source\":\"Internet Movie Database\",\"Value\":\"7.0/10\"}],\"Metascore\":\"N/A\",\"imdbRating\":\"7.0\",\"imdbVotes\":\"589\",\"imdbID\":\"tt4275958\",\"Type\":\"movie\",\"DVD\":\"N/A\",\"BoxOffice\":\"$93,224\",\"Production\":\"N/A\",\"Website\":\"N/A\",\"Response\":\"True\"}";

            var J=JToken.Parse(A);
            return (J);

        }

        public static async Task<ResultDto<GetMovieByIdDto>> GetMovieById(int id)
        {
            try
            {
                var data = GetData().Where(p => p.Id == id)
                .Select(p => new GetMovieByIdDto
                {
                    Title = p.Title,
                    Year = p.Year,
                    Genre = p.Genre.Name,
                    GenreId = p.GenreId,
                    UserRate = p.UserRatingId != null ? p.UserRating.UserRate : null,
                    Review = p.ReviewId != null ? p.Review.ReviewsCount : null,
                    Actors = p.Actors.Select(c => c.Name).ToList(),
                    Directors = p.Directors.Select(p => p.Name).ToList(),

                }).SingleOrDefault();

                return data != null ? new ResultDto<GetMovieByIdDto>(data, true, "Ok") : new ResultDto<GetMovieByIdDto>(null, false, "Error");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResultDto<GetMovieByIdDto>(null,false, ex.Message));
            }
            
        }

        public static AddMovieDto AddMovieDataSample()
        {
            AddMovieDto dto = new AddMovieDto()
            {
                Year = 2020,
                Title = "Hello",
                GenreId = 1,
                Actors = new List<ActorDto>()
                {
                    new ActorDto()
                    {
                        Age=20,
                        Award=0,
                        Birthday="202",
                        Description="Hello",
                        Gender=0,
                        IsMarried=false,
                        Name="MMM",
                    }
                },
                Directors = new List<DirectorsDto>
                {
                    new DirectorsDto
                    {
                        Age = 20,
                        Award = 0,
                        Birthday="2002",
                        Description = "Hello",
                        Gender = 0,
                        IsMarried = false,
                        Name="jjj"
                    }
                }
            };

            return dto;
        }

       
        public static PutMovieDto PutMovieDtoSample()
        {
            PutMovieDto dto = new PutMovieDto()
            {
                Id = 1,
                GenreId = 1,
                ReviewId = 3,
                Title = "Hello",
                Year = 2020,
                UserRatingId = 5

            };
            return dto;
        }
    }


}

