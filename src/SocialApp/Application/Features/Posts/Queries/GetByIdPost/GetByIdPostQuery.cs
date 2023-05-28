using Application.Features.Posts.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Queries.GetByIdPost;

public class GetByIdPostQuery : IRequest<PostDto>
{
    public int Id { get; set; }

    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQuery, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
       
        public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper
                                      )
        {
            _postRepository = postRepository;
            _mapper = mapper;
           
        }


        public async Task<PostDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
        {
          
            Post? post = await _postRepository.GetAsync(b => b.Id == request.Id);
            PostDto postDto = _mapper.Map<PostDto>(post);
            return postDto;
        }
    }
}