using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SOS.API.ExcHand
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            //Loglama için ilgili ilemlerin yapıldığı yer (db log, file log vs gibi)
        }
    }
}