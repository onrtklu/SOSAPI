using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Utilities.Response
{
    public static class Response
    {
        public static SosResult<T> SosResult<T>(this T data, HttpStatusCode code = HttpStatusCode.OK, bool statu = true, string message = null) => new SosResult<T>()
        {
            Statu = statu,
            StatusCode = code,
            Data = data,
            Message = message
        };

        private static SosErrorResult _sosError;
        public static SosErrorResult SosErrorResult(this HttpStatusCode code, string message = null)
        {
            if(_sosError == null)
                _sosError = new SosErrorResult()
                {
                    Statu = false,
                    StatusCode = code,
                    Message = message
                };
            else
            {
                _sosError.Statu = false;
                _sosError.StatusCode = code;
                _sosError.Message = message;
            }

            return _sosError;
        }

        private static SosOpResult _SosOp;
        public static SosOpResult SosOpResult(this HttpStatusCode code, int? id, string message = null, bool statu = true)
        {
            if (_SosOp == null)
                _SosOp = new SosOpResult()
                {
                    Statu = statu,
                    StatusCode = code,
                    Id = id,
                    Message = message
                };
            else
            {
                _SosOp.Statu = statu;
                _SosOp.StatusCode = code;
                _SosOp.Id = id;
                _SosOp.Message = message;
            }

            return _SosOp;
        }

        public static SosOpDataResult<T> SosOpDataResult<T>(this HttpStatusCode code, int? id, T data, string message = null, bool statu = true) => new SosOpDataResult<T>()
        {
            Statu = statu,
            StatusCode = code,
            Id = id,
            Data = data,
            Message = message
        };

    }
}
