using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.About
{
    public interface IAboutManager 
    {
        ISosResult GetAbout();
    }
}
