﻿using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ResponseType
{
    public class SosResult<T> : ISosResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Status => StatusCode.ToString();
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
