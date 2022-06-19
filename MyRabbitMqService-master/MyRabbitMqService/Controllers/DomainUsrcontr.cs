using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyRabbitMqService.BL.Interfaces;
using MyRabbitMqService.Models;

namespace MyRabbitMqService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DomainUsrcontr : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ILogger<DomainUsrcontr> _logger;


        public DomainUsrcontr(ILogger<DomainUsrcontr> logger, IRabbitMqService rabbitMqService)
        {
            _logger = logger;
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost]
        public async Task<IActionResult> SendDomainUserInfo([FromBody] User p)
        {
            await _rabbitMqService.SendDomainUserinfo(p);

            return Ok();
        }
    }
}
