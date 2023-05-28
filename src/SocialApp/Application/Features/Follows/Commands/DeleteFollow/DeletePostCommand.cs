
using Application.Features.Follows.Dtos;
using Application.Features.Posts.Dtos;
using Application.Features.Users.Constants;
using Application.Features.Users.Dtos;
using Application.Features.Users.Dtos.EventUserBus;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

public class DeleteFollowCommand : IRequest<DeletedFollowDto>
{
    public User Id { get; set; }



    public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, DeletedFollowDto>
    {
        private readonly IFollowRepository _FollowRepository;
        private readonly IMapper _mapper;
      
        public DeleteFollowCommandHandler(IFollowRepository FollowRepository, IMapper mapper)
                                       
        {
            _FollowRepository = FollowRepository;
            _mapper = mapper;
           
        }

        public async Task<DeletedFollowDto> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
         
            Follow mappedFollow = _mapper.Map<Follow>(request);
            Follow deletedFollow = await _FollowRepository.UnfollowAsync(mappedFollow);
            DeletedFollowDto deletedFollowDto = _mapper.Map<DeletedFollowDto>(deletedFollow);
            return deletedFollowDto;
        }
    }
}