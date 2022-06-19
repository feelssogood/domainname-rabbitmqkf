using MessagePack;
using MyRabbitMqService.BL.Common;
using MyRabbitMqService.BL.Interfaces;
using MyRabbitMqService.BL.Services;
using MyRabbitMqService.Models;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MyRabbitMqService.BL.DataFlow
{
    public class UserDataFlow : IUserDataFlow
    {
        private readonly TransformBlock<byte[], User> entryBlock;

        private readonly IKafkaProducer _kafkaProducer;

        public UserDataFlow(IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;


            entryBlock = new TransformBlock<byte[], User>(data =>
              MessagePackSerializer.Deserialize<User>(data)
             );

            var enrichBlock = new TransformBlock<User, User>(u =>
            {
                u.DomainName = "changed";
                u.LUPD_Datetime = DateTime.Now;
                return u;
            });

            var publishBlock = new ActionBlock<User>(u =>
            {
                Console.WriteLine($"Domain Name {u.DomainName} , Last Update Datetime {u.LUPD_Datetime}");
                
                _kafkaProducer.SendDomainUsrINFO_KF(u);                
            });

            var linkOptions = new DataflowLinkOptions()
            {
                PropagateCompletion = true
            };

            entryBlock.LinkTo(enrichBlock, linkOptions);
            enrichBlock.LinkTo(publishBlock, linkOptions);
        }

        public async Task SendDomainUSR(byte[] data)
        {
            await entryBlock.SendAsync(data);
        }
    }
}
