using DapperExtensions;
using SOS.Core.Entities;
using SOS.Core.Uow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.DataAccess.Dapper
{
    public class DapperGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        protected IUnitOfWork _uow;

        public DapperGenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<T> GetList()
        {
            return _uow.Connection.GetList<T>(transaction: _uow.Transaction).ToList();
        }

        public List<T> GetList(IList<ISort> sort)
        {
            return _uow.Connection.GetList<T>(transaction: _uow.Transaction, sort: sort).ToList();
        }

        public List<T> GetList(Expression<Func<T, object>> filter, Operator op, object value, IList<ISort> sort = null)
        {
            var predicate = Predicates.Field(filter, op, value);
            return _uow.Connection.GetList<T>(predicate, transaction: _uow.Transaction, sort: sort).ToList();
        }

        public T Get(int id)
        {
            return _uow.Connection.Get<T>(id, transaction: _uow.Transaction);
        }

        public int Add(T entity)
        {
            return _uow.Connection.Insert(entity, transaction: _uow.Transaction);
        }

        public bool Update(T entity)
        {
            return _uow.Connection.Update(entity, transaction: _uow.Transaction);
        }

        public bool Delete(T entity)
        {
            return _uow.Connection.Delete(entity, transaction: _uow.Transaction);
        }

        public bool Delete(Expression<Func<T, object>> filter, Operator op, object value)
        {
            var predicate = Predicates.Field(filter, op, value);
            return _uow.Connection.Delete(predicate, transaction: _uow.Transaction);
        }
    }
}
