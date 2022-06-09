using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace TheModels.Repository
{
    public interface IRepository<T> :IRepositoryNet<T>  where T : class
    {

        void Add(T entity);

        Task AddAsync(T entity);

        void Add (IEnumerable<T> entities);

        Task AddAsync(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entity);

        void Delete(int id);

        void Delete(Expression<Func<T,bool>> exception);

        Task DeleteAsync(T entity);

        Task DeleteAsync(IEnumerable<T> entity);

        Task DeleteAsync(int id);

        Task DeleteAsync(Expression<Func<T, bool>> exception);

        void Update(T entity);

        void Update(IEnumerable<T> entitys);

        void Update(Action<T> action , Expression<Func<T, bool>> exception);

        Task UpdateAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        IIncludableQueryable<T, Tproprty> Include<Tproprty>(Expression<Func<T, Tproprty>> expression);

        T Find(int? id);

        T Find(Expression<Func<T, bool>> expression);

        Task<T> FindAsync(Expression<Func<T, bool>> expression);

        Task<T> FindAsync(int? id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsycn();

        IQueryable<T> Get(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);

        IEnumerable<T> Take(int count);

        IQueryable<T> Take(Expression<Func<T, bool>> expression);


        T FindNoTracking(Expression<Func<T, bool>> expression);

        Task<T> FindAsyncNoTracking(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetAllNoTracking();

        Task<IEnumerable<T>> GetAllAsycnNoTracking();

        IQueryable<T> GetNoTracking(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAsyncNoTracking(Expression<Func<T, bool>> expression);

        bool Any();

        bool Any(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
