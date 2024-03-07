using Application.Dto.ResultDto;
using Domain.Entitties.UserEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Account.AddRecommandFeature
{
    public class AddReCommandRequest:IRequest<ResultDto>
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
    }
}
