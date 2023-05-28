

using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IPostImageRepository : IAsyncRepository<PostImage>, IRepository<PostImage>
{
}