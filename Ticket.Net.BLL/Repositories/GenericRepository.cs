using Ticket.Net.DAL.Models;
using Ticket.Net.BLL.Services.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ticket.Net.BLL.Repositories {


    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        
        internal TicketNetContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository()
        {
            this._context = new TicketNetContext();
            this._dbSet = _context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            entity.AddDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.IsDeleted = false;
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return entity;
            entity.IsDeleted = true;
            entity.UpdateDate = DateTime.Now;
            _context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
             
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
           var entity = _dbSet.Where(q => q.IsDeleted == false).FirstOrDefault(expression);
            return entity;
        }

        public List<T> GetAll()
        {
            var entities = _dbSet.Where(q => q.IsDeleted == false).ToList();
            return entities;
        }

        public IQueryable<T> GetAllWithExternalQuery(Expression<Func<T, bool>> filter)
        {
            var entities = _dbSet.Where(q => q.IsDeleted == false).Where(filter);
            return entities;
        }

        public IQueryable<T> GetAllWithQueryable()
        {
           var entities = _dbSet.Where(q => q.IsDeleted == false);
           return entities;
        }

        public T GetById(int id)
        {
            var entity = _dbSet.Where(q=> q.IsDeleted == false).FirstOrDefault(q=> q.Id == id);
            return entity;
        }
    }




}