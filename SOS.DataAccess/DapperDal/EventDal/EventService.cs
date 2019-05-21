using SOS.DataAccess.UOW;
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

namespace SOS.DataAccess.DapperDal.EventDal
{
    public class EventService : DapperGenericRepository<Event>, IEventService
    {
        public EventService(IDbTransaction transaction) : base(transaction){}

        public string GetEvent(int id)
        {
            var result = _connection.Query("select * from dbo.Event", transaction: _transaction);
            return "get event";
        }

        public IList<string> GetEventDetails()
        {
            return new List<string>()
            {
                "onur",
                "toklu"
            };
        }

        public List<EventDetailDto> GetEventDetailList()
        {
            return _connection.Query<EventDetailDto>(
                 "SELECT e.ID AS EventID, h.HallName, p.PlayName, e.EventDate " +
                 "FROM dbo.Event e " +
                 "LEFT JOIN dbo.Hall h ON e.HallID = h.ID " +
                 "LEFT JOIN dbo.Play p ON e.PlayID = p.ID "
                , transaction: _transaction).ToList();
        }
    }
}
