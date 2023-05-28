using Application.Features.Messages.Dtos;
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

public class DeleteMessageCommand : IRequest<DeletedMessageDto>
{
    public int Id { get; set; }



    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, DeletedMessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public DeleteMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)

        {
            _messageRepository = messageRepository;
            _mapper = mapper;

        }

        public async Task<DeletedMessageDto> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {

            Message mappedMessage = _mapper.Map<Message>(request);
            Message deletedMessage = await _messageRepository.DeleteAsync(mappedMessage);
            DeletedMessageDto deletedMessageDto = _mapper.Map<DeletedMessageDto>(deletedMessage);
            return deletedMessageDto;
        }
    }
}