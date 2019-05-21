using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOS.API.Service
{
    public interface IUserService
    {
        List<string> GetUserFullNames();
    }

    public class UserService : IUserService
    {
        public List<string> GetUserFullNames()
        {
            return new List<string>
                              { "Olcay Şahan",
                                "Anderson Talisca",
                                "Oğuzhan Özyakup",
                                "Ricardo Quaresma",
                                "Cenk Tosun" };
        }
    }
}