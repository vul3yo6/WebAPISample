using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiApp
{
    public class LogExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.TraceError("例外: {0}", actionExecutedContext.Exception.Message);
            Trace.TraceError("請求 URI: {0}", actionExecutedContext.Request.RequestUri);

            base.OnException(actionExecutedContext);
        }
    }
}