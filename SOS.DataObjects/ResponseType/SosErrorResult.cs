using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public class SosErrorResult : ISosResult
    {
        public bool Statu { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Status => StatusCode.ToString();
        public string Message { get; set; }
    }
}
