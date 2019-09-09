using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Customer
{
    public class ResultRegisterLoginDto
    {
        public string NameSurname { get; set; }
        public string PictureUrl { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
