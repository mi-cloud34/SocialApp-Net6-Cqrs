using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
      
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<Conservation> Conservations { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) 
            : base(dbContextOptions)
        {
            Configuration = configuration;
        }

       
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            IEnumerable<EntityEntry<Entity>> datas = ChangeTracker
                .Entries<Entity>().Where(e =>
                    e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Post>().Ignore(x => x.Likes);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}