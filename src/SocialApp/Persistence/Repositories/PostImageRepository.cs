


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostImageRepository : EfRepositoryBase<PostImage, BaseDbContext>, IPostImageRepository
{
    public PostImageRepository(BaseDbContext context) : base(context)
    {
    }
}