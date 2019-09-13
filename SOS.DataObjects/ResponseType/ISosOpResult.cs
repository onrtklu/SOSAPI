using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public interface ISosOpResult : ISosResult
    {
        int? Id { get; set; }
    }
}
