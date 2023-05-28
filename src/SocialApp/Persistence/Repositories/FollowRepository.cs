


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FollowRepository : EfRepositoryBase<Follow, BaseDbContext>, IFollowRepository
{
    public FollowRepository(BaseDbContext context) : base(context)
    {
    }
}