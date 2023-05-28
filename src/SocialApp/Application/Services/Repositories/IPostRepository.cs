

using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IPostRepository : IAsyncRepository<Post>, IRepository<Post>
{
}