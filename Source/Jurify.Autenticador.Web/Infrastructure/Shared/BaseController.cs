using Jurify.Autenticador.Web.UseCases.Core;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Infrastructure.Shared
{
    public class BaseController : ControllerBase
    {
        public ActionResult AppResponse<T>(Response<T> response)
        {
            if (response.IsSucess)
                return Ok(response.Result);

            return BadRequest(response.Errors);
        }
    }
}
