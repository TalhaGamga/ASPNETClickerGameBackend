using ClickerGameMVC.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.Service.Abstract
{
    public interface IService<T> where T : class, IEntity
    {
        T GetById(int id);
        DbSet<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        T Delete(int id);
        bool Contains(int id);
        IQueryable<T> GetQueryable();
    }
}