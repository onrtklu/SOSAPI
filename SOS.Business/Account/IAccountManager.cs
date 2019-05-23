using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Account
{
    public interface IAccountManager
    {
        bool Login(string userName, string password);
    }
}
