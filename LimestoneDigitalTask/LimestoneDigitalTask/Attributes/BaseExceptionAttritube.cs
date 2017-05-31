using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Helpers;
using LimestoneDigitalTask.Models.DTO;
using Microsoft.ApplicationInsights;

namespace LimestoneDigitalTask.Attributes
{
    public class BaseExceptionAttritube : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext excepionContext)
        {
            var baseEx = excepionContext.Exception as BaseException;

            if (excepionContext.Exception is BaseException) excepionContext.Result = baseEx.result;
            else
            {
                var log = new
                {
                    message = excepionContext.Exception.Message,
                    stack_trace = excepionContext.Exception.StackTrace.Replace("\n", "").Replace("\r", "").Replace("\t", ""),
                    method = excepionContext.HttpContext.Request.RawUrl,
                    time = DateTime.UtcNow
                };

                var str = $"| {log.time} | {log.method} | {log.message} | {log.stack_trace}";

                Logger.InitLogger();
                Logger.Log.Error(str);

                excepionContext.Result = new BaseException(Enums.Errors.InternalServerError).result;
            }
        }
    }
}