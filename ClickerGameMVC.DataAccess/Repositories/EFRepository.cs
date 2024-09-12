using ClickerGameMVC.Data;
using ClickerGameMVC.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.DataAccess.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        ApplicationDbContext dbContext;
        DbSet<T> dbSet;

        public EFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public T Delete(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public DbSet<T> GetDbSet()
        {
            return dbSet;
        }

        public IQueryable<T> GetQuareyble()
        {
            return dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return dbSet.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Update(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public bool Contains(int id)
        {
            return dbSet.Any(e => e.Id == id);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}