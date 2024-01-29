using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListContentController : ControllerBase
    {

        private readonly ListContentService _listOperationsService;

        public ListContentController(ListContentService listOperationsService)
        {
            _listOperationsService = listOperationsService;
        }

        [HttpGet("FiltrarLista", Name = "FiltrarLista")]
        public ActionResult<List<string>> FiltrarLista()
        {
            return _listOperationsService.FiltrarLista();
        }
    }
}
