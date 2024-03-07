using Application.Dto.Movie;
using Application.Dto.ResultDto;
using Application.Features.Commands.Movie.AddMovieFeature;
using Application.Features.Commands.Movie.DeleteMovieFeature;
using Application.Features.Commands.Movie.PutMovieFeature;
using Application.Features.Queries.Movie.CallMovieApiFeature;
using Application.Features.Queries.Movie.GetAllMovieFeature;
using Application.Features.Queries.Movie.GetMovieByIdFeature;
using Application.Features.Queries.Movie.GetRecommandFeature;
using Domain.Entitties.MovieEnttiy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.Controllers;
using Movie.Model.MoqData;
using Newtonsoft.Json.Linq;

namespace MovieWebAPITest
{
    public class MovieControllerTest
    {
        
        [Fact]
        public async void Movie_Get_Test()
        {
            //Arrange
            var Mock=new Mock<IMediator>();

            Mock.Setup(p => p.Send(It.IsAny<GetAllMovieRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(await moqData.GetAllMovie());

            MovieController movieController =new MovieController(Mock.Object);

            //Act
            var Response =await movieController.Get();

            //Assert
            Assert.IsType<OkObjectResult>(Response);

            var okObjectResult = Response as OkObjectResult;

            Assert.NotNull(okObjectResult.Value);

            Assert.IsAssignableFrom<ResultDto<List<GetAllMovieDto>>>(okObjectResult.Value);
        }
        [Theory]
        [InlineData("Avengers")]
        public async void MovieGetByTitleTest(string title)
        {
            //Arrange
            var Mock = new Mock<IMediator>();

            var Data = moqData.GetJtokenSample();

            Mock.Setup(p => p.Send(It.IsAny<CallMovieApiRequest>(), default))
                .ReturnsAsync(await Task.FromResult(new ResultDto<JToken>(Data,true,"Ok")));

            MovieController movieController = new MovieController(Mock.Object);

            //Act

            var Result = await movieController.GetByTitle(title);


            //Assert
            Assert.IsType<OkObjectResult>(Result);

            var OkResult = Result as OkObjectResult;

            Assert.NotNull(OkResult);
            Assert.IsAssignableFrom<MovieIMDB>(OkResult.Value);
        }
        [Theory]
        [InlineData(1,-1)]
        public async void Movie_Get_By_Id_Test(int ValidId,int InvalidId )
        {
            var Mock = new Mock<IMediator>();
            

            Mock.Setup(p => p.Send(It.IsAny<GetMovieByIdRequest>(), default)).ReturnsAsync(await moqData.GetMovieById(ValidId));

            MovieController movieController = new MovieController(Mock.Object);

            //Act 
            var Result = await movieController.GetById(ValidId);

            //Assert
            Assert.IsType<OkObjectResult>(Result);

            var OkResult = Result as OkObjectResult;

            Assert.NotNull(OkResult.Value);

            Assert.IsAssignableFrom<GetMovieByIdDto>(OkResult.Value);


            //Invalidid
            
            Mock.Setup(p => p.Send(It.IsAny<GetMovieByIdRequest>(),default)).ReturnsAsync(await moqData.GetMovieById(InvalidId));

           
            //Act
            var InvalidResult = await movieController.GetById(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(InvalidResult);
            
        }
        [Fact]
        public async void Add_Movie_Test()
        {
            var Mock=new Mock<IMediator>();

            var Model=moqData.AddMovieDataSample();
            Mock.Setup(p => p.Send(It.IsAny<AddMovieRequest>(), default)).ReturnsAsync(await Task.FromResult(new ResultDto<int>(2,true,"Ok")));

            MovieController movieController =new MovieController(Mock.Object);

            //Act
            var Result =await movieController.Post(Model);
            
            Assert.IsType<CreatedAtActionResult>(Result);

            var CreatedResult = Result as CreatedAtActionResult;

            Assert.NotNull(CreatedResult.ActionName);
            Assert.Null(CreatedResult.ControllerName);
            Assert.Equal("Get", CreatedResult.ActionName);

        }
        [Fact]
        public async void Put_Movie_Test()
        {
            var Mock=new Mock<IMediator>();

            var Model = moqData.PutMovieDtoSample();

            Mock.Setup(p => p.Send(It.IsAny<PutMovieRequest>(), default)).ReturnsAsync(await Task.FromResult(new ResultDto<int>(Model.Id, true, "Ok")));

            MovieController movieController=new MovieController(Mock.Object);

            //Act
            var Result=await movieController.Put(Model);

            //Assert

            Assert.IsType<OkObjectResult>(Result);

            var OkResult = Result as OkObjectResult;

            Assert.NotNull(OkResult);

            Assert.IsAssignableFrom<int>(OkResult.Value);

        }
        [Theory]
        [InlineData(1,-1)]
        public async void Delete_MovieTest(int Valid,int Invalid)
        {
            var Mock=new Mock<IMediator>();

            Mock.Setup(p => p.Send(It.IsAny<DeleteMovieRequest>(), default)).ReturnsAsync(await Task.FromResult(new ResultDto(true, "Ok")));

            MovieController movieController = new MovieController(Mock.Object);

            //Act

            var Result= await movieController.Delete(Valid);

            //Assert

            Assert.IsType<OkResult>(Result);

            var OkResult=Result as OkResult;

            Assert.NotNull(OkResult);


            //Invalid

            Mock.Setup(p => p.Send(It.IsAny<DeleteMovieRequest>(), default)).ReturnsAsync(await Task.FromResult(new ResultDto(false, "Not Found Movie")));

            //Act

            var InvalidResult = await movieController.Delete(Invalid);


            //Assert
            Assert.IsType<NotFoundResult>(InvalidResult);


        }
        //[Fact]
        //public async void User_Recomand_Test()
        //{
        //    var Mock= new Mock<IMediator>();
        //    var Data = await moqData.GetAllMovie();
        //    Mock.Setup(p => p.Send(It.IsAny<GetRecommandRequest>(), default))
        //        .ReturnsAsync(await Task.FromResult(new ResultDto<List<GetAllMovieDto>>(Data.Data , true, "Ok")));
            
        //    MovieController movieController = new MovieController(Mock.Object);

        //    //Act
        //    var Result = await movieController.UserRecommand();

        //    Assert.IsType<OkObjectResult>(Result);

        //    Assert.NotNull(Result);

        //    var OkResult=Result as OkObjectResult;

        //    Assert.NotNull(OkResult);

        //    Assert.IsAssignableFrom<ResultDto<List<GetAllMovieDto>>>(OkResult);


        //}
        
    }
}
