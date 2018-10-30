using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.MultiTenancy;

namespace Colegio.EntityFrameworkCore
{
    public class ColegioDbContext : AbpZeroDbContext<Tenant, Role, User, ColegioDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
