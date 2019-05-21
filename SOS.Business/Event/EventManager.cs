using SOS.DataAccess.DAL;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Event
{
    public class EventManager : IEventManager
    {
        private IEventService _eventService;
        

        public string GetEvent(int id)
        {
            using (DalSession dalSession = new DalSession())
            {
                //Your database code here
                _eventService = new EventService(dalSession.UnitOfWork);//UoW have no effect here as Begin() is not called.

                return _eventService.GetEvent(id);
            }

        }

        public IList<string> GetEventDetails()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork unitOfWork = dalSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    _eventService = new EventService(unitOfWork);
                    //_eventService.Insert(myPoco);

                    unitOfWork.Commit();

                    return _eventService.GetEventDetails();
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
