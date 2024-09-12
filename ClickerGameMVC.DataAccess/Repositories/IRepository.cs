using ClickerGameMVC.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        public T GetById(int id);
        DbSet<T> GetDbSet();
        void Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        void SaveChanges();
        bool Contains(int id);
        IQueryable<T> GetQuareyble();
    }
}