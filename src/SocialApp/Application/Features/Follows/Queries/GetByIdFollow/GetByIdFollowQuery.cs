
using Application.Features.Follows.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Queries.GetByIdFollow;

public class GetByIdFollowQuery : IRequest<FollowDto>
{
    public int Id { get; set; }

    public class GetByIdFollowQueryHandler : IRequestHandler<GetByIdFollowQuery, FollowDto>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
       
        public GetByIdFollowQueryHandler(IFollowRepository followRepository, IMapper mapper
                                      )
        {
            _followRepository = followRepository;
            _mapper = mapper;
           
        }


        public async Task<FollowDto> Handle(GetByIdFollowQuery request, CancellationToken cancellationToken)
        {
          
            Follow? follow = await _followRepository.GetAsync(b => b.Id == request.Id);
            FollowDto FollowDto = _mapper.Map<FollowDto>(follow);
            return FollowDto;
        }
    }
}