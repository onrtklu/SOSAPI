using SOS.DataObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Utilities.Response
{
    public class Response
    {
        public static SosResult<T> SosResult<T>(T data, HttpStatusCode code, string message = null) => new SosResult<T>()
        {
            StatusCode = code,
            Data = data,
            Message = message
        };

        public static SosResult<T> SosError<T>(string message, HttpStatusCode code) => new SosResult<T>()
        {
            StatusCode = code,
            Message = message
        };
    }
}
