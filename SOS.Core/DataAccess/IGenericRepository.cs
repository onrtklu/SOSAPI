using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using System.Linq.Expressions;

namespace SOS.Core.DataAccess
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(IList<ISort> sort);
        List<T> GetList(Expression<Func<T, object>> filter, Operator op, object value, IList<ISort> sort = null);
        List<T> GetList();
        T Get(int id);
        int Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(Expression<Func<T, object>> filter, Operator op, object value);
    }
}
