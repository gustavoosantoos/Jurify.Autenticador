using Jurify.Autenticador.Web.Domain.Model.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Infrastructure.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainValidationException ex)
            {
                context.Result = new BadRequestObjectResult(ex.Errors);
            }
        }
    }
}
