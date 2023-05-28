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

public class DeletePostCommand : IRequest<DeletedPostDto>
{
    public int Id { get; set; }



    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletedPostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
      
        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
                                       
        {
            _postRepository = postRepository;
            _mapper = mapper;
           
        }

        public async Task<DeletedPostDto> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
         
            Post mappedPost = _mapper.Map<Post>(request);
            Post deletedPost = await _postRepository.DeleteAsync(mappedPost);
            DeletedPostDto deletedPostDto = _mapper.Map<DeletedPostDto>(deletedPost);
            return deletedPostDto;
        }
    }
}