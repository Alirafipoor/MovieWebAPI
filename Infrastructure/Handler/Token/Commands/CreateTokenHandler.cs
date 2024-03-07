using Application.Dto.ResultDto;
using Application.Dto.Token;
using Application.Features.Commands.Token.CreateTokenFeature;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Bugeto.Models.Helpers;

namespace Infrastructure.Handler.Token.Commands
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenRequest, ResultDto<CreateTokenDto>>
    {
        private readonly IConfiguration _config;

        public CreateTokenHandler(IConfiguration config)
        {
            _config = config;
        }

       

        async Task<ResultDto<CreateTokenDto>> IRequestHandler<CreateTokenRequest, ResultDto<CreateTokenDto>>.Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Claims = new List<Claim>()
                {
                    new Claim("UserId",request.User.Id.ToString()),
                    new Claim("PhoneNumber",request.User.PhoneNumber)
                };

                var key = _config["JwtToken:Key"];
                var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var Credentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
                var TokenExp = DateTime.Now.AddDays(1);


                var token = new JwtSecurityToken(issuer: _config["JwtToken:issuer"],
                    audience: _config["JwtToken:audience"],
                    expires: DateTime.Now.AddDays(1),
                    notBefore: DateTime.Now,
                    claims: Claims,
                    signingCredentials: Credentials);

                var JwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                

                CreateTokenDto createTokenDto= new CreateTokenDto
                {
                    Exp = TokenExp,
                    Token = JwtToken
                };

                return await Task.FromResult(new ResultDto<CreateTokenDto>(createTokenDto, true, "Ok"));
            }
            catch (Exception ex)
            {
                return new ResultDto<CreateTokenDto>(null, false, "Errro");
            }
        }
    }
}
