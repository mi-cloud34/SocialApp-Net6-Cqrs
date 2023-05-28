using Application.Features.Conservations.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Conservations.Commands.CreateConservation
{
    public class CreateConservationCommand : IRequest<CreatedConservationDto>
    {
        public User senderId { get; set; }
        public User  receiveId { get; set; }
        public class CreateConservationCommandHandler : IRequestHandler<CreateConservationCommand, CreatedConservationDto>
        {
            IConservationRepository _conservationRepository;
            private readonly IMapper _mapper;
            private readonly DbContext _baseDbContext;

            public CreateConservationCommandHandler(IConservationRepository conservationRepository, IMapper mapper,DbContext dbContext)
            {
                _conservationRepository = conservationRepository;
                _mapper = mapper;
                _baseDbContext = dbContext;

            }

            public async Task<CreatedConservationDto> Handle(CreateConservationCommand request, CancellationToken cancellationToken)
            {
                Conservation mappedConservation = _mapper.Map<Conservation>(request);

                 mappedConservation = new()
                {
                   Members = new List<User>() { request.senderId, request.receiveId }
                };
                _baseDbContext.AddAsync<Conservation>(mappedConservation);
                //Conservation createConservation = //await _conservationRepository.AddAsync(mappedConservation);
                CreatedConservationDto createdConservationDto = _mapper.Map<CreatedConservationDto>(mappedConservation);
                return createdConservationDto;

            }
        }
    }
}
