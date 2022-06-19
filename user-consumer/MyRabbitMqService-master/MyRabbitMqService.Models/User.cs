using MessagePack;
using System;

namespace MyRabbitMqService.Models
{
    [MessagePackObject]
    public class User
    {
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public string DomainName { get; set; }

        [Key(2)]
        public DateTime LUPD_Datetime { get; set; }
    }
}
