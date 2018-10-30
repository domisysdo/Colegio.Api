using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Colegio.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class ColegioRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ColegioDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ColegioRepositoryBase(IDbContextProvider<ColegioDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="ColegioRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ColegioRepositoryBase<TEntity> : ColegioRepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected ColegioRepositoryBase(IDbContextProvider<ColegioDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
