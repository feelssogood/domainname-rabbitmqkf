using MyRabbitMqService.Models;
using System.Collections;
using System.Collections.Generic;

namespace MyRabbitMqService.BL.Services
{
    public class UserCacheDictionary
    {
        public static IDictionary DomainUsrs = new Dictionary<int, User>();

    }
}