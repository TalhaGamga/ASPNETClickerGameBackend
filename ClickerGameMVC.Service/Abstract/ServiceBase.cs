using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.Service.Abstract
{
    public class ServiceBase<T> : IService<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public T Delete(int id)
        {
            var entity = GetById(id);
            return _repository.Delete(entity);
        }

        public DbSet<T> GetAll()
        {
            return _repository.GetDbSet();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public bool Contains(int id)
        {
            return _repository.Contains(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _repository.GetQuareyble();
        }
    }
}