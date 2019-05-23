﻿using SOS.DataAccess.DapperDal.EventDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IEventService _eventService;
        private bool _disposed;

        public UnitOfWork()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IEventService EventService
        {
            get { return _eventService ?? (_eventService = new EventService(_transaction)); }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _eventService = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}