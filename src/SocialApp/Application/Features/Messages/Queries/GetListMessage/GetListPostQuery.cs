using Application.Features.Messages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Queries.GetListMessage;

public class GetListMessageQuery : IRequest<MessageListModel>
{

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, MessageListModel>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageListModel> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            List<Message?> Messages = (List<Message?>)await _messageRepository.GetAllAsync();
            MessageListModel mappedMessageListModel = _mapper.Map<MessageListModel>(Messages);
            return mappedMessageListModel;
        }
    }
}