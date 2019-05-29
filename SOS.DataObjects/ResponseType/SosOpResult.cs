using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SOS.DataObjects.HateoasType;

namespace SOS.DataObjects.ResponseType
{
    public class SosOpResult : ISosOpResult
    {
        public bool Statu { get ; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Status => StatusCode.ToString();

        private string message;
        public string Message { get => message; set => message = value; }

        public int? Id { get; set; }

        public IList<ILink> Links { get; set; }
    }
}
