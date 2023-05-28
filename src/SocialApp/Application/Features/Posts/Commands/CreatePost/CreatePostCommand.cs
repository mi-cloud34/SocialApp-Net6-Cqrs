using Application.Features.Posts.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.FileStorage;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand:IRequest<CreatedPostDto>
    {
        public IFormCollection? Files { get; set; }
        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostDto>
        {
            IPostRepository _postRepository;
            private readonly IMapper _mapper;
            private readonly IStorageService _storageServices;
            public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper, IStorageService storageServices)
            {
                _postRepository = postRepository;
                _mapper = mapper;
                _storageServices = storageServices;
            }

            public async Task<CreatedPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                Post mappedPost=_mapper.Map<Post>(request);
                List<( string fileName, string pathOrContainerName)> result = 
                 await _storageServices.UploadsAsync("post-images", (IFormFileCollection)request.Files);
              //  FileShare=== public IFormCollection? Files { get; set; }
            mappedPost.PostImages = new List<PostImage>()
                {
                   new PostImage(){

                       Name = result[0].fileName,
                       Path = result[0].pathOrContainerName,
                       Storage = _storageServices.StorageName,
                   }
                };
                Post createPost =await _postRepository.AddAsync(mappedPost);
                CreatedPostDto createdPostDto=_mapper.Map<CreatedPostDto>(mappedPost);
                return createdPostDto;    
                
            }
        }
    }
}
