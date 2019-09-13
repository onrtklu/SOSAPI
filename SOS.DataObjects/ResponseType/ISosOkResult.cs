using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public interface ISosOkResult<T> : ISosResult
    {
        T Data { get; set; }
    }
}
