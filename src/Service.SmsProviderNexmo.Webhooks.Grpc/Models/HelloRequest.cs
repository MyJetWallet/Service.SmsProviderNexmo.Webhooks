using System.Runtime.Serialization;

namespace Service.SmsProviderNexmo.Webhooks.Grpc.Models
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}