using Application.Features.Follows.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.FileStorage;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Follows.Commands.CreateFollow
{
    public class CreateFollowCommand : IRequest<CreatedFollowDto>
    {
        public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, CreatedFollowDto>
        {
            IFollowRepository _followRepository;
            private readonly IMapper _mapper;
          
            public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper, IStorageService storageServices)
            {
                _followRepository = followRepository;
                _mapper = mapper;
               
            }

            public async Task<CreatedFollowDto> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
            {
                Follow mappedFollow = _mapper.Map<Follow>(request);
               
                Follow createFollow = await _followRepository.FollowAsync(mappedFollow);
                CreatedFollowDto createdFollowDto = _mapper.Map<CreatedFollowDto>(mappedFollow);
                return createdFollowDto;

            }
        }
    }
}
