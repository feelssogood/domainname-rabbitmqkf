using MyRabbitMqService.Models;
using System.Threading.Tasks;

namespace MyRabbitMqService.BL.Interfaces
{

    public interface IKafkaProducer
    {
        Task SendDomainUsrINFO_KF(User u);
    }
}
