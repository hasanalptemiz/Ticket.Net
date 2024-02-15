using System.Linq.Expressions;
using Ticket.Net.DAL.Models;


namespace Ticket.Net.BLL.Services.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
       bool Any(Expression<System.Func<T, bool>> expression);

       T FirstOrDefault(Expression<System.Func<T, bool>> expression);

       T GetById(int id);

       T Create(T entity);

       List<T> GetAll();

       IQueryable<T> GetAllWithQueryable();

       IQueryable<T> GetAllWithExternalQuery(Expression<System.Func<T, bool>> expression);

       T Delete(int id);



    }
}
