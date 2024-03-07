using Application.Dto.Movie;
using Application.Features.Commands.Movie.AddMovieFeature;
using Application.Features.Commands.Movie.DeleteMovieFeature;
using Application.Features.Commands.Movie.PutMovieFeature;
using Application.Features.Queries.Movie.CallMovieApiFeature;
using Application.Features.Queries.Movie.GetAllMovieFeature;
using Application.Features.Queries.Movie.GetMovieByIdFeature;
using Application.Features.Queries.Movie.GetRecommandFeature;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Result = await mediator.Send(new GetAllMovieRequest());
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("Movie{Title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            try
            {
                var result = await mediator.Send(new CallMovieApiRequest
                {
                    Title = title
                });

                if (result.IsSuccess && result.Data !=null)
                {
                    MovieIMDB movies = new MovieIMDB(result.Data);
                    return Ok(movies);
                }


                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Result =await mediator.Send(new GetMovieByIdRequest()
                {
                    Id = id
                });

                //var userId = GetUserId();

                //if(userId != 0)
                //{
                //    var RecommandResult = await mediator.Send(new AddReCommandRequest { Id = userId, GenreId = Result.Data.GenreId });
                //}
                

                if (Result.IsSuccess)
                {
                    return Ok(Result.Data);
                }
                    

                return NotFound();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMovieDto Model)
        {
            try
            {
                var result = await mediator.Send(new AddMovieRequest
                {
                    AddMovieDto = Model
                });

                if (result.IsSuccess)
                    return CreatedAtAction("Get", new {id=result.Data});

                return BadRequest();
            }
           catch(Exception e)
            {
                return BadRequest();
            }


        }

        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutMovieDto Model)
        {
            try
            {
                var result = await mediator.Send(new PutMovieRequest
                {
                    PutMovieDto = Model
                });

                if (result.IsSuccess)
                    return Ok(result.Data);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            

        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resut=await mediator.Send(new DeleteMovieRequest { Id = id });

                if (resut.IsSuccess)
                    return Ok();

                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("UserRecommand")]
        public async Task<IActionResult> UserRecommand()
        {
            try
            {
                var UserId = GetUserId();
                if(UserId != 0)
                {
                    var result=await mediator.Send(new GetRecommandRequest { UserId = UserId });

                    if (result.IsSuccess)
                    {
                        return Ok(result.Data);
                    }
                        

                    return NotFound();
                }
                return NotFound();
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
        }
    }
}
