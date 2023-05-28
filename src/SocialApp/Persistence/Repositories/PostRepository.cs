


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostRepository : EfRepositoryBase<Post, BaseDbContext>, IPostRepository
{
    public PostRepository(BaseDbContext context) : base(context)
    {
    }
}