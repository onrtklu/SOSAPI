using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public interface ISosResult
    {
        bool Statu { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string Status { get; }
        string Message { get; set; }
    }
}
