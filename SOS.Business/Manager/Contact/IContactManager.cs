using SOS.DataObjects.ComplexTypes.Contact;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Contact
{
    public interface IContactManager
    {
        ISosResult SendMessage(ContactDtoInsert contactDtoInsert);
    }
}
