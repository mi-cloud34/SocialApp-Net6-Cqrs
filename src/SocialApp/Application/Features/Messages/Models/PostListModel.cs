using Application.Features.Users.Dtos;

namespace Application.Features.Messages.Models;

public class MessageListModel
{
    public IList<Dtos.MessageListDto> Items { get; set; }
}