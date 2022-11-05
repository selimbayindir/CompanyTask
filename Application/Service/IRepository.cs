using Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IRepository<T> 
        where T : BaseEntity 
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll ();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate); //tek nesne task
        Task<T> GetById(String id);
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool DeleteAsync(T model);
        bool DeleteRangeAsync(List<T> models);
        Task<bool> DeleteByidAsync(string id);
        bool update(T model);
        Task<int> SaveAsync();

    }
}
