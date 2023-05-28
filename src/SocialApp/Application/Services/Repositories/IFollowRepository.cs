

using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IFollowRepository : IAsyncRepository<Follow>, IRepository<Follow>
{
}