

using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserImageRepository : IAsyncRepository<UserImage>, IRepository<UserImage>
{
}