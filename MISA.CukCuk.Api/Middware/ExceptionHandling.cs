using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Middware
{
    /// <summary>
    /// middleware exception
    /// </summary>
    /// CreatedBy: LMDuc (27/04/2021)
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// message lỗi
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception">lỗi bắt được</param>
        /// <returns></returns>
        /// CreateBy: LMDuc (27/04/2021)
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //HttpStatusCode status;
            string message;
            var response = new
            {
                devMsg = exception.Message,
                userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA",
                MISACode = "002",
                Data = exception.Data
            };
            var stackTrace = String.Empty;
            message = exception.Message;
            var exceptionType = exception.GetType();
            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync(result);
        }
    }
}
