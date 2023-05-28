


using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ConservationRepository : EfRepositoryBase<Conservation, BaseDbContext>, IConservationRepository
{
    public ConservationRepository(BaseDbContext context) : base(context)
    {
    }
}