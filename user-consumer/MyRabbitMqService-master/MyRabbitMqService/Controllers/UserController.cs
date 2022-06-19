using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyRabbitMqService.BL.DataFlow;
using MyRabbitMqService.BL.Interfaces;
using MyRabbitMqService.Models;

namespace MyRabbitMqService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        //private readonly IUserDataFlow _userDataFlow;
        private readonly IKafkaProducer _kafkaProducer;


        public UserController(ILogger<UserController> logger,
            IKafkaProducer kafkaProducer
            //IUserDataFlow userDataFlow
            )
        {
            _logger = logger;
            _kafkaProducer = kafkaProducer;
            //_userDataFlow = userDataFlow;
        }
    }
}
