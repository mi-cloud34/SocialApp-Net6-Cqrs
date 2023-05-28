using Application.Features.Conservations.Dtos;
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

public class DeleteConservationCommand : IRequest<DeletedConservationDto>
{
    public int Id { get; set; }



    public class DeleteConservationCommandHandler : IRequestHandler<DeleteConservationCommand, DeletedConservationDto>
    {
        private readonly IConservationRepository _conservationRepository;
        private readonly IMapper _mapper;
      
        public DeleteConservationCommandHandler(IConservationRepository conservationRepository, IMapper mapper)
                                       
        {
            _conservationRepository = conservationRepository;
            _mapper = mapper;
           
        }

        public async Task<DeletedConservationDto> Handle(DeleteConservationCommand request, CancellationToken cancellationToken)
        {
         
            Conservation mappedConservation = _mapper.Map<Conservation>(request);
            Conservation deletedConservation = await _conservationRepository.DeleteAsync(mappedConservation);
            DeletedConservationDto deletedConservationDto = _mapper.Map<DeletedConservationDto>(deletedConservation);
            return deletedConservationDto;
        }
    }
}