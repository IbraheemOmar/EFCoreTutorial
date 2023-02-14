using EFCoreTutorial.Context;
using EFCoreTutorial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.Repositories
{
    public abstract class Repository<TEntity> :IRepository<TEntity> where TEntity : class //the song &artist repo are inheriting the properties and methods of repo.
    {
        protected readonly MusicContext context;
        public Repository(MusicContext dbContext)
        {
            context = dbContext;
        }

        //cast casting the MusicContext to the DBContext
        protected DbContext Context { get { return context; } }

        public virtual async Task<TEntity> AddAsync(TEntity entity)  //
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync() //task is wrapping this (to use another thread)method in another task class and
                                                               //running this method returning what ever is in the tasks brackets
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            TEntity? entity = await Context.Set<TEntity>() //creates two record one for modifying and one for tracking modifications
                                     .Where(w => EF.Property<int>(w, "Id") == id)
                                     .FirstOrDefaultAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity) //this is the entity record being changed;
        {
            await Context.Set<TEntity>().AddAsync(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Modified; //telling the database that this is not a new entity, this entity has just been modified
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual void DeleteAll()
        {

        }
    }
}
