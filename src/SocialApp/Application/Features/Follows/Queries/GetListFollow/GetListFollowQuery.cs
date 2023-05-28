
using Application.Features.Follows.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Queries.GetListFollow;

public class GetListFollowQuery : IRequest<FollowListModel>
{

    public class GetListFollowQueryHandler : IRequestHandler<GetListFollowQuery, FollowListModel>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public GetListFollowQueryHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<FollowListModel> Handle(GetListFollowQuery request, CancellationToken cancellationToken)
        {
            List<Follow?> follows = (List<Follow?>)await _followRepository.GetAllAsync();
            FollowListModel mappedFollowListModel = _mapper.Map<FollowListModel>(follows);
            return mappedFollowListModel;
        }
    }
}