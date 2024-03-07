using Application.Context;
using Application.Features.Commands.Account.GetCodeFeature;
using Application.Features.Commands.Account.LoginFeature;
using Application.Features.Commands.Token.GenerateTokenAndRefreshTokenFeature;
using Application.Features.Commands.userToken.DeleteTokenFeature;
using Application.Features.Queries.userToken.FindRefreshTokenFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
       
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
            
        }

        ///<summary>
        ///Enter your PhoneNumber To Get Code
        /// </summary>
        /// <remarks>Step1</remarks>
        [HttpGet]
        [Route("GetCode")]
        public async Task<IActionResult> GetCode(string PhoneNumber)
        {
            try
            {
                var Result = await mediator.Send(new GetCodeRequest { PhoneNumber = PhoneNumber });

                if (Result.IsSuccess)
                    return Ok(Result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
             
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Post(string PhoneNumber,string code)
        {
            try
            {
                var result=await mediator.Send(new LoginRequest { PhoneNumber = PhoneNumber, Code = code });
                if (result.IsSuccess)
                {
                    var tokenResult = await mediator.Send(new GenrateTokenAndRefreshtokenRequest { User = result.Data });
                    return Ok(tokenResult);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string RefreshToken)
        {
            try
            {
                var User=await mediator.Send(new FindRefreshTokenRequest { RefreshToken = RefreshToken });
                if (User.IsSuccess)
                {
                    var Token = await mediator.Send(new GenrateTokenAndRefreshtokenRequest { User = User.Data.User });
                    await mediator.Send(new DeleteTokenRequest { RefreshToken=RefreshToken });
                    return Ok(Token);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
