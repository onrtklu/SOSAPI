using SOS.DataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Account
{
    public class AccountManager : IAccountManager
    {
        private IUnitOfWork _uow;
        public AccountManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Login(string userName, string password)
        {
            if (userName == "Onur" && password == "123456")
                return true;

            return false;
        }
    }
}
