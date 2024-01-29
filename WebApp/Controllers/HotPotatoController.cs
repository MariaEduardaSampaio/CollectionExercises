using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotPotatoController : ControllerBase
    {
        private readonly HotPotatoService _batataQuenteService;

        public HotPotatoController(HotPotatoService batataQuenteService)
        {
            _batataQuenteService = batataQuenteService;
        }

        [HttpGet("BatataQuente", Name = "BatataQuente")]

        public ActionResult<string> JogarBatataQuente()
        {
            return _batataQuenteService.JogarBatataQuente();
        }
    }
}
