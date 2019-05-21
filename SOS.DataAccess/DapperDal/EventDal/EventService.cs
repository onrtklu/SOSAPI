using SOS.DataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SOS.DataAccess.DapperDal.EventDal
{
    public class EventService : IEventService
    {
        IUnitOfWork _unitOfWork = null;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string GetEvent(int id)
        {
            var result = _unitOfWork.Connection.Query("select * from dbo.Event");
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
    }
}
