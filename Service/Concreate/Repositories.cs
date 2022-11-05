using Application.Service;
using DataAccess.Context;
using Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concreate
{
    public class Repositories<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly MvcAppContext _context;

        public Repositories(MvcAppContext context)
        {
            _context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();

        public  IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<bool> AddAsync(T model)
        {
          EntityEntry<T> entityEntry=  await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await _context.AddRangeAsync(models);
            return true;
        }

        public bool DeleteAsync(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;

        }

        public async Task<bool> DeleteByidAsync(string id)
        {
            //EntityEntry<T> entityEntry = await Table.Remove(p=>p.id);
            //return entityEntry.State == EntityState.Deleted;

            T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
           EntityEntry<T> entityEntry= Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteRangeAsync(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<T> GetById(string id)
        {
           T model= await Table.FindAsync(id);
            return model;

        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            T model = await Table.SingleOrDefaultAsync(predicate);
            return model;

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Table.Where(predicate);
            return query;

        }
        public bool update(T model)
        {
            EntityEntry<T> entityEntry= Table.Update(model);
           return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
           int count= await _context.SaveChangesAsync();
            return count;
        }
    }
}
