using Application.Context;
using Application.Dto.ResultDto;
using Application.Features.Commands.Movie.AddMovieFeature;
using AutoMapper;
using Domain.Entitties.MovieEnttiy;
using MediatR;

namespace Infrastructure.Handler.Movie.Commands
{
    public class AddMovieHandler : IRequestHandler<AddMovieRequest, ResultDto<int>>
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public AddMovieHandler(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<ResultDto<int>> IRequestHandler<AddMovieRequest, ResultDto<int>>.Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Model=_mapper.Map<MyMovie>(request.AddMovieDto);

                _context.Movies.Add(Model);
                _context.SaveChanges();
                return await Task.FromResult(new ResultDto<int>(Model.Id, true, "Ok"));
            }

            catch (Exception e)
            {
                return await Task.FromResult(new ResultDto<int>(0, false, e.Message));
            }

        }
    }
}
