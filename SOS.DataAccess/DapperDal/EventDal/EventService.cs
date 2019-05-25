using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SOS.Core.DataAccess.Dapper;
using System.Data;
using SOS.DataObjects.Entities;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.Core.Uow;

namespace SOS.DataAccess.DapperDal.EventDal
{
    public class EventService : DapperGenericRepository<Event>, IEventService
    {
        private IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Event GetEvent(int id)
        {
            var result = _unitOfWork.Connection.QuerySingleOrDefault<Event>("select * from dbo.Event where ID = @id", new { id = id }, transaction: _uow.Transaction);
            //var result = _connection.QuerySingleOrDefault<Event>("select * from dbo.Event where ID = @id",new { id = id }, transaction: _transaction);
            return result;
        }

        public List<Event> GetEventList()
        {
            var result = _unitOfWork.Connection.Query<Event>("select * from dbo.Event", transaction: _uow.Transaction).ToList();
            //var result = _connection.Query<Event>("select * from dbo.Event", transaction: _transaction).ToList();
            return result;
        }

        public List<EventDetailDto> GetEventDetailList()
        {
            return _unitOfWork.Connection.Query<EventDetailDto>(
                 "SELECT e.ID AS EventID, h.HallName, p.PlayName, e.EventDate " +
                 "FROM dbo.Event e " +
                 "LEFT JOIN dbo.Hall h ON e.HallID = h.ID " +
                 "LEFT JOIN dbo.Play p ON e.PlayID = p.ID "
                , transaction: _uow.Transaction).ToList();
        }
    }
}
