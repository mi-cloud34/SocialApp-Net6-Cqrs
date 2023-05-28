

using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IMessageRepository : IAsyncRepository<Message>, IRepository<Message>
{
}