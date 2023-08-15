using Common.Domain;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infraestructure.Persistence
{
    public class GenericDbContext : DbContext
    {
        //private readonly IIdentity _identity;

        public GenericDbContext(DbContextOptions options/*, IIdentity identity*/) : base(options)
        {
            //_identity = identity;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var userId = this._identity?.Name ?? "Test";
            var userId = "Test";
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.Entity is BaseDomain
                        && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BaseDomain entity)
                {
                    string userName = userId;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = userName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }
                    entity.UpdatedBy = userName;
                    entity.UpdatedDate = now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
