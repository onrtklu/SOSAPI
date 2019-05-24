using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Response
{
    public class SosResult<T> : ISosResult
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string Status => StatusCode.ToString();
        public T Data { get; set; }
        public string Message { get; set; }
    }

    public interface ISosResult
    {

    }
}
