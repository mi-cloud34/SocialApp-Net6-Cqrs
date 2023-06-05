using Application.Features.Posts.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest<UpdatePostDto>
{
    public int Id { get; set; }
    public string Name { get; set; }


    public int? UserId { get; set; }

    public string PostText { get; set; }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
       
        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper
                                        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
           
        }

        public async Task<UpdatePostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
           
            Post mappedPost = _mapper.Map<Post>(request);
            Post updatedPost = await _postRepository.UpdateAsync(mappedPost);
            UpdatePostDto updatedPostDto = _mapper.Map<UpdatePostDto>(updatedPost);
            return updatedPostDto;
        }
    }
}