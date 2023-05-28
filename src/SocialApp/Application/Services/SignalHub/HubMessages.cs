using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SignalHub
{
    public  class HubMessages:Hub
    {
        private readonly IMessageRepository _messageRepository;
        public HubMessages(IMessageRepository messageRepository)
        {
                    _messageRepository= messageRepository;
        }
        public async Task SendMessage( string  user,Message message)
        {
             message = new()
             {
                 UserId = new BaseUserId().getIdFromRequest(),
                 MessageText = message.MessageText
             };
            
                _messageRepository.AddAsync(message);

            
         await Clients.User(user).SendAsync("ReceiveMessage", message);
          
            // await Clients.User(Context.UserIdentifier).SendAsync("sendMessage",message);
        }
    }

}
