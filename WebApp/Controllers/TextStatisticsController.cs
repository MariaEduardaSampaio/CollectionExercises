using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextStatisticsController: ControllerBase
    {
        private readonly TextStatisticsService _textStatisticsService;

        public TextStatisticsController(TextStatisticsService textStatisticsService)
        {
            _textStatisticsService = textStatisticsService;
        }

        [HttpGet("ContarOcorrenciaDePalavras", Name = "ContarOcorrenciaDePalavras")]
        public ActionResult<string> ContarOcorrenciaDePalavras()
        {
            return _textStatisticsService.ContarOcorrenciaDePalavras();
        }
    }
}
