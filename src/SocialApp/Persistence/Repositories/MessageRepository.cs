


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MessageRepository : EfRepositoryBase<Message, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext context) : base(context)
    {
    }
}