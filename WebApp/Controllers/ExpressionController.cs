using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ExpressionController : ControllerBase
    {
        private readonly ExpressionService _stackOperationsService;

        public ExpressionController(ExpressionService stackOperationsService)
        {
            _stackOperationsService = stackOperationsService;
        }


        [HttpGet("VerificarExpressaoBalanceada", Name = "VerificarExpressaoBalanceada")]
        public ActionResult<bool> ExpressaoEhBalanceada()
        {
            return _stackOperationsService.ExpressaoEhBalanceada();
        }
    }
}