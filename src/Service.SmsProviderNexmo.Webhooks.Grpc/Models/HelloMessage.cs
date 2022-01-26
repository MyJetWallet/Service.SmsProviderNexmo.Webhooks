using System.Runtime.Serialization;
using Service.SmsProviderNexmo.Webhooks.Domain.Models;

namespace Service.SmsProviderNexmo.Webhooks.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}