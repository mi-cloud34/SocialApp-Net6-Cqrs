


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserImageRepository : EfRepositoryBase<UserImage, BaseDbContext>, IUserImageRepository
{
    public UserImageRepository(BaseDbContext context) : base(context)
    {
    }
}