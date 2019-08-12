using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOS.API.Filters
{
    public class QRCodeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public QRCodeAttribute(bool Required = true)
        {
            SetRequired(Required);
        }

        private bool required;

        public bool GetRequired()
        {
            return required;
        }

        private void SetRequired(bool value)
        {
            required = value;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
        }
    }

}