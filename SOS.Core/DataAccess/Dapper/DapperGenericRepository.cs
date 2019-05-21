using DapperExtensions;
using SOS.Core.Entities;
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
        protected IDbTransaction _transaction { get; private set; }
        protected IDbConnection _connection => _transaction.Connection;

        public DapperGenericRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public List<T> GetList()
        {
            return _connection.GetList<T>(transaction: _transaction).ToList();
        }

        public List<T> GetList(IList<ISort> sort)
        {
            return _connection.GetList<T>(transaction: _transaction, sort: sort).ToList();
        }

        public List<T> GetList(Expression<Func<T, object>> filter, Operator op, object value, IList<ISort> sort = null)
        {
            var predicate = Predicates.Field(filter, op, value);
            return _connection.GetList<T>(predicate, transaction: _transaction, sort: sort).ToList();
        }

        public T Get(int id)
        {
            return _connection.Get<T>(id, transaction: _transaction);
        }

        public int Add(T entity)
        {
            return _connection.Insert(entity, transaction: _transaction);
        }

        public bool Update(T entity)
        {
            return _connection.Update(entity, transaction: _transaction);
        }

        public bool Delete(T entity)
        {
            return _connection.Delete(entity, transaction: _transaction);
        }

        public bool Delete(Expression<Func<T, object>> filter, Operator op, object value)
        {
            var predicate = Predicates.Field(filter, op, value);
            return _connection.Delete(predicate, transaction: _transaction);
        }
    }
}
