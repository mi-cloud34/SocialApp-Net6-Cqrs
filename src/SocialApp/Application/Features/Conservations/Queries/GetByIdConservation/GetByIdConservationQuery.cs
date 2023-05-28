using Application.Features.Conservations.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Conservations.Queries.GetByIdConservation;

public class GetByIdConservationQuery : IRequest<ConservationDto>
{
    public int Id { get; set; }

    public class GetByIdConservationQueryHandler : IRequestHandler<GetByIdConservationQuery, ConservationDto>
    {
        private readonly IConservationRepository _conservationRepository;
        private readonly IMapper _mapper;
       
        public GetByIdConservationQueryHandler(IConservationRepository conservationRepository, IMapper mapper
                                      )
        {
            _conservationRepository = conservationRepository;
            _mapper = mapper;
           
        }


        public async Task<ConservationDto> Handle(GetByIdConservationQuery request, CancellationToken cancellationToken)
        {
          
            Conservation? Conservation = await _conservationRepository.GetAsync(b => b.Id == request.Id);
            ConservationDto ConservationDto = _mapper.Map<ConservationDto>(Conservation);
            return ConservationDto;
        }
    }
}