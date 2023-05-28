using Application.Features.Messages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Queries.GetByIdMessage;

public class GetByIdMessageQuery : IRequest<MessageDto>
{
    public int Id { get; set; }

    public class GetByIdMessageQueryHandler : IRequestHandler<GetByIdMessageQuery, MessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
       
        public GetByIdMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper
                                      )
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
           
        }


        public async Task<MessageDto> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
        {
          
            Message? Message = await _messageRepository.GetAsync(b => b.Id == request.Id);
            MessageDto MessageDto = _mapper.Map<MessageDto>(Message);
            return MessageDto;
        }
    }
}