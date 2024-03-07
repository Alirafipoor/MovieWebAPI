using Application.Dto.ResultDto;
using Application.Features.Commands.Account.GetCodeFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebAPITest
{

    public class AccountControllerTest
    {
        [Theory]
        [InlineData("09025208307")]
        public async void Get_Code_Test(string Valid)
        {
            var Mock=new Mock<IMediator>();

            Mock.Setup(p => p.Send(It.IsAny<GetCodeRequest>(), default))
                .ReturnsAsync(await Task.FromResult(new ResultDto<string>("1222", true, "Ok")));

            AccountController accountController  = new AccountController(Mock.Object);

            //Act
            var Result=await accountController.GetCode(Valid);

            //Assert
            Assert.IsType<OkObjectResult>(Result);

            var OkResult = Result as OkObjectResult;

            Assert.NotNull(OkResult.Value);

            Assert.IsAssignableFrom<ResultDto<string>>(OkResult.Value);


           
        }
    }
}
