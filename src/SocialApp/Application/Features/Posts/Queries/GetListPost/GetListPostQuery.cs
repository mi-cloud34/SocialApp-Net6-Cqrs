using Application.Features.Posts.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Queries.GetListPost;

public class GetListPostQuery : IRequest<PostListModel>
{

    public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, PostListModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListModel> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            List<Post?> posts = (List<Post?>)await _postRepository.GetAllAsync();
            PostListModel mappedPostListModel = _mapper.Map<PostListModel>(posts);
            return mappedPostListModel;
        }
    }
}