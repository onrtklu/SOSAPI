﻿using Dommel;
using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.DataAccess.Dapper
{
    public class DapperGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected IDbTransaction _transaction { get; private set; }
        protected IDbConnection _connection
        {
            get
            {
                if(_transaction == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    return new SqlConnection(connectionString);
                }
                else
                    return _transaction.Connection;
            }
        }

        public DapperGenericRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        #region Insert
        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public object Insert(TEntity entity)
        {
            return _connection.Insert(entity, _transaction);
        }

        public Task<object> InsertAsync(TEntity entity)
        {
            return _connection.InsertAsync(entity, transaction : _transaction);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public bool Delete(TEntity entity)
        {
            return _connection.Delete(entity, transaction : _transaction);
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            return _connection.DeleteAsync(entity, transaction : _transaction);
        }


        public bool DeleteMultiple(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.DeleteMultiple(predicate, transaction : _transaction);
        }

        public Task<bool> DeleteMultipleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.DeleteMultipleAsync(predicate, transaction : _transaction);
        }
        #endregion

        #region Update

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        public bool Update(TEntity entity)
        {
            return _connection.Update(entity, transaction : _transaction);
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            return _connection.UpdateAsync(entity, transaction : _transaction);
        }
        #endregion

        #region Get

        //T Query();
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public TEntity Get(object id)
        {
            return _connection.Get<TEntity>(id);
        }

        public Task<TEntity> GetAsync(object id)
        {
            return _connection.GetAsync<TEntity>(id);
        }
        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _connection.GetAll<TEntity>();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _connection.GetAllAsync<TEntity>();
        }
        #endregion

        #region Select
        /// <summary>
        /// Selects all the entities matching the specified predicate.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.Select(predicate);
        }

        public Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.SelectAsync(predicate);
        }
        /// <summary>
        /// Selects the first entity matching the specified predicate, or a default value if no entity matched.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.FirstOrDefault<TEntity>(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _connection.FirstOrDefaultAsync<TEntity>(predicate);
        }
        #endregion

    }
}
