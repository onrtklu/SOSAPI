using SOS.DataObjects.HateoasType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public class SosResult<T> : ISosOkResult<T>
    {
        public bool Statu { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Status => StatusCode.ToString();

        private string message;
        public string Message { get => message; set => message = value; }

        public T Data { get; set; }

        public IList<ILink> Links { get; set; }
    }
}
