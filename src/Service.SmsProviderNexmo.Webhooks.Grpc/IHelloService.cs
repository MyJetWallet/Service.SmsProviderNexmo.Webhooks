using System.ServiceModel;
using System.Threading.Tasks;
using Service.SmsProviderNexmo.Webhooks.Grpc.Models;

namespace Service.SmsProviderNexmo.Webhooks.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}