using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.DAL.Entities;

namespace Reports.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> FindById(Guid id);
        Task<IEnumerable<T>> GetAll(QueryParameters queryParameters); 
        void Remove(T entity);
        void Update(T entity);
    }
}