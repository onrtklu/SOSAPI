using SOS.DataObjects.ResponseType;
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

        private static SosErrorResult _sosError;
        public static SosErrorResult SosError(HttpStatusCode code, string message = null)
        {
            if(_sosError == null)
                _sosError = new SosErrorResult()
                {
                    StatusCode = code,
                    Message = message
                };
            else
            {
                _sosError.StatusCode = code;
                _sosError.Message = message;
            }

            return _sosError;
        }

        private static SosOpResult _SosOp;
        public static SosOpResult sosOpResult(HttpStatusCode code, int? id, string message = null)
        {
            if (_SosOp == null)
                _SosOp = new SosOpResult()
                {
                    StatusCode = code,
                    Id = id,
                    Message = message
                };
            else
            {
                _SosOp.StatusCode = code;
                _SosOp.Id = id;
                _SosOp.Message = message;
            }

            return _SosOp;
        }
    }
}
