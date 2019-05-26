using SOS.Core.Uow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Dal
{
    public sealed class DalSession : IDalSession
    {
        IDbConnection _connection = null;
        IUnitOfWork _unitOfWork = null;

        public DalSession()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //_connection = new OleDbConnection(DalCommon.ConnectionString);
            _connection = new SqlConnection(conStr);
            _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }


        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}
