using Application.Features.Conservations.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Conservations.Queries.GetListConservation;

public class GetListConservationQuery : IRequest<ConservationListModel>
{

    public class GetListConservationQueryHandler : IRequestHandler<GetListConservationQuery, ConservationListModel>
    {
        private readonly IConservationRepository _conservationRepository;
        private readonly IMapper _mapper;

        public GetListConservationQueryHandler(IConservationRepository conservationRepository, IMapper mapper)
        {
            _conservationRepository = conservationRepository;
            _mapper = mapper;
        }

        public async Task<ConservationListModel> Handle(GetListConservationQuery request, CancellationToken cancellationToken)
        {
            List<Conservation?> conservations = (List<Conservation?>)await _conservationRepository.GetAllAsync();
            ConservationListModel mappedConservationListModel = _mapper.Map<ConservationListModel>(conservations);
            return mappedConservationListModel;
        }
    }
}