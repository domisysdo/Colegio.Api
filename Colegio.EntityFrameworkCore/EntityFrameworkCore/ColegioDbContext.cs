using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Models.EstudianteNs;
using Colegio.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Colegio.EntityFrameworkCore
{
    public class ColegioDbContext : AbpZeroDbContext<Tenant, Role, User, ColegioDbContext>
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
