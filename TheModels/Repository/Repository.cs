using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheModels.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.IO;
using System.Text.Json;
using System.Net.Http.Json;


namespace TheModels.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ContextApplication data;
        private readonly HttpClient httpClient;
        public Repository(ContextApplication data)
        {
            this.data = data;
            httpClient = new HttpClient();
        }
        public void Add(T entity)
        {
            data.Set<T>().Add(entity);
            data.SaveChanges();
        }

        public void Add(IEnumerable<T> entities)
        {
            data.Set<T>().AddRange(entities);
            data.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
           await data.Set<T>().AddAsync(entity);
           await data.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<T> entities)
        {
            await data.Set<T>().AddRangeAsync(entities);
            await data.SaveChangesAsync();
        }

        public async Task AddImage<Timage>(Timage entity, byte[] FileImage, string Apiurl) where Timage :Gallery
        {
           var request =  await httpClient.PostAsJsonAsync(Apiurl, FileImage);
            if (request.IsSuccessStatusCode)
            {
                var Nameimage = await request.Content.ReadAsStringAsync();
                entity.UrlImage = Nameimage;
                await data.Set<Timage>().AddAsync(entity);
                await data.SaveChangesAsync();

            }
            
           
        }

        public async Task AddSubject(T entity)
        {
            await data.Set<T>().AddAsync(entity);
            await data.SaveChangesAsync();
        }

        public bool Any()
        {
            return data.Set<T>().Any();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().Any(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await data.Set<T>().AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            data.Set<T>().Remove(entity);
            data.SaveChanges();
        }

        public void Delete(IEnumerable<T> entity)
        {
            data.Set<T>().RemoveRange(entity);
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = data.Set<T>().Find(id);
            if(model != null)
            {
                Delete(model);
            }
        }

        public void Delete(Expression<Func<T, bool>> exception)
        {
            var models = FindNoTracking(exception);
            if (models != null)
                Delete(models);
        }

        public async Task DeleteAsync(T entity)
        {
            data.Set<T>().Remove(entity);
           await data.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var modle = await FindAsync(id);
            if (modle != null)
               await DeleteAsync(modle);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> exception)
        {
            var models = await GetAsyncNoTracking(exception);
            if(models != null)
            {
                data.Set<T>().RemoveRange(models);
                await data.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(IEnumerable<T> entity)
        {
            data.Set<T>().RemoveRange(entity);
            await data.SaveChangesAsync();
        }

        public T? Find(int? id)
        {
            return data.Set<T>().Find(id);
        }

        public T? Find(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().FirstOrDefault(expression);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await data.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> FindAsync(int? id)
        {
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<T?> FindAsyncNoTracking(Expression<Func<T, bool>> expression)
        {
            return await data.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public T? FindNoTracking(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().AsNoTracking().FirstOrDefault(expression);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return data.Set<T>().AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsycn()
        {
            return await data.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsycnNoTracking()
        {
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> GetAllNoTracking()
        {
            return  data.Set<T>().AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var models = await data.Set<T>().Where(expression).ToListAsync();
            return models.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAsyncNoTracking(Expression<Func<T, bool>> expression)
        {
            return await data.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public IQueryable<T> GetNoTracking(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().AsNoTracking().Where(expression);
        }

        public IIncludableQueryable<T, Tproprty> Include<Tproprty>(Expression<Func<T, Tproprty>> expression)
        {
            return data.Set<T>().Include(expression);
        }

        public void SaveChange()
        {
            data.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await data.SaveChangesAsync();
        }

        public IEnumerable<T> Take(int count)
        {
            return data.Set<T>().Take(count);
        }

        public IQueryable<T> Take(Expression<Func<T, bool>> expression)
        {
            return data.Set<T>().TakeWhile(expression);
        }


        public void Update(T entity)
        {
            data.Set<T>().Update(entity);
            data.SaveChanges();
        }

        public void Update(IEnumerable<T> entitys)
        {
            data.Set<T>().UpdateRange(entitys);
            data.SaveChanges();
        }

        public void Update(Action<T> action, Expression<Func<T, bool>> exception)
        {
            var Models = Get(exception);
            if(Models is not null)
            {
                foreach (var item in Models)
                {
                    action.Invoke(item);
                    SaveChange();
                }
            }
        }

        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            data.Set<T>().UpdateRange(entities);
            await data.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            data.Set<T>().Update(entity);
            await data.SaveChangesAsync();
        }

      
    }
}
